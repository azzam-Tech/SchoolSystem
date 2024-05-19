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
    public class ClassTimeTablesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ClassTimeTablesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var classTimeTables = await _unitOfWork.ClassTimeTables.GetAllAsync();
                var classTimeTablesDTO = _mapper.Map<IEnumerable<ClassTimeTableDto>>(classTimeTables);
                ApiResponse6<IEnumerable<ClassTimeTableDto>> response = new(classTimeTablesDTO);
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
                var classTimeTable = await _unitOfWork.ClassTimeTables.GetByIdAsync(id);
                if (classTimeTable == null)
                {
                    ApiResponse3 reaponse = new();
                    return NotFound(reaponse);
                }
                var classTimeTableDto = _mapper.Map<ClassTimeTableDto>(classTimeTable);
                ApiResponse6<ClassTimeTableDto> response = new(classTimeTableDto);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 response = new ApiResponse4(message: ex.Message);
                return StatusCode(500, response);
            }
        }

        [HttpGet("GetByClassId/{id}")]
        public async Task<IActionResult> GetByClassId(int id)
        {
            try
            {
                var classTimeTable = await _unitOfWork.ClassTimeTables.GetByIdAsync(id);
                if (classTimeTable == null)
                {
                    ApiResponse3 reaponse = new();
                    return NotFound(reaponse);
                }
                var classTimeTableDto = _mapper.Map<ClassTimeTableDto>(classTimeTable);
                ApiResponse6<ClassTimeTableDto> response = new(classTimeTableDto);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 response = new ApiResponse4(message: ex.Message);
                return StatusCode(500, response);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClassTimeTableDto classTimeTableDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ApiResponse2 response2 = new();
                    return BadRequest(response2);
                }
                if (classTimeTableDto == null)
                {
                    ApiResponse2 response1 = new();
                    return BadRequest(response1);
                }

                var Class = await _unitOfWork.Classes.GetByIdAsync(classTimeTableDto.ClassId);
                if (Class == null)
                {
                    ApiResponse2 response3 = new();
                    return BadRequest(response3);
                }

                var classTimeTable = _mapper.Map<ClassTimeTable>(classTimeTableDto);
                await _unitOfWork.ClassTimeTables.AddAsync(classTimeTable);
                await _unitOfWork.SaveAsync();
                ApiResponse6<ClassTimeTableDto> response = new(_mapper.Map<ClassTimeTableDto>(classTimeTable));
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 response = new ApiResponse4(message: ex.Message);
                return StatusCode(500, response);
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ClassTimeTableDto classTimeTableDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ApiResponse2 response2 = new();
                    return BadRequest(response2);
                }
                if (classTimeTableDto == null)
                {
                    ApiResponse2 response1 = new();
                    return BadRequest(response1);
                }
                var classTimeTable = await _unitOfWork.ClassTimeTables.GetByIdAsync(id);
                if (classTimeTable == null)
                {
                    ApiResponse3 response3 = new();
                    return NotFound(response3);
                }
                _mapper.Map(classTimeTableDto, classTimeTable);
                //_unitOfWork.Solutions.Update(solution);
                await _unitOfWork.SaveAsync();
                ApiResponse5<ClassTimeTableDto> response = new(classTimeTableDto);
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
                var classTimeTable = await _unitOfWork.ClassTimeTables.GetByIdAsync(id);
                if (classTimeTable == null)
                {
                    ApiResponse3 response3 = new();
                    return NotFound(response3);
                }
                _unitOfWork.ClassTimeTables.Delete(classTimeTable);
                await _unitOfWork.SaveAsync();
                var classTimeTableDto = _mapper.Map<ClassTimeTableDto>(classTimeTable);
                ApiResponse6<ClassTimeTableDto> response = new(classTimeTableDto);
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