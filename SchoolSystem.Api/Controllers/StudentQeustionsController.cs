using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DAL.UnitOfWork;
using SchoolSystem.BLL.DTOs;
using SchoolSystem.DAL.Entites;
using SchoolSystem.DAL.Models;
using AutoMapper;

namespace SchoolSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentQeustionsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public StudentQeustionsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var studentQeustions = await _unitOfWork.StudentQeustions.GetAllAsync();
                var studentQeustionsDTO = _mapper.Map<IEnumerable<StudentQeustionDto>>(studentQeustions);
                ApiResponse6<IEnumerable<StudentQeustionDto>> response = new(studentQeustionsDTO);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 reaponse = new(message: ex.Message);
                return Ok(reaponse);
            }
        }

        // creat a method to get StudentQeustion by id using StudentQeustionDto , automapper , Try Catch block and Responses classes
        [HttpGet("{id}", Name = "GetStudentQeustion")]

        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var rtudentQeustion = await _unitOfWork.StudentQeustions.GetByIdAsync(id);
                if (rtudentQeustion == null)
                {
                    ApiResponse3 reaponse = new();
                    return NotFound(reaponse);
                }
                var studentQeustionDto = _mapper.Map<StudentQeustionDto>(rtudentQeustion);
                ApiResponse6<StudentQeustionDto> response = new(studentQeustionDto);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 response = new ApiResponse4(message: ex.Message);
                return StatusCode(500, response);
            }
        }

        // creat a method to create StudentQeustion using StudentQeustionDto , automapper , Try Catch block , Responses classes check if the object is null and if the model is valid and other nessesary checks
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] StudentQeustionDto studentQeustionDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ApiResponse2 response2 = new();
                    return BadRequest(response2);
                }
                if (studentQeustionDto == null)
                {
                    ApiResponse2 response1 = new();
                    return BadRequest(response1);
                }
                var classsubject = await _unitOfWork.SubjectClasses.GetByIdAsync(studentQeustionDto.SubjectClassId);
                if (classsubject == null)
                {
                    ApiResponse2 response3 = new();
                    return BadRequest(response3);
                }
                var studentQeustion = _mapper.Map<StudentQeustion>(studentQeustionDto);
                await _unitOfWork.StudentQeustions.AddAsync(studentQeustion);
                await _unitOfWork.SaveAsync();
                ApiResponse5<StudentQeustionDto> response = new(studentQeustionDto);
                return Ok(response);
                //return CreatedAtRoute("GetStudentQeustion", new { id = StudentQeustion.Id }, StudentQeustion);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 response = new(message: ex.Message);
                return StatusCode(500, response);
            }
        }

        // creat a method to update StudentQeustion using StudentQeustionDto , automapper , Try Catch block , Responses classes check if the object is null and if the model is valid and other nessesary checks
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] StudentQeustionDto studentQeustionDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ApiResponse2 response2 = new();
                    return BadRequest(response2);
                }
                if (studentQeustionDto == null)
                {
                    ApiResponse2 response1 = new();
                    return BadRequest(response1);
                }
                var studentQeustion = await _unitOfWork.StudentQeustions.GetByIdAsync(id);
                if (studentQeustion == null)
                {
                    ApiResponse3 response3 = new();
                    return NotFound(response3);
                }
                _mapper.Map(studentQeustionDto, studentQeustion);
                //var StudentQeustionupdated = _mapper.Map<StudentQeustion>(studentQeustionDto);
                //_unitOfWork.StudentQeustions.Update(StudentQeustionupdated);
                await _unitOfWork.SaveAsync();
                ApiResponse5<StudentQeustionDto> response = new(studentQeustionDto);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 response = new(message: ex.Message);
                return StatusCode(500, response);
            }
        }

        // creat a method to delete StudentQeustion using StudentQeustionDto , automapper , Try Catch block , Responses classes check if the object is null and if the model is valid and other nessesary checks
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var studentQeustion = await _unitOfWork.StudentQeustions.GetByIdAsync(id);
                if (studentQeustion == null)
                {
                    ApiResponse3 response1 = new();
                    return NotFound(response1);
                }
                _unitOfWork.StudentQeustions.Delete(studentQeustion);
                await _unitOfWork.SaveAsync();
                var studentQeustionDto = _mapper.Map<StudentQeustionDto>(studentQeustion);
                ApiResponse6<StudentQeustionDto> response = new(studentQeustionDto);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 response = new(message: ex.Message);
                return StatusCode(500, response);
            }
        }
    }
}
