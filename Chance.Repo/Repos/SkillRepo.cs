using Chance.Repo.Data;
using Chance.Repo.Models;
using Chance.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Chance.Repo.Repos;

public class SkillRepo : IRepository<Skill>
{
    ChanceDbContext _context;

    public SkillRepo(ChanceDbContext context)
    {
        _context = context;
    }

    public async Task<List<Skill>> GetAll()
    {
        return await _context.Skills.ToListAsync();
    }

    public async Task<Skill> GetById(int id)
    {
        return await _context.Skills.SingleAsync(s => s.Id == id);
    }

    public async Task<Skill> GetBytitle(int skillType) => await _context.Skills.SingleAsync(s => s.Title == (SkillType)skillType);

    public Skill Create(Skill skill)
    {
        _context.Skills.Add(skill);
        _context.SaveChanges();
        return skill;
    }

    public Skill Update(Skill skill)
    {
        throw new NotImplementedException();
    }

    public int Delete(int id) => _context.Skills.Where(a => a.Id == id).ExecuteDelete();

}
