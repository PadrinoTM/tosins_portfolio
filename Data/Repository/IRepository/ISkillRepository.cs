using MyVidly.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyVidly.Data.IRepository
{
    public interface ISkillRepository
    {
        Task<IEnumerable<Skills>> GetAll();
        Task<Skills> GetByIdAsync(int id);
        Task<bool> Add(Skills skill);
        Task<bool> UpdateDataToDb(Skills skill);
        Task<bool> DeleteFromDb(Skills skill);
        Task<bool> Save();

    }
}
