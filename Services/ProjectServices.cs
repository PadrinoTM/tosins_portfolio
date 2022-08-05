using AutoMapper;
using MyVidly.Data.IRepository;
using MyVidly.Data.IServices;
using MyVidly.Models;
using MyVidly.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyVidly.Data.Services
{
    public class ProjectServices : IProjectServices
    {
        private readonly IProjectRepository _project;
        private readonly IMapper _mapper;

        public ProjectServices(IProjectRepository project, IMapper mapper)
        {
            _project = project;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Project>> AllList()
        {
            return await _project.GetAll();
        }

        public async Task<bool> Create(ListOfProjectViewModel projViewModel)
        {
            var addProject = _mapper.Map<Project>(projViewModel);
            return await _project.Add(addProject);
        }

        public async Task<bool> EditByDetails(ListOfProjectViewModel projViewModel)
        {
            var editInfo = _mapper.Map<Project>(projViewModel);
            return await _project.UpdateDataToDb(editInfo);
        }

        public async Task<Project> GetById(int id)
        {
            return await _project.GetByIdAsync(id);
        }

        public async Task<bool> RemoveData(Project exp)
        {
            return await _project.DeleteFromDb(exp);
        }
    }
}
