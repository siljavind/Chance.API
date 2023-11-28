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

        public List<Background> GetAll() => _context.Backgrounds.ToList();

        public Background Create(Background background)
        {
            _context.Backgrounds.Add(background);
            _context.SaveChanges();
            return background;
        }

        public int Delete(int id) => _context.Backgrounds.Where(b => b.Id == id).ExecuteDelete();

        public Background GetById(int id) => _context.Backgrounds.Single(b => b.Id == id);

        public Background Update(Background background)
        {
            throw new NotImplementedException();
        }

    }
}