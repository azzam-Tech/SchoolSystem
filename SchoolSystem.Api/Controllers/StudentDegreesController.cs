using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DAL.UnitOfWork;
using SchoolSystem.BLL.DTOs;
using SchoolSystem.BLL.DTOs.GetDto;
using SchoolSystem.DAL.Entites;
using SchoolSystem.DAL.Models;
using AutoMapper;

namespace SchoolSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentDegreesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public StudentDegreesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var studentDegrees = await _unitOfWork.StudentDegrees.GetAllAsync();
                var studentDegreesDTO = _mapper.Map<IEnumerable<GetStudentDegreeDto>>(studentDegrees);
                ApiResponse6<IEnumerable<GetStudentDegreeDto>> response = new(studentDegreesDTO);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 reaponse = new(message: ex.Message);
                return Ok(reaponse);
            }
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var studentDegree = await _unitOfWork.StudentDegrees.GetByIdAsync(id);
                if (studentDegree == null)
                {
                    ApiResponse3 reaponse = new();
                    return NotFound(reaponse);
                }
                var studentDegreeDto = _mapper.Map<GetStudentDegreeDto>(studentDegree);
                ApiResponse6<GetStudentDegreeDto> response = new(studentDegreeDto);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 response = new ApiResponse4(message: ex.Message);
                return StatusCode(500, response);
            }
        }

        [HttpGet("GetByStudentId/{id}")]
        public async Task<IActionResult> GetGetByStudentIdById(int id)
        {
            try
            {
                var studentDegree = await _unitOfWork.StudentDegrees.GetStudentDegreesByStudentId(id);
                if (studentDegree == null)
                {
                    ApiResponse3 reaponse = new();
                    return NotFound(reaponse);
                }
                List<GetStudentDegreeDto> studentDegreeDto = new List<GetStudentDegreeDto>(); 
                foreach (var item in studentDegree)
                {
                    studentDegreeDto.Add(new GetStudentDegreeDto
                    {
                        SubjectClassId = item.SubjectClassId,
                        DegreeTypeId = item.DegreeTypeId,
                        StudentDegreeValue = item.StudentDegreeValue,
                    });
                }
                ApiResponse6<IEnumerable<GetStudentDegreeDto>> response = new(studentDegreeDto);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 response = new ApiResponse4(message: ex.Message);
                return StatusCode(500, response);
            }
        }


    }
}
