using AutoMapper;
using MyVidly.Data.IRepository;
using MyVidly.Data.IServices;
using MyVidly.Models;
using MyVidly.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyVidly.Data.Services
{
    public class ExperienceServices : IExperienceServices
    {
        private readonly IExperienceRepository _exp;
        private readonly IMapper _mapper;

        public ExperienceServices(IExperienceRepository experience, IMapper map)
        {
            _exp = experience;
            _mapper = map;
        }
        public async Task<IEnumerable<Experience>> AllList()
        {
            return await _exp.GetAll();
        }

        public async Task<bool> Create(ListOfExperiencesViewModel EVM)
        {
            var NewExp = _mapper.Map<Experience>(EVM);
            return await _exp.Add(NewExp);
        }

        public async Task<bool> EditByDetails(ListOfExperiencesViewModel expViewModel)
        {
            var EditExp = _mapper.Map<Experience>(expViewModel);
            return await _exp.UpdateDataToDb(EditExp);
        }

        public async Task<Experience> GetById(int id)
        {
            return await _exp.GetByIdAsync(id);
        }

        public async Task<bool> RemoveData(Experience exp)
        {
            return await _exp.DeleteFromDb(exp);
        }
    }
}
