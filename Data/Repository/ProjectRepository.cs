using Microsoft.EntityFrameworkCore;
using MyVidly.Data.IRepository;
using MyVidly.Models;
using MyVidly.Models.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyVidly.Data.Repository
{

    public class ProjectRepository : IProjectRepository
    {
        private readonly MyVidlyDbContext _context;

        public ProjectRepository(MyVidlyDbContext context)
        {
            _context = context;

        }

        public async Task<IEnumerable<Project>> GetAll()
        {
            return await _context.Projectz.ToListAsync();
        }

        public async Task<Project> GetByIdAsync(int id)
        {
            return await _context.Projectz.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<bool> Add(Project project)
        {
            _context.Add(project);
            return await Save();
        }
        public async Task<bool> UpdateDataToDb(Project project)
        {
            _context.Projectz.Update(project);
            return await Save();
        }

        public async Task<bool> DeleteFromDb(Project project)
        {
            _context.Projectz.Remove(project);
            return await Save();
        }
        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0;
        }
    }

}
