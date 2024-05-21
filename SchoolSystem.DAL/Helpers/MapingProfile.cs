using AutoMapper;
using SchoolSystem.BLL.DTOs;
using SchoolSystem.BLL.DTOs.EditDto;
using SchoolSystem.BLL.DTOs.GetDto;
using SchoolSystem.BLL.DTOs.PostDto;
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

            //Level
            CreateMap<Level, GetLevelDto>().ReverseMap();
            CreateMap<PostLevelDto, Level>().ReverseMap();

            //Subject
            CreateMap<Subject, GetSubjectDto>().ReverseMap();
            CreateMap<PostSubjectDto, Subject>().ReverseMap();


            //CreateMap<Class, ClassDto>().ReverseMap();
            //CreateMap<ClassDto, Class>().ReverseMap();
            //CreateMap<SubjectClass, SubjectClassDto>().ReverseMap();
            //CreateMap<SubjectClassDto, SubjectClass>().ReverseMap();

            //HomeWorke
            CreateMap<HomeWork, GetHomeWorkDto>().ReverseMap();
            CreateMap<PostHomeWorkDto, HomeWork>().ReverseMap();


            //StudentQeustion
            CreateMap<StudentQeustion, GetStudentQeustionDto>().ReverseMap();
            CreateMap<PostStudentQeustionDto, StudentQeustion>().ReverseMap();

            //Reinforcementlesson
            CreateMap<Reinforcementlesson, GetReinforcementlessonDto>().ReverseMap();
            CreateMap<PostReinforcementlessonDto, Reinforcementlesson>().ReverseMap();

            //Solution
            CreateMap<Solution, GetSolutionDto>().ReverseMap();
            CreateMap<PostSolutionDto, Solution>().ReverseMap();
            CreateMap<EditSolutionDto, Solution>().ReverseMap();


            //StudentDegree
            CreateMap<StudentDegree, GetStudentDegreeDto>().ReverseMap();
            CreateMap<PostStudentDegreeDto, StudentDegree>().ReverseMap();

            //ClassTimeTable
            CreateMap<ClassTimeTable, GetClassTimeTableDto>().ReverseMap();
            CreateMap<PostClassTimeTableDto, ClassTimeTable>().ReverseMap();


            //FollowUpNoteBook
            CreateMap<FollowUpNoteBook, GetFollowUpNoteBookDto>().ReverseMap();
            CreateMap<PostFollowUpNoteBookDto, FollowUpNoteBook>().ReverseMap();


            //Level
            //CreateMap<Level, LevelDto>().ReverseMap();
            //CreateMap<LevelDto, Level>().ReverseMap();


            //Subject
            //CreateMap<Subject, SubjectDto>().ReverseMap();
            //CreateMap<SubjectDto, Subject>().ReverseMap();


            //HomeWorke
            //CreateMap<HomeWork, HomeWorkDto>().ReverseMap();    
            //CreateMap<HomeWorkDto, HomeWork>().ReverseMap();



            //StudentQeustion
            //CreateMap<StudentQeustion, StudentQeustionDto>().ReverseMap();
            //CreateMap<StudentQeustionDto, StudentQeustion>().ReverseMap();


            //Reinforcementlesson
            //CreateMap<Reinforcementlesson, ReinforcementlessonDto>().ReverseMap();
            //CreateMap<ReinforcementlessonDto, Reinforcementlesson>().ReverseMap();



            //Solution
            //CreateMap<Solution, SolutionDto>().ReverseMap();
            //CreateMap<SolutionDto, Solution>().ForMember(src => src.SolutionId , opt => opt.Ignore()).ReverseMap();



            //StudentDegree
            //CreateMap<StudentDegree, StudentDegreeDto>().ReverseMap();
            //CreateMap<StudentDegreeDto, StudentDegree>().ForMember(src => src.StudentDegreeId, opt => opt.Ignore()).ReverseMap();


            //ClassTimeTable
            //CreateMap<ClassTimeTable, ClassTimeTableDto>().ReverseMap();
            //CreateMap<ClassTimeTableDto, ClassTimeTable>().ForMember(src => src.ClassTimeTableId, opt => opt.Ignore()).ReverseMap();


            //FollowUpNoteBook
            //CreateMap<FollowUpNoteBook, FollowUpNoteBookDto>().ReverseMap();
            //CreateMap<FollowUpNoteBookDto, FollowUpNoteBook>().ForMember(src => src.FollowUpNoteBookId, opt => opt.Ignore()).ReverseMap();








        }
    }
}
