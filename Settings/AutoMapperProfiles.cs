using AutoMapper;
using MyVidly.Models;
using MyVidly.ViewModel;

namespace MyVidly.Settings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Project, ListOfProjectViewModel>().ReverseMap();
            CreateMap<Skills, ListOfSkillsViewModel>().ReverseMap();
            CreateMap<Experience, ListOfExperiencesViewModel>().ReverseMap();

        }
    }
}
