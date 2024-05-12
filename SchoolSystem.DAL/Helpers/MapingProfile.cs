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

        }
    }
}
