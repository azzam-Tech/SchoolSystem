﻿using Microsoft.AspNetCore.Http;
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
    public class SolutionsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public SolutionsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var solutions = await _unitOfWork.Solutions.GetAllAsync();
                var solutionsDTO = _mapper.Map<IEnumerable<SolutionDto>>(solutions);
                ApiResponse6<IEnumerable<SolutionDto>> response = new(solutionsDTO);
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
                var Solution = await _unitOfWork.Solutions.GetByIdAsync(id);
                if (Solution == null)
                {
                    ApiResponse3 reaponse = new();
                    return NotFound(reaponse);
                }
                var SolutionDto = _mapper.Map<SolutionDto>(Solution);
                ApiResponse6<SolutionDto> response = new(SolutionDto);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 response = new ApiResponse4(message: ex.Message);
                return StatusCode(500, response);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SolutionDto solutionDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ApiResponse2 response2 = new();
                    return BadRequest(response2);
                }
                if (solutionDto == null)
                {
                    ApiResponse2 response1 = new();
                    return BadRequest(response1);
                }
                var homework = await _unitOfWork.HomeWorks.GetByIdAsync(solutionDto.HomeWorkId);
                if (homework == null)
                {
                    ApiResponse2 response3 = new();
                    return BadRequest(response3);
                }
                var solution = _mapper.Map<Solution>(solutionDto);
                await _unitOfWork.Solutions.AddAsync(solution);
                await _unitOfWork.SaveAsync();
                ApiResponse5<SolutionDto> response = new(solutionDto);
                return Ok(response);
                //return CreatedAtRoute("GetHomeWork", new { id = homeWork.Id }, homeWork);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 response = new(message: ex.Message);
                return StatusCode(500, response);
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] SolutionDto solutionDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ApiResponse2 response2 = new();
                    return BadRequest(response2);
                }
                if (solutionDto == null)
                {
                    ApiResponse2 response1 = new();
                    return BadRequest(response1);
                }
                var solution = await _unitOfWork.Solutions.GetByIdAsync(id);
                if (solution == null)
                {
                    ApiResponse3 response3 = new();
                    return NotFound(response3);
                }
                _mapper.Map(solutionDto, solution);
                //_unitOfWork.Solutions.Update(solution);
                await _unitOfWork.SaveAsync();
                ApiResponse5<SolutionDto> response = new(solutionDto);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 response = new(message: ex.Message);
                return StatusCode(500, response);
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var solution = await _unitOfWork.Solutions.GetByIdAsync(id);
                if (solution == null)
                {
                    ApiResponse3 response3 = new();
                    return NotFound(response3);
                }
                _unitOfWork.Solutions.Delete(solution);
                await _unitOfWork.SaveAsync();
                var solutionDto = _mapper.Map<SolutionDto>(solution);
                ApiResponse6<SolutionDto> response = new(solutionDto);
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