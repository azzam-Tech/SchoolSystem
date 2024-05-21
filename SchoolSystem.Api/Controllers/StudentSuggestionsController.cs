using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DAL.UnitOfWork;
using SchoolSystem.BLL.DTOs;
using SchoolSystem.DAL.Entites;
using SchoolSystem.DAL.Models;
using AutoMapper;
using SchoolSystem.BLL.DTOs.GetDto;
using SchoolSystem.BLL.DTOs.PostDto;
using SchoolSystem.BLL.DTOs.EditDto;

namespace SchoolSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentSuggestionsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public StudentSuggestionsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("GetByClassIdAsync/{id}")]

        public async Task<IActionResult> GetByClassIdAsync(int id)
        {
            try
            {
                var studentSuggestionsFDB = await _unitOfWork.StudentSuggestions.GetByClassIdAsync(id);
                if (studentSuggestionsFDB == null)
                {
                    ApiResponse3 reaponse = new();
                    return NotFound(reaponse);
                }
                var studentSuggestionsDto = _mapper.Map<IEnumerable<GetStudentSuggestionDto>>(studentSuggestionsFDB);
                ApiResponse6<IEnumerable<GetStudentSuggestionDto>> response = new(studentSuggestionsDto);
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
        public async Task<IActionResult> Post([FromBody] PostStudentSuggestionDto studentSuggestionDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ApiResponse2 response2 = new();
                    return BadRequest(response2);
                }
                if (studentSuggestionDto == null)
                {
                    ApiResponse2 response1 = new();
                    return BadRequest(response1);
                }
                var Class = await _unitOfWork.Classes.GetByIdAsync(studentSuggestionDto.ClassId);
                if (Class == null)
                {
                    ApiResponse2 response3 = new();
                    return BadRequest(response3);
                }
                var studentQeustionTDB = _mapper.Map<StudentSuggestion>(studentSuggestionDto);
                await _unitOfWork.StudentSuggestions.AddAsync(studentQeustionTDB);
                await _unitOfWork.SaveAsync();
                ApiResponse5<PostStudentSuggestionDto> response = new(studentSuggestionDto);
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
        public async Task<IActionResult> Put(int id, [FromBody] EditStudentSuggestionDto studentSuggestionDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ApiResponse2 response2 = new();
                    return BadRequest(response2);
                }
                if (studentSuggestionDto == null)
                {
                    ApiResponse2 response1 = new();
                    return BadRequest(response1);
                }
                var studentSuggestion = await _unitOfWork.StudentSuggestions.GetByIdAsync(id);
                if (studentSuggestion == null)
                {
                    ApiResponse3 response3 = new();
                    return NotFound(response3);
                }
                _mapper.Map(studentSuggestionDto, studentSuggestion);
                await _unitOfWork.SaveAsync();
                ApiResponse5<EditStudentSuggestionDto> response = new(studentSuggestionDto);
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
                var studentSuggestionsFDB = await _unitOfWork.StudentSuggestions.GetByIdAsync(id);
                if (studentSuggestionsFDB == null)
                {
                    ApiResponse3 response1 = new();
                    return NotFound(response1);
                }
                _unitOfWork.StudentSuggestions.Delete(studentSuggestionsFDB);
                await _unitOfWork.SaveAsync();
                var studentSuggestionDto = _mapper.Map<GetStudentSuggestionDto>(studentSuggestionsFDB);
                ApiResponse6<GetStudentSuggestionDto> response = new(studentSuggestionDto);
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
