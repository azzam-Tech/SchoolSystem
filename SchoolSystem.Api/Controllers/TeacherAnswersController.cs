using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DAL.Entites;
using SchoolSystem.DAL.Models;
using AutoMapper;
using System;
using SchoolSystem.BLL.DTOs.GetDto;
using SchoolSystem.BLL.DTOs.PostDto;
using SchoolSystem.DAL.UnitOfWork;
using SchoolSystem.BLL.DTOs;

namespace SchoolSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherAnswersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public TeacherAnswersController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //[HttpGet("GetAllByQuestionIdAsync/{questionid}")]
        //public async Task<IActionResult> GetAllByQuestionIdAsync(int questionid)
        //{
        //    try
        //    {
        //        var teacherAnswersFDB = await _unitOfWork.TeacherAnswers.GetByTeacherIdAsync(questionid);
        //        var teacherAnswerDTO = _mapper.Map<GetTeacherAnswerDto>(teacherAnswersFDB);
        //        ApiResponse6<GetTeacherAnswerDto> response = new(teacherAnswerDTO);
        //        return Ok(response);
        //    }
        //    catch (System.Exception ex)
        //    {
        //        ApiResponse4 reaponse = new(message: ex.Message);
        //        return Ok(reaponse);
        //    }
        //}

        [HttpPost("create")]
        public async Task<IActionResult> Post([FromBody] PostTeacherAnswerDto postTeacherAnswerDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ApiResponse2 response2 = new();
                    return BadRequest(response2);
                }
                if (postTeacherAnswerDto == null)
                {
                    ApiResponse2 response1 = new();
                    return BadRequest(response1);
                }
                var studentQeustions = await _unitOfWork.StudentQeustions.GetByIdAsync(postTeacherAnswerDto.StudentQeustionId);
                if (studentQeustions == null)
                {
                    ApiResponse2 response3 = new();
                    return BadRequest(response3);
                }
                var teacherAnswerTDB = _mapper.Map<TeacherAnswer>(postTeacherAnswerDto);
                await _unitOfWork.TeacherAnswers.AddAsync(teacherAnswerTDB);
                await _unitOfWork.SaveAsync();
                ApiResponse5<PostTeacherAnswerDto> response = new(postTeacherAnswerDto);
                return Ok(response);
                //return CreatedAtRoute("GetHomeWork", new { id = followUpNoteBook.Id }, followUpNoteBook);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 response = new(message: ex.Message);
                return StatusCode(500, response);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var teacherAnswerFDB = await _unitOfWork.TeacherAnswers.GetByIdAsync(id);
                if (teacherAnswerFDB == null)
                {
                    ApiResponse3 response1 = new();
                    return NotFound(response1);
                }
                _unitOfWork.TeacherAnswers.Delete(teacherAnswerFDB);
                await _unitOfWork.SaveAsync();
                var teacherAnswerDto = _mapper.Map<PostTeacherAnswerDto>(teacherAnswerFDB);
                ApiResponse6<PostTeacherAnswerDto> response = new(teacherAnswerDto);
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
