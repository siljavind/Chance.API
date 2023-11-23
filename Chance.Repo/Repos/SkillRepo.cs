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

    public async Task<List<Skill>> GetAll() => await _context.Skills.ToListAsync();

    public async Task<Skill> GetById(int id) => await _context.Skills.SingleAsync(a => a.SkillType == (SkillType)id);

    public async Task<Skill> GetBySkillType(int skillType) => await _context.Skills.SingleAsync(a => a.SkillType == (SkillType)skillType);

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

    public int Delete(int id) => _context.Skills.Where(a => a.SkillType == (SkillType)id).ExecuteDelete();

}
