using MyVidly.Models;
using MyVidly.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyVidly.Data.IServices
{
    public interface IExperienceServices
    {
        Task<IEnumerable<Experience>> AllList();
        Task<Experience> GetById(int id);
        Task<bool> Create(ListOfExperiencesViewModel expViewModel);
        public Task<bool> EditByDetails(ListOfExperiencesViewModel expViewModel);
        Task<bool> RemoveData(Experience exp);
    }
}
