using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DAL.UnitOfWork;
using SchoolSystem.BLL.DTOs;
using SchoolSystem.DAL.Entites;
using SchoolSystem.DAL.Models;
using AutoMapper;
using System;

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

        [HttpGet]

        public async Task<IActionResult> GeLLAsync()
        {
            try
            {
                var followUpNoteBooks = await _unitOfWork.FollowUpNoteBooks.GetAllAsync();
                //var followUpNoteBooksDTO = _mapper.Map<FollowUpNoteBookDto>(followUpNoteBooks);
                //ApiResponse6<FollowUpNoteBookDto> response = new(followUpNoteBooksDTO);
                return Ok(followUpNoteBooks);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 response = new ApiResponse4(message: ex.Message);
                return StatusCode(500, response);
            }
        }

        [HttpGet("GetByDateClassAsync/{id}/{datetime}")]

        public async Task<IActionResult> GetByDateClassAsync(int id, DateTime datetime)
        {
            try
            {
                var followUpNoteBooks = await _unitOfWork.FollowUpNoteBooks.GetByDateClassAsync(id, datetime);
                if (followUpNoteBooks == null || followUpNoteBooks.Count() == 0)
                {
                    ApiResponse3 reaponse = new();
                    return NotFound(reaponse);
                }
                var followUpNoteBooksDTO = _mapper.Map<IEnumerable< FollowUpNoteBookDto>>(followUpNoteBooks);
                ApiResponse6<IEnumerable<FollowUpNoteBookDto>> response = new(followUpNoteBooksDTO);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 response = new ApiResponse4(message: ex.Message);
                return StatusCode(500, response);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FollowUpNoteBookDto followUpNoteBookDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ApiResponse2 response2 = new();
                    return BadRequest(response2);
                }
                if (followUpNoteBookDto == null)
                {
                    ApiResponse2 response1 = new();
                    return BadRequest(response1);
                }
                var classsubject = await _unitOfWork.SubjectClasses.GetByIdAsync(followUpNoteBookDto.SubjectClassId);
                if (classsubject == null)
                {
                    ApiResponse2 response3 = new();
                    return BadRequest(response3);
                }
                var followUpNoteBook = _mapper.Map<FollowUpNoteBook>(followUpNoteBookDto);
                await _unitOfWork.FollowUpNoteBooks.AddAsync(followUpNoteBook);
                await _unitOfWork.SaveAsync();
                ApiResponse5<FollowUpNoteBookDto> response = new(followUpNoteBookDto);
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
