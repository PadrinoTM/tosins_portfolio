using Microsoft.EntityFrameworkCore;
using MyVidly.Data.IRepository;
using MyVidly.Models;
using MyVidly.Models.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyVidly.Data.Repository
{
    public class SkillRepository : ISkillRepository
    {
        private readonly MyVidlyDbContext _context;

        public SkillRepository(MyVidlyDbContext context)
        {
            _context = context;

        }

        public async Task<bool> Add(Skills skill)
        {
            _context.Add(skill);
            return await Save();
        }

        public async Task<bool> DeleteFromDb(Skills skill)
        {
            _context.Skillz.Remove(skill);
            return await Save();
        }

        public async Task<IEnumerable<Skills>> GetAll()
        {
            return await _context.Skillz.ToListAsync();
        }

        public async Task<Skills> GetByIdAsync(int id)
        {
            return await _context.Skillz.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0;
        }

        public async Task<bool> UpdateDataToDb(Skills skill)
        {
            _context.Skillz.Update(skill);
            return await Save();
        }
    }


}

