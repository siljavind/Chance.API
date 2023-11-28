using Chance.Repo.Data;
using Chance.Repo.Models;
using Chance.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Chance.Repo.Repos
{
    public class BackgroundRepo : IBackgroundRepo
    {
        ChanceDbContext _context;

        public BackgroundRepo(ChanceDbContext context)
        {
            _context = context;
        }

        public async Task<List<Background>> GetAll() => await _context.Backgrounds.ToListAsync();

        public async Task<Background?> GetById(int id) => await _context.Backgrounds.SingleOrDefaultAsync(b => b.Id == id);

        public async Task<Background> Create(Background background)
        {
            // Add the background to the Backgrounds DbSet (not async because it doesn't require a database call)
            _context.Backgrounds.Add(background);

            // Save the changes asynchronously (async because it requires a database call)
            await _context.SaveChangesAsync();

            // Return the created background
            return background;
        }

        public async Task<Background> Update(Background background)
        {
            // Set the state of the background entity to Modified
            _context.Entry(background).State = EntityState.Modified;

            // Save the changes asynchronously
            await _context.SaveChangesAsync();

            // Return the updated background entity
            return background;
        }

        // Using the ExecuteDeleteAsync() instead of DeleteAsync() to delete and save changes in one step
        public async Task<int> Delete(int id) => await _context.Backgrounds.Where(b => b.Id == id).ExecuteDeleteAsync();

        public async Task<bool> Exists(string title) => await _context.Backgrounds.AnyAsync(b => b.Title == title);

    }
}