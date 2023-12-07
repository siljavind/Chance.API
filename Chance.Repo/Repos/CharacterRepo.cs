// using Chance.Repo.Data;
// using Chance.Repo.Models;
// using Chance.Repo.Interfaces;
// using Microsoft.EntityFrameworkCore;
// using System.IO.Compression;
// using System.Reflection;
// using System.Text.Json.Serialization;
// using Chance.Repo.DTOs;

// namespace Chance.Repo.Repos
// {
//     public class CharacterRepo : ICharacterRepo
//     {
//         ChanceDbContext _context;

//         public CharacterRepo(ChanceDbContext context)
//         {
//             _context = context;
//         }

//         public async Task<List<Character>?> GetAll() =>
//             await _context.Characters
//                 .Include(c => c.Race)
//                 .Include(c => c.Subrace)
//                 .Include(c => c.Class)
//                 .Include(c => c.Background)
//                 .Include(c => c.User)
//                 .ToListAsync();

//         public async Task<Character?> GetById(int id) =>
//             await _context.Characters
//                 .Include(c => c.Race)
//                 .Include(c => c.Subrace)
//                 .Include(c => c.Class)
//                 .Include(c => c.Background)
//                 .Include(c => c.User)
//                 .SingleOrDefaultAsync(c => c.Id == id);

//         public async Task<Character> Create(Character character)
//         {
//             _context.Characters.Add(character);
//             await _context.SaveChangesAsync();

//             return await GetById(character.Id);
//         }

//         public async Task<Character> Update(Character character)
//         {
//             if (!await Exists(character.Id))
//                 throw new NotFoundException();

//             foreach (var prop in typeof(Character).GetProperties())
//             {
//                 // Ignore the Id property and any properties with the JsonIgnore attribute
//                 if (prop.GetCustomAttribute<JsonIgnoreAttribute>() != null || prop.Name == "Id") continue;

//                 // Get the value of the property from the updated entity
//                 var updatedValue = prop.GetValue(character);

//                 // If the value not the default value for the property's type, mark the property as modified
//                 if (!updatedValue.Equals(GetDefaultValue(prop.PropertyType)))
//                     _context.Entry(character).Property(prop.Name).IsModified = true;

//             }
//             // Save changes to database
//             await _context.SaveChangesAsync();

//             // Detach the entity from the context so I can call GetById() and get the full entity with both changed and unchanged properties
//             _context.Entry(character).State = EntityState.Detached;

//             // Get and return entity with updated values
//             return await GetById(character.Id);
//         }

//         public async Task<int> Delete(int id)
//         {
//             var entity = await _context.Characters.SingleAsync(e => e.Id == id) ?? throw new NotFoundException();
//             _context.Characters.Remove(entity);
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

//         public async Task<bool> Exists(string title) => await _context.Characters.AnyAsync(e => e.Title == title);

//         public async Task<bool> Exists(int id) => await _context.Characters.AnyAsync(e => e.Id == id);
//     }




// }