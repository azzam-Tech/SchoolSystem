using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.BLL.DTOs;
using SchoolSystem.DAL.Entites;
using SchoolSystem.DAL.Models;
using AutoMapper;
using SchoolSystem.DAL.UnitOfWork;

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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var Reinforcementlessons = await _unitOfWork.Reinforcementlessons.GetAllAsync();
                var ReinforcementlessonsDTO = _mapper.Map<IEnumerable<ReinforcementlessonDto>>(Reinforcementlessons);
                ApiResponse6<IEnumerable<ReinforcementlessonDto>> response = new(ReinforcementlessonsDTO);
                return Ok(ReinforcementlessonsDTO);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 reaponse = new(message: ex.Message);
                return Ok(reaponse);
            }
        }

        // creat a method to get reinforcementlessonby id using ReinforcementlessonDto , automapper , Try Catch block and Responses classes
        [HttpGet("{id}", Name = "GetHomeWork")]

        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var reinforcementlesson= await _unitOfWork.Reinforcementlessons.GetByIdAsync(id);
                if (reinforcementlesson== null)
                {
                    ApiResponse3 reaponse = new();
                    return NotFound(reaponse);
                }
                var ReinforcementlessonDto = _mapper.Map<ReinforcementlessonDto>(reinforcementlesson);
                ApiResponse6<ReinforcementlessonDto> response = new(ReinforcementlessonDto);
                return Ok(ReinforcementlessonDto);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 response = new ApiResponse4(message: ex.Message);
                return StatusCode(500, response);
            }
        }

        // creat a method to create reinforcementlessonusing ReinforcementlessonDto , automapper , Try Catch block , Responses classes check if the object is null and if the model is valid and other nessesary checks
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ReinforcementlessonDto ReinforcementlessonDto)
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
                ApiResponse5<ReinforcementlessonDto> response = new(ReinforcementlessonDto);
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
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ReinforcementlessonDto ReinforcementlessonDto)
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
                var homeWorkupdated = _mapper.Map<HomeWork>(ReinforcementlessonDto);
                //_unitOfWork.Reinforcementlessons.Update(homeWorkupdated);
                await _unitOfWork.SaveAsync();
                ApiResponse5<ReinforcementlessonDto> response = new(ReinforcementlessonDto);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 response = new(message: ex.Message);
                return StatusCode(500, response);
            }
        }

        // creat a method to delete reinforcementlessonusing ReinforcementlessonDto , automapper , Try Catch block , Responses classes check if the object is null and if the model is valid and other nessesary checks
        [HttpDelete("{id}")]
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
                var ReinforcementlessonDto = _mapper.Map<ReinforcementlessonDto>(reinforcementlesson);
                ApiResponse6<ReinforcementlessonDto> response = new(ReinforcementlessonDto);
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
