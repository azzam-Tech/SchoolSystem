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

namespace SchoolSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReinforcementlessonsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ReinforcementlessonsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //[HttpGet]
        //public async Task<IActionResult> Get()
        //{
        //    try
        //    {
        //        var Reinforcementlessons = await _unitOfWork.Reinforcementlessons.GetAllAsync();
        //        var ReinforcementlessonsDTO = _mapper.Map<IEnumerable<GetReinforcementlessonDto>>(Reinforcementlessons);
        //        ApiResponse6<IEnumerable<GetReinforcementlessonDto>> response = new(ReinforcementlessonsDTO);
        //        return Ok(response);
        //    }
        //    catch (System.Exception ex)
        //    {
        //        ApiResponse4 reaponse = new(message: ex.Message);
        //        return Ok(reaponse);
        //    }
        //}

        // creat a method to get reinforcementlessonby id using ReinforcementlessonDto , automapper , Try Catch block and Responses classes
        [HttpGet("GetBySubjectClassId/{id}")]

        public async Task<IActionResult> GetBySubjectClassId(int id)
        {
            try
            {
                var reinforcementlesson= await _unitOfWork.Reinforcementlessons.GetBySubjectClassId(id);
                if (reinforcementlesson== null || reinforcementlesson.Count() == 0)
                {
                    ApiResponse3 reaponse = new();
                    return NotFound(reaponse);
                }
                var ReinforcementlessonDto = _mapper.Map<IEnumerable<GetReinforcementlessonDto>>(reinforcementlesson);
                ApiResponse6< IEnumerable<GetReinforcementlessonDto>> response = new(ReinforcementlessonDto);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 response = new ApiResponse4(message: ex.Message);
                return StatusCode(500, response);
            }
        }

        // creat a method to create reinforcementlessonusing ReinforcementlessonDto , automapper , Try Catch block , Responses classes check if the object is null and if the model is valid and other nessesary checks
        [HttpPost("Create")]
        public async Task<IActionResult> Post([FromBody] PostReinforcementlessonDto ReinforcementlessonDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ApiResponse2 response2 = new();
                    return BadRequest(response2);
                }
                if (ReinforcementlessonDto == null)
                {
                    ApiResponse2 response1 = new();
                    return BadRequest(response1);
                }
                var classsubject = await _unitOfWork.SubjectClasses.GetByIdAsync(ReinforcementlessonDto.SubjectClassId);
                if (classsubject == null)
                {
                    ApiResponse2 response3 = new();
                    return BadRequest(response3);
                }
                var reinforcementlesson= _mapper.Map<Reinforcementlesson>(ReinforcementlessonDto);
                await _unitOfWork.Reinforcementlessons.AddAsync(reinforcementlesson);
                await _unitOfWork.SaveAsync();
                ApiResponse5<PostReinforcementlessonDto> response = new(ReinforcementlessonDto);
                return Ok(response);
                //return CreatedAtRoute("GetHomeWork", new { id = homeWork.Id }, homeWork);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 response = new(message: ex.Message);
                return StatusCode(500, response);
            }
        }

        // creat a method to update reinforcementlessonusing ReinforcementlessonDto , automapper , Try Catch block , Responses classes check if the object is null and if the model is valid and other nessesary checks
        [HttpPut("Edit/{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EditReinforcementlessonDto ReinforcementlessonDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ApiResponse2 response2 = new();
                    return BadRequest(response2);
                }
                if (ReinforcementlessonDto == null)
                {
                    ApiResponse2 response1 = new();
                    return BadRequest(response1);
                }
                var reinforcementlesson= await _unitOfWork.Reinforcementlessons.GetByIdAsync(id);
                if (reinforcementlesson== null)
                {
                    ApiResponse3 response3 = new();
                    return NotFound(response3);
                }
                _mapper.Map(ReinforcementlessonDto, reinforcementlesson);
                await _unitOfWork.SaveAsync();
                ApiResponse5<EditReinforcementlessonDto> response = new(ReinforcementlessonDto);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 response = new(message: ex.Message);
                return StatusCode(500, response);
            }
        }

        // creat a method to delete reinforcementlessonusing ReinforcementlessonDto , automapper , Try Catch block , Responses classes check if the object is null and if the model is valid and other nessesary checks
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var reinforcementlesson= await _unitOfWork.Reinforcementlessons.GetByIdAsync(id);
                if (reinforcementlesson== null)
                {
                    ApiResponse3 response1 = new();
                    return NotFound(response1);
                }
                _unitOfWork.Reinforcementlessons.Delete(reinforcementlesson);
                await _unitOfWork.SaveAsync();
                var ReinforcementlessonDto = _mapper.Map<GetReinforcementlessonDto>(reinforcementlesson);
                ApiResponse6<GetReinforcementlessonDto> response = new(ReinforcementlessonDto);
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
