using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DAL.UnitOfWork;
using SchoolSystem.BLL.DTOs;
using SchoolSystem.DAL.Entites;
using SchoolSystem.DAL.Models;
using AutoMapper;
using System;
using SchoolSystem.BLL.DTOs.GetDto;
using SchoolSystem.BLL.DTOs.PostDto;

namespace SchoolSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FollowUpNoteBooksController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public FollowUpNoteBooksController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //[HttpGet]

        //public async Task<IActionResult> GeLLAsync()
        //{
        //    try
        //    {
        //        var followUpNoteBooks = await _unitOfWork.FollowUpNoteBooks.GetAllAsync();
        //        //var getfollowUpNoteBooksDTO = _mapper.Map<FollowUpNoteBookDto>(followUpNoteBooks);
        //        //ApiResponse6<FollowUpNoteBookDto> response = new(getfollowUpNoteBooksDTO);
        //        return Ok(followUpNoteBooks);
        //    }
        //    catch (System.Exception ex)
        //    {
        //        ApiResponse4 response = new ApiResponse4(message: ex.Message);
        //        return StatusCode(500, response);
        //    }
        //}

        [HttpGet("GetByDateClassAsync/{id}/{date}")]

        public async Task<IActionResult> GetByDateClassAsync(int id, DateOnly date)
        {
            try
            {
                var followUpNoteBooks = await _unitOfWork.FollowUpNoteBooks.GetByDateClassAsync(id, date);
                if (followUpNoteBooks == null || followUpNoteBooks.Count() == 0)
                {
                    ApiResponse3 reaponse = new();
                    return NotFound(reaponse);
                }
                var getfollowUpNoteBooksDTO = _mapper.Map<IEnumerable< GetFollowUpNoteBookDto>>(followUpNoteBooks);
                ApiResponse6<IEnumerable<GetFollowUpNoteBookDto>> response = new(getfollowUpNoteBooksDTO);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 response = new ApiResponse4(message: ex.Message);
                return StatusCode(500, response);
            }
        }

        [HttpGet("GetByClassSubjectId/{id}")]

        public async Task<IActionResult> GetByClassSubjectId(int id)
        {
            try
            {
                var followUpNoteBooks = await _unitOfWork.FollowUpNoteBooks.GetByClassSubjectId(id);
                if (followUpNoteBooks == null || followUpNoteBooks.Count() == 0)
                {
                    ApiResponse3 reaponse = new();
                    return NotFound(reaponse);
                }
                var getfollowUpNoteBooksDTO = _mapper.Map<IEnumerable<GetFollowUpNoteBookDto>>(followUpNoteBooks);
                ApiResponse6<IEnumerable<GetFollowUpNoteBookDto>> response = new(getfollowUpNoteBooksDTO);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 response = new ApiResponse4(message: ex.Message);
                return StatusCode(500, response);
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Post([FromBody] PostFollowUpNoteBookDto postFollowUpNoteBookDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ApiResponse2 response2 = new();
                    return BadRequest(response2);
                }
                if (postFollowUpNoteBookDto == null)
                {
                    ApiResponse2 response1 = new();
                    return BadRequest(response1);
                }
                var classsubject = await _unitOfWork.SubjectClasses.GetByIdAsync(postFollowUpNoteBookDto.SubjectClassId);
                if (classsubject == null)
                {
                    ApiResponse2 response3 = new();
                    return BadRequest(response3);
                }
                var followUpNoteBook = _mapper.Map<FollowUpNoteBook>(postFollowUpNoteBookDto);
                await _unitOfWork.FollowUpNoteBooks.AddAsync(followUpNoteBook);
                await _unitOfWork.SaveAsync();
                ApiResponse5<PostFollowUpNoteBookDto> response = new(postFollowUpNoteBookDto);
                return Ok(response);
                //return CreatedAtRoute("GetHomeWork", new { id = followUpNoteBook.Id }, followUpNoteBook);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 response = new(message: ex.Message);
                return StatusCode(500, response);
            }
        }


        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var followUpNoteBook = await _unitOfWork.FollowUpNoteBooks.GetByIdAsync(id);
                if (followUpNoteBook == null)
                {
                    ApiResponse3 response1 = new();
                    return NotFound(response1);
                }
                _unitOfWork.FollowUpNoteBooks.Delete(followUpNoteBook);
                await _unitOfWork.SaveAsync();
                var getfollowUpNoteBookDto = _mapper.Map<GetFollowUpNoteBookDto>(followUpNoteBook);
                ApiResponse6<GetFollowUpNoteBookDto> response = new(getfollowUpNoteBookDto);
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
