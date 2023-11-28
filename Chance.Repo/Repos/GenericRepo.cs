using Chance.Repo.Data;
using Chance.Repo.Models;
using Chance.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Chance.Repo.Repos
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class, IGeneric
    {
        private readonly ChanceDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepo(ChanceDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<List<T>> GetAll() => await _dbSet.ToListAsync();

        public async Task<T?> GetById(int id) => await _dbSet.SingleOrDefaultAsync(e => e.Id == id);

        public async Task<T> Create(T entity)
        {
            // Add the entity to the DbSet (not async because it doesn't require a database call)
            _dbSet.Add(entity);

            // Save the changes asynchronously (async because it requires a database call)
            await _context.SaveChangesAsync();

            // Return the created entity
            return entity;
        }

        public async Task<Background> UpdateOrg(Background background)
        {
            // Set the state of the background entity to Modified
            _context.Entry(background).State = EntityState.Modified;

            // Save the changes asynchronously
            await _context.SaveChangesAsync();

            // Return the updated background entity
            return background;
        }

        public async Task<T> Update(T entity)
        {
            //TODO HANDLE NULLS
            try
            {
                // Set the state of the background entity to Modified
                _context.Entry(entity).State = EntityState.Modified;

                // Save the changes asynchronously
                await _context.SaveChangesAsync();

                // Return the updated background entity
                return entity;

            }
            catch (Exception e)
            {
                return e.Message as T; //TODO LOOK AT THIS
            }

        }

        // Using the ExecuteDeleteAsync() instead of DeleteAsync() to delete and save changes in one step
        public async Task<int> Delete(int id) => await _dbSet.Where(e => e.Id == id).ExecuteDeleteAsync();

        public async Task<bool> TitleExists(string title) => await _dbSet.AnyAsync(e => e.Title == title);

        public async Task<bool> Exists(int id) => await _dbSet.AnyAsync(e => e.Id == id);

    }
}