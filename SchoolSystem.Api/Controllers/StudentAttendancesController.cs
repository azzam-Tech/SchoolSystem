using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.BLL.DTOs;
using SchoolSystem.DAL.Entites;
using SchoolSystem.DAL.Models;
using AutoMapper;
using SchoolSystem.DAL.UnitOfWork;
using SchoolSystem.BLL.DTOs.GetDto;
using SchoolSystem.BLL.DTOs.PostDto;
using SchoolSystem.BLL.DTOs.EditDto;
using SchoolSystem.Api.FileServices;

namespace SchoolSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAttendancesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public StudentAttendancesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost("create")]
        public async Task<IActionResult> tend([FromBody] List<PostStudentAttendanceDto> postStudentAttendanceDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ApiResponse2 response2 = new();
                    return BadRequest(response2);
                }
                if (postStudentAttendanceDto == null)
                {
                    ApiResponse2 response1 = new();
                    return BadRequest(response1);
                }
                //var user = await _unitOfWork.Users.GetByIdAsync(postTeacherAttendanceDto.UserId);
                //if (user == null)
                //{
                //    ApiResponse2 response3 = new();
                //    return BadRequest(response3);
                //}
                var studentAttendanceTDB = _mapper.Map<List<StudentAttendance>>(postStudentAttendanceDto);
                await _unitOfWork.StudentAttendances.AddRangeAsync(studentAttendanceTDB);
                await _unitOfWork.SaveAsync();
                ApiResponse5<List<PostStudentAttendanceDto>> response = new(postStudentAttendanceDto);
                return Ok(response);
                //return CreatedAtRoute("GetHomeWork", new { id = followUpNoteBook.Id }, followUpNoteBook);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 response = new(message: ex.Message);
                return StatusCode(500, response);
            }
        }
        //create a method to get all StudentAttendance using GetAllAsync method from StudentAttendanceRepository
        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var studentAttendancesFDB = await _unitOfWork.StudentAttendances.GetAllAsync();
                var studentAttendancesDTO = _mapper.Map<IEnumerable<GetStudentAttendanceDto>>(studentAttendancesFDB);
                ApiResponse6<IEnumerable<GetStudentAttendanceDto>> response = new(studentAttendancesDTO);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 reaponse = new(message: ex.Message);
                return Ok(reaponse);
            }
        }

        [HttpGet("GetAllBySoneIdAsync/{soneid}")]
        public async Task<IActionResult> GetAllByTeacherIdAsync(int soneid)
        {
            try
            {
                var studentAttendancesFDB = await _unitOfWork.StudentAttendances.GetAllBySoneIdAsync(soneid);
                var studentAttendancesDTO = _mapper.Map<IEnumerable<GetStudentAttendanceDto>>(studentAttendancesFDB);
                ApiResponse6<IEnumerable<GetStudentAttendanceDto>> response = new(studentAttendancesDTO);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 reaponse = new(message: ex.Message);
                return Ok(reaponse);
            }
        }


    }
}
