using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.BLL.DTOs.Students;
using SchoolSystem.DAL.Entites;
using SchoolSystem.DAL.Models;
using SchoolSystem.DAL.UnitOfWork;

namespace SchoolSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public StudentsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetALL()
        {
            try
            {
                IEnumerable<Student> studentsfDB = _unitOfWork.Students.GetAll();

                IEnumerable<StudentDto> studentDtos = new List<StudentDto>();
                //IEnumerable<StudentDto> studentDtos = [];

                foreach (Student student in studentsfDB)
                {
                    StudentDto studentDto = new StudentDto
                    {
                        UserId = student.StudentId,
                        StedentParent = student.StudentId,
                        ClassId = student.ClassId,
                    };
                }

                Response<IEnumerable<StudentDto>> response = new(studentDtos);

                return Ok(response);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                string message = ex.Message;
                Response<IEnumerable<StudentDto>> response = new(null,message ,error);
                
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("addRange")]
        public IActionResult Post([FromBody] IEnumerable<StudentDto> studentsDto )
        {
            try
            {
                //IEnumerable<Student> studentsfDB = _unitOfWork.Students.Add();

                List<Student> students = new List<Student>();
                //IEnumerable<StudentDto> studentDtos = [];

                foreach (StudentDto studentDto in studentsDto)
                {
                    Student student = new Student
                    {
                        UserId = studentDto.UserId,
                        StedentParent = studentDto.StedentParent,
                        ClassId = studentDto.ClassId,
                    };
                    students.Add(student);
                }
                _unitOfWork.Students.AddRange(students);
                _unitOfWork.Complete();

                Response<IEnumerable<Student>> response = new(students);

                return Ok(response);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                string message = ex.Message;
                Response<IEnumerable<Student>> response = new(null, message, error);

                return BadRequest(ex.Message);
            }
        }
    }
}
