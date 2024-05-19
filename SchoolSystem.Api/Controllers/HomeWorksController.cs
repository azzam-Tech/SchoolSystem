using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DAL.UnitOfWork;
using SchoolSystem.BLL.DTOs;
using SchoolSystem.DAL.Entites;
using SchoolSystem.DAL.Models;
using AutoMapper;
using SchoolSystem.BLL.DTOs.GetDto;
using SchoolSystem.BLL.DTOs.PostDto;

namespace SchoolSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeWorksController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public HomeWorksController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        // creat a method to get all HomeWorks using HomeWorkDTO , automapper , Try Catch block and Responses classes
        [HttpGet]
        public async Task <IActionResult> Get()
        {
            try
            {
                var homeWorks = await _unitOfWork.HomeWorks.GetAllAsync();
                var homeWorksDTO = _mapper.Map<IEnumerable<GetHomeWorkDto>>(homeWorks);
                ApiResponse6<IEnumerable<GetHomeWorkDto>> response = new(homeWorksDTO);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 reaponse = new(message: ex.Message);
                return Ok(reaponse);
            }
        }

        // creat a method to get HomeWork by id using HomeWorkDTO , automapper , Try Catch block and Responses classes
        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var homeWork = await _unitOfWork.HomeWorks.GetByIdAsync(id);
                if (homeWork == null)
                {
                    ApiResponse3 reaponse = new();
                    return NotFound(reaponse);
                }
                var homeWorkDTO = _mapper.Map<GetHomeWorkDto>(homeWork);
                ApiResponse6<GetHomeWorkDto> response = new(homeWorkDTO);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 response = new ApiResponse4(message: ex.Message);
                return StatusCode(500, response);
            }
        }

        [HttpGet("GetBySubjectClassId/{id}")]

        public async Task<IActionResult> GetBySubjectClassId(int id)
        {
            try
            {
                var homeWorks = await _unitOfWork.HomeWorks.GetBySubjectClassId(id);
                if (homeWorks == null)
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

        // creat a method to create HomeWork using HomeWorkDTO , automapper , Try Catch block , Responses classes check if the object is null and if the model is valid and other nessesary checks
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostHomeWorkDto homeWorkDto)
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
                var homeWork = _mapper.Map<HomeWork>(homeWorkDto);
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

        // creat a method to update HomeWork using HomeWorkDTO , automapper , Try Catch block , Responses classes check if the object is null and if the model is valid and other nessesary checks
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PostHomeWorkDto homeWorkDto)
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
                ApiResponse5<PostHomeWorkDto> response = new(homeWorkDto);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 response = new(message: ex.Message);
                return StatusCode(500, response);
            }
        }

        // creat a method to delete HomeWork using HomeWorkDTO , automapper , Try Catch block , Responses classes check if the object is null and if the model is valid and other nessesary checks
        [HttpDelete("{id}")]
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

        //// creat a method to get all HomeWorks using HomeWorkDTO , automapper , Try Catch block and Responses classes
        //[HttpGet]
        //public IActionResult Get()
        //{
        //    try
        //    {
        //        var homeWorks = _unitOfWork.HomeWorks.GetAll();
        //        var homeWorksDTO = _mapper.Map<IEnumerable<HomeWorkDto>>(homeWorks);
        //        ApiResponse6<IEnumerable<HomeWorkDto>> response = new(homeWorksDTO);
        //        return Ok(homeWorksDTO);
        //    }
        //    catch (System.Exception ex)
        //    {
        //        ApiResponse4 reaponse = new(message:ex.Message);    
        //        return Ok(reaponse);
        //    }
        //}

        //// creat a method to get HomeWork by id using HomeWorkDTO , automapper , Try Catch block and Responses classes
        //[HttpGet("{id}", Name = "GetHomeWork")]

        //public IActionResult Get(int id)
        //{
        //    try
        //    {
        //        var homeWork = _unitOfWork.HomeWorks.GetById(id);
        //        if (homeWork == null)
        //        {
        //            ApiResponse3 reaponse = new();
        //            return NotFound(reaponse);
        //        }
        //        var homeWorkDTO = _mapper.Map<HomeWorkDto>(homeWork);
        //        ApiResponse6<HomeWorkDto> response = new(homeWorkDTO);
        //        return Ok(homeWorkDTO);
        //    }
        //    catch (System.Exception ex)
        //    {
        //        ApiResponse4 response = new ApiResponse4(message: ex.Message);
        //        return StatusCode(500, response);
        //    }
        //}

        //// creat a method to create HomeWork using HomeWorkDTO , automapper , Try Catch block , Responses classes check if the object is null and if the model is valid and other nessesary checks
        //[HttpPost]
        //public IActionResult Post([FromBody] HomeWorkDto homeWorkDto)
        //{
        //    try
        //    {
        //        if (homeWorkDto == null)
        //        {
        //            ApiResponse2 response1 = new();
        //            return BadRequest(response1);
        //        }
        //        if (!ModelState.IsValid)
        //        {
        //            ApiResponse2 response2 = new();
        //            return BadRequest(response2);
        //        }
        //        var classsubject = _unitOfWork.SubjectClasses.GetById(homeWorkDto.SubjectClassId);
        //        if (classsubject == null)
        //        {
        //            ApiResponse2 response3 = new();
        //            return BadRequest(response3);
        //        }
        //        var homeWork = _mapper.Map<HomeWork>(homeWorkDto);
        //        _unitOfWork.HomeWorks.Add(homeWork);
        //        _unitOfWork.Save();
        //        ApiResponse5<HomeWorkDto> response = new(homeWorkDto);
        //        return Ok(response);
        //        //return CreatedAtRoute("GetHomeWork", new { id = homeWork.Id }, homeWork);
        //    }
        //    catch (System.Exception ex)
        //    {
        //        ApiResponse4 response = new(message: ex.Message);
        //        return StatusCode(500, response);
        //    }
        //}

        //// creat a method to update HomeWork using HomeWorkDTO , automapper , Try Catch block , Responses classes check if the object is null and if the model is valid and other nessesary checks
        //[HttpPut("{id}")]
        //public IActionResult Put(int id, [FromBody] HomeWorkDto homeWorkDto)
        //{
        //    try
        //    {
        //        if (homeWorkDto == null)
        //        {
        //            ApiResponse2 response1 = new();
        //            return BadRequest(response1);
        //        }
        //        if (!ModelState.IsValid)
        //        {
        //            ApiResponse2 response2 = new();
        //            return BadRequest(response2);
        //        }
        //        var homeWork = _unitOfWork.HomeWorks.GetById(id);
        //        if (homeWork == null)
        //        {
        //            ApiResponse3 response3 = new();
        //            return NotFound(response3);
        //        }
        //        _mapper.Map(homeWorkDto , homeWork);
        //        var homeWorkupdated = _mapper.Map<HomeWork>(homeWorkDto);
        //        //_unitOfWork.HomeWorks.Update(homeWorkupdated);
        //        _unitOfWork.Save();
        //        ApiResponse5<HomeWorkDto> response = new(homeWorkDto);
        //        return Ok(response);
        //    }
        //    catch (System.Exception ex)
        //    {
        //        ApiResponse4 response = new(message: ex.Message);
        //        return StatusCode(500, response);
        //    }
        //}

        //// creat a method to delete HomeWork using HomeWorkDTO , automapper , Try Catch block , Responses classes check if the object is null and if the model is valid and other nessesary checks
        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    try
        //    {
        //        var homeWork = _unitOfWork.HomeWorks.GetById(id);
        //        if (homeWork == null)
        //        {
        //            ApiResponse3 response1 = new();
        //            return NotFound(response1);
        //        }
        //        _unitOfWork.HomeWorks.Delete(homeWork);
        //        _unitOfWork.Save();
        //        var homeWorkDto = _mapper.Map<HomeWorkDto>(homeWork);   
        //        ApiResponse6<HomeWorkDto> response = new(homeWorkDto);
        //        return Ok(response);
        //    }
        //    catch (System.Exception ex)
        //    {
        //        ApiResponse4 response = new(message: ex.Message);
        //        return StatusCode(500, response);
        //    }
        //}


    }
}
