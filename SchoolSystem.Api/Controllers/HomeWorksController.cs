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
using SchoolSystem.Api.FileServices;

namespace SchoolSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeWorksController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IManageFiles manageFiles;

        public HomeWorksController(IUnitOfWork unitOfWork, IMapper mapper , IManageFiles manageFiles)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            this.manageFiles = manageFiles;
        }
        // creat a method to get all HomeWorks using HomeWorkDTO , automapper , Try Catch block and Responses classes
        //[HttpGet]
        //public async Task <IActionResult> Get()
        //{
        //    try
        //    {
        //        var homeWorks = await _unitOfWork.HomeWorks.GetAllAsync();
        //        var homeWorksDTO = _mapper.Map<IEnumerable<GetHomeWorkDto>>(homeWorks);
        //        ApiResponse6<IEnumerable<GetHomeWorkDto>> response = new(homeWorksDTO);
        //        return Ok(response);
        //    }
        //    catch (System.Exception ex)
        //    {
        //        ApiResponse4 reaponse = new(message: ex.Message);
        //        return Ok(reaponse);
        //    }
        //}

        // creat a method to get HomeWork by id using HomeWorkDTO , automapper , Try Catch block and Responses classes
        //[HttpGet("{id}")]

        //public async Task<IActionResult> GetById(int id)
        //{
        //    try
        //    {
        //        var homeWork = await _unitOfWork.HomeWorks.GetByIdAsync(id);
        //        if (homeWork == null)
        //        {
        //            ApiResponse3 reaponse = new();
        //            return NotFound(reaponse);
        //        }
        //        var homeWorkDTO = _mapper.Map<GetHomeWorkDto>(homeWork);
        //        ApiResponse6<GetHomeWorkDto> response = new(homeWorkDTO);
        //        return Ok(response);
        //    }
        //    catch (System.Exception ex)
        //    {
        //        ApiResponse4 response = new ApiResponse4(message: ex.Message);
        //        return StatusCode(500, response);
        //    }
        //}

        [HttpGet("GetBySubjectClassId/{id}")]

        public async Task<IActionResult> GetBySubjectClassId(int id)
        {
            try
            {
                var homeWorks = await _unitOfWork.HomeWorks.GetBySubjectClassId(id);
                if (homeWorks == null || homeWorks.Count() ==0 )
                {
                    ApiResponse3 reaponse = new();
                    return NotFound(reaponse);
                }
                var homeWorksDTO = _mapper.Map<IEnumerable<GetHomeWorkDto>>(homeWorks);
                ApiResponse6<IEnumerable<GetHomeWorkDto>> response = new(homeWorksDTO);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 response = new ApiResponse4(message: ex.Message);
                return StatusCode(500, response);
            }
        }

         [HttpPost("Create")]
        public async Task<IActionResult> Post( [FromForm] PostHomeWorkDto homeWorkDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ApiResponse2 response2 = new();
                    return BadRequest(response2);
                }
                if (homeWorkDto == null)
                {
                    ApiResponse2 response1 = new();
                    return BadRequest(response1);
                }
                var classsubject = await _unitOfWork.SubjectClasses.GetByIdAsync(homeWorkDto.SubjectClassId);
                if (classsubject == null)
                {
                    ApiResponse2 response3 = new();
                    return BadRequest(response3);
                }

                var shema = $"{Request.Scheme}://";
                var host = $"{Request.Host}/";

                var imagePath1 = shema + host + await manageFiles.SaveImage(homeWorkDto.HomeWorkImagePath, "HomeWork");
                
                var imagePath = imagePath1.Replace("/wwwroot", "");




                var homeWork = _mapper.Map<HomeWork>(homeWorkDto);

                homeWork.HomeWorkImagePath = imagePath;

                await _unitOfWork.HomeWorks.AddAsync(homeWork);
                await _unitOfWork.SaveAsync();
                ApiResponse5<PostHomeWorkDto> response = new(homeWorkDto);
                return Ok(response);
                //return CreatedAtRoute("GetHomeWork", new { id = homeWork.Id }, homeWork);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 response = new(message: ex.Message);
                return StatusCode(500, response);
            }
        }

        [HttpPut("Edit/{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EditHomeWorkDto homeWorkDto)
        {
            try
            {                
                if (!ModelState.IsValid)
                {
                    ApiResponse2 response2 = new();
                    return BadRequest(response2);
                }
                if (homeWorkDto == null)
                {
                    ApiResponse2 response1 = new();
                    return BadRequest(response1);
                }
                var homeWork = await _unitOfWork.HomeWorks.GetByIdAsync(id);
                if (homeWork == null)
                {
                    ApiResponse3 response3 = new();
                    return NotFound(response3);
                }
                _mapper.Map(homeWorkDto, homeWork);
                //var homeWorkupdated = _mapper.Map<HomeWork>(homeWorkDto);
                //_unitOfWork.HomeWorks.Update(homeWorkupdated);
                await _unitOfWork.SaveAsync();
                ApiResponse5<EditHomeWorkDto> response = new(homeWorkDto);
                return Ok(response);
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
                var homeWork = await _unitOfWork.HomeWorks.GetByIdAsync(id);
                if (homeWork == null)
                {
                    ApiResponse3 response1 = new();
                    return NotFound(response1);
                }
                _unitOfWork.HomeWorks.Delete(homeWork);
                await _unitOfWork.SaveAsync();
                var homeWorkDto = _mapper.Map<HomeWorkDto>(homeWork);
                ApiResponse6<HomeWorkDto> response = new(homeWorkDto);
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
