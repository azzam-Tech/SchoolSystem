using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DAL.Entites;
using SchoolSystem.DAL.Models;
using AutoMapper;
using System;
using SchoolSystem.BLL.DTOs.GetDto;
using SchoolSystem.BLL.DTOs.PostDto;
using SchoolSystem.DAL.UnitOfWork;

namespace SchoolSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherAttendancesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public TeacherAttendancesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("GetAllByTeacherIdAsync/{teacherid}")]
        public async Task<IActionResult> GetAllByTeacherIdAsync(int teacherid)
        {
            try
            {
                var teacherAttendancesFDB = await _unitOfWork.TeacherAttendances.GetAllByTeacherIdAsync(teacherid);
                var teacherEvaluationsDTO = _mapper.Map<IEnumerable<GetTeacherAttendanceDto>>(teacherAttendancesFDB);
                ApiResponse6<IEnumerable<GetTeacherAttendanceDto>> response = new(teacherEvaluationsDTO);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 reaponse = new(message: ex.Message);
                return Ok(reaponse);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostTeacherAttendanceDto postTeacherAttendanceDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ApiResponse2 response2 = new();
                    return BadRequest(response2);
                }
                if (postTeacherAttendanceDto == null)
                {
                    ApiResponse2 response1 = new();
                    return BadRequest(response1);
                }
                var user = await _unitOfWork.Users.GetByIdAsync(postTeacherAttendanceDto.UserId);
                if (user == null)
                {
                    ApiResponse2 response3 = new();
                    return BadRequest(response3);
                }
                var teacherAttendanceTDB = _mapper.Map<TeacherAttendance>(postTeacherAttendanceDto);
                await _unitOfWork.TeacherAttendances.AddAsync(teacherAttendanceTDB);
                await _unitOfWork.SaveAsync();
                ApiResponse5<PostTeacherAttendanceDto> response = new(postTeacherAttendanceDto);
                return Ok(response);
                //return CreatedAtRoute("GetHomeWork", new { id = followUpNoteBook.Id }, followUpNoteBook);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 response = new(message: ex.Message);
                return StatusCode(500, response);
            }
        }

    }
}
