using Microsoft.EntityFrameworkCore;
using MyVidly.Data.IRepository;
using MyVidly.Models;
using MyVidly.Models.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyVidly.Data.Repository
{
    public class ExperienceRepository : IExperienceRepository
    {
        private readonly MyVidlyDbContext _context;

        public ExperienceRepository(MyVidlyDbContext context)
        {
            _context = context;

        }

        public async Task<bool> Add(Experience experience)
        {
            _context.Add(experience);
            return await Save();
        }

        public async Task<bool> DeleteFromDb(Experience experience)
        {
            _context.Experiencez.Remove(experience);
            return await Save();
        }

        public async Task<IEnumerable<Experience>> GetAll()
        {
            return await _context.Experiencez.ToListAsync();
        }

        public async Task<Experience> GetByIdAsync(int id)
        {
            return await _context.Experiencez.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0;
        }

        public async Task<bool> UpdateDataToDb(Experience experience)
        {
            _context.Experiencez.Update(experience);
            return await Save();
        }
    }
}
