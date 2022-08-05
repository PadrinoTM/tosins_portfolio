using MyVidly.Models;
using MyVidly.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyVidly.Data.IServices
{
    public interface ISkillServices
    {
        Task<IEnumerable<Skills>> AllList();
        Task<Skills> GetById(int id);
        Task<bool> Create(ListOfSkillsViewModel skillsViewModel);
        public Task<bool> EditByDetails(ListOfSkillsViewModel skillsViewModel);
        Task<bool> RemovedData(Skills skill);
    }
}
