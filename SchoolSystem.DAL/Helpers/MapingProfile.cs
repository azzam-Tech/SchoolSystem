using AutoMapper;
using SchoolSystem.BLL.DTOs;
using SchoolSystem.DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.DAL.Helpers
{
    public class MapingProfile : Profile
    {
        public MapingProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<Level, LevelDto>().ReverseMap();
            CreateMap<LevelDto, Level>().ReverseMap();
            CreateMap<Subject, SubjectDto>().ReverseMap();
            CreateMap<SubjectDto, Subject>().ReverseMap();
            //CreateMap<Class, ClassDto>().ReverseMap();
            //CreateMap<ClassDto, Class>().ReverseMap();
            //CreateMap<SubjectClass, SubjectClassDto>().ReverseMap();
            //CreateMap<SubjectClassDto, SubjectClass>().ReverseMap();
            CreateMap<HomeWork, HomeWorkDto>().ReverseMap();    
            CreateMap<HomeWorkDto, HomeWork>().ReverseMap();
            CreateMap<StudentQeustion, StudentQeustionDto>().ReverseMap();
            CreateMap<StudentQeustionDto, StudentQeustion>().ReverseMap();
            CreateMap<Reinforcementlesson, ReinforcementlessonDto>().ReverseMap();
            CreateMap<ReinforcementlessonDto, Reinforcementlesson>().ReverseMap();
            CreateMap<Solution, SolutionDto>().ReverseMap();
            CreateMap<SolutionDto, Solution>().ForMember(src => src.SolutionId , opt => opt.Ignore()).ReverseMap();
            CreateMap<StudentDegree, StudentDegreeDto>().ReverseMap();
            CreateMap<StudentDegreeDto, StudentDegree>().ForMember(src => src.StudentDegreeId, opt => opt.Ignore()).ReverseMap();

        }
    }
}
