using Chance.Repo.Data;
using Chance.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Reflection;
using System.Linq.Expressions;
using Microsoft.Data.SqlClient;

namespace Chance.Repo.Repos;

public class GenericRepo<T> : IGenericRepo<T> where T : class, IGeneric
{
    private readonly ChanceDbContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepo(ChanceDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task<List<T>> GetAll(params Expression<Func<T, object>>[] includeProperties)
    {
        var entities = await IncludeProperties(includeProperties).ToListAsync();

        if (entities.Count > 0)
            return entities;
        else
            throw new NotFoundException();
    }

    public async Task<T?> GetById(int id, params Expression<Func<T, object>>[] includeProperties)
    {
        try
        {
            return await IncludeProperties(includeProperties).SingleAsync(e => e.Id == id);
        }
        catch (InvalidOperationException)
        {
            throw new NotFoundException();
        }
    }

    public async Task<T?> GetByTitle(string title, params Expression<Func<T, object>>[] includeProperties)
    {
        try
        {
            return await IncludeProperties(includeProperties).SingleAsync(e => e.Title == title);
        }
        catch (InvalidOperationException)
        {
            throw new NotFoundException();
        }
    }

    public async Task<T> Create(T entity)
    {
        try
        {
            // Add the entity to the DbSet (not async because it doesn't require a database call)
            _dbSet.Add(entity);

            // Save the changes asynchronously (async because it requires a database call)
            await _context.SaveChangesAsync();

            // Return the created entity
            return await GetById(entity.Id);
        }
        catch (DbUpdateException e) when ((e.InnerException as SqlException)?.Number == 2627 || (e.InnerException as SqlException)?.Number == 2601)
        {
            throw new ConflictException();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<T> Update(T updatedEntity)
    {
        if (!await Exists(updatedEntity.Id))
            throw new NotFoundException();

        try
        {
            // Get properties of updatedEntity's type
            foreach (var prop in typeof(T).GetProperties())
            {
                // Ignore the Id property and any properties with the JsonIgnore attribute
                if (prop.GetCustomAttribute<JsonIgnoreAttribute>() != null || prop.Name == "Id") continue;

                // Get the value of the property from the updated entity
                var updatedValue = prop.GetValue(updatedEntity);

                // If the value not the default value for the property's type, mark the property as modified
                if (!updatedValue.Equals(GetDefaultValue(prop.PropertyType)))
                    _context.Entry(updatedEntity).Property(prop.Name).IsModified = true;

            }
            // Save changes to database
            await _context.SaveChangesAsync();

            // Detach the entity from the context so I can call GetById() and get the full entity with both changed and unchanged properties
            _context.Entry(updatedEntity).State = EntityState.Detached;

            // Get and return entity with updated values
            return await GetById(updatedEntity.Id);
        }
        catch (DbUpdateException e) when (e.InnerException?.Message.Contains("duplicate key value violates unique constraint") == true)
        {
            throw new ConflictException();
        }
    }

    // Using the ExecuteDeleteAsync() instead of DeleteAsync() to delete and save changes in one step
    public async Task<int> Delete(int id)
    {
        if (await Exists(id))
        {
            _dbSet.Remove(await _dbSet.SingleAsync(e => e.Id == id));
            return await _context.SaveChangesAsync();
        }

        throw new NotFoundException($"An entity with the id {id} could not be found.");
    }

    public async Task<bool> Exists(string title) => await _dbSet.AnyAsync(e => e.Title == title);

    public async Task<bool> Exists(int id) => await _dbSet.AnyAsync(e => e.Id == id);

    private static object? GetDefaultValue(Type t)
    {
        // Since Activator.CreateInstance() instantiates a new object, I only want to use it for value types
        if (t.IsValueType)
            return Activator.CreateInstance(t);

        // If t is not a value type, but instead a reference type, it returns null (which is the default value for reference types)
        return null;
    }

    private IQueryable<T> IncludeProperties(params Expression<Func<T, object>>[] includeProperties)
    {
        var query = _dbSet.AsQueryable();

        foreach (var includeProperty in includeProperties)
        {
            query = query.Include(includeProperty);
        }

        return query;
    }
}
