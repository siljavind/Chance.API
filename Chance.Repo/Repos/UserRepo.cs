// using Chance.Repo.Data;
// using Chance.Repo.Models;
// using Chance.Repo.Interfaces;
// using Microsoft.EntityFrameworkCore;
// using System.IO.Compression;
// using System.Reflection;
// using System.Text.Json.Serialization;

// namespace Chance.Repo.Repos
// {
//     public class UserRepo : IUserRepo
//     {
//         ChanceDbContext _context;

//         public UserRepo(ChanceDbContext context)
//         {
//             _context = context;
//         }

//         public async Task<List<User>> GetAll() =>
//             await _context.Users.ToListAsync();

//         public async Task<User?> GetById(int id) =>
//             await _context.Users.SingleOrDefaultAsync(c => c.Id == id);

//         public async Task<User> Create(User user)
//         {
//             _context.Users.Add(user);
//             await _context.SaveChangesAsync();

//             return await GetById(user.Id);
//         }

//         public async Task<User> Update(User user)
//         {
//             if (!await Exists(user.Id))
//                 throw new NotFoundException();

//             foreach (var prop in typeof(User).GetProperties())
//             {
//                 // Ignore the Id property and any properties with the JsonIgnore attribute
//                 if (prop.GetCustomAttribute<JsonIgnoreAttribute>() != null || prop.Name == "Id") continue;

//                 // Get the value of the property from the updated entity
//                 var updatedValue = prop.GetValue(user);

//                 // If the value not the default value for the property's type, mark the property as modified
//                 if (!updatedValue.Equals(GetDefaultValue(prop.PropertyType)))
//                     _context.Entry(user).Property(prop.Name).IsModified = true;

//             }
//             // Save changes to database
//             await _context.SaveChangesAsync();

//             // Detach the entity from the context so I can call GetById() and get the full entity with both changed and unchanged properties
//             _context.Entry(user).State = EntityState.Detached;

//             // Get and return entity with updated values
//             return await GetById(user.Id);
//         }

//         public async Task<int> Delete(int id)
//         {
//             var entity = await _context.Users.SingleAsync(e => e.Id == id) ?? throw new NotFoundException();
//             _context.Users.Remove(entity);
//             return await _context.SaveChangesAsync();
//         }

//         private static object? GetDefaultValue(Type t)
//         {
//             // Since Activator.CreateInstance() instantiates a new object, I only want to use it for value types
//             if (t.IsValueType)
//                 return Activator.CreateInstance(t);

//             // If t is not a value type, but instead a reference type, it returns null (which is the default value for reference types)
//             return null;
//         }

//         public async Task<bool> Exists(string title) => await _context.Users.AnyAsync(e => e.Title == title);

//         public async Task<bool> Exists(int id) => await _context.Users.AnyAsync(e => e.Id == id);
//     }




// }