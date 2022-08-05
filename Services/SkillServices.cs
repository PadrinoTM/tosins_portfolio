using AutoMapper;
using MyVidly.Data.IRepository;
using MyVidly.Data.IServices;
using MyVidly.Models;
using MyVidly.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyVidly.Data.Services
{
    public class SkillServices : ISkillServices
    {
        private readonly ISkillRepository _skill;
        private readonly IMapper _mapper;

        public SkillServices(ISkillRepository skill, IMapper mapper)
        {
            _skill = skill;
            _mapper = mapper;

        }
        public async Task<IEnumerable<Skills>> AllList()
        {
            return await _skill.GetAll();
        }

        public async Task<Skills> GetById(int id)
        {
            return await _skill.GetByIdAsync(id);
        }
        public async Task<bool> Create(ListOfSkillsViewModel skill)
        {
            var addSkill = _mapper.Map<Skills>(skill);
            return await _skill.Add(addSkill);
        }
        public async Task<bool> EditByDetails(ListOfSkillsViewModel skill)
        {
            var editInfo = _mapper.Map<Skills>(skill);
            return await _skill.UpdateDataToDb(editInfo);
        }

        public async Task<bool> RemovedData(Skills skill)
        {
            return await _skill.DeleteFromDb(skill);
        }
    }
}

