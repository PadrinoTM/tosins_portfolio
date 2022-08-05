using MyVidly.Models;
using MyVidly.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyVidly.Data.IServices
{
    public interface IProjectServices
    {
        Task<IEnumerable<Project>> AllList();
        Task<Project> GetById(int id);
        Task<bool> Create(ListOfProjectViewModel projViewModel);
        public Task<bool> EditByDetails(ListOfProjectViewModel projViewModel);
        Task<bool> RemoveData(Project exp);
    }
}
