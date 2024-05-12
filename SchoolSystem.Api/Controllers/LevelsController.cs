using Microsoft.AspNetCore.Http;
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
    public class LevelsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public LevelsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // create a method to get all levels from the database using the unit of work and levelDto the ApiResponse model from the DAL project and try catch block
        [HttpGet]
        public IActionResult GetLevels()
        {
            try
            {
                var levels = _unitOfWork.Levels.GetAll();
                var data = _mapper.Map<IEnumerable<LevelDto>>(levels);

                ApiResponse6<IEnumerable<LevelDto>> response = new ApiResponse6<IEnumerable<LevelDto>>(data, null, "Levels retrieved successfully", true, "200");

                return Ok(response);
            }
            catch (System.Exception ex)
            {
               ApiResponse4 response = new ApiResponse4(message : ex.Message);
                return StatusCode(500,response);
            }
        }

        // create a method to get a level by id from the database using the unit of work and levelDto the ApiResponse model from the DAL project and try catch block    
        [HttpGet("{id}")]
        public IActionResult GetLevel(int id)
        {
            try
            {
                var level = _unitOfWork.Levels.GetById(id);
                if (level == null)
                {
                    ApiResponse3 responsex = new ApiResponse3(message: "Level data is missing");
                    return StatusCode(400, responsex);
                }
                var data = _mapper.Map<LevelDto>(level);
                ApiResponse6<LevelDto> response = new ApiResponse6<LevelDto>(data, null, "Level retrieved successfully", true, "200");
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 response = new ApiResponse4(message: ex.Message);
                return StatusCode(500, response);
            }
        }

        // create a method to create a level in the database using the unit of work and levelDto the ApiResponse model from the DAL project and try catch block
        [HttpPost]
        public IActionResult CreateLevel([FromBody] LevelDto levelDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ApiResponse3 modelStateresponse = new ApiResponse3(message: "Invalid model state");
                    return StatusCode(400, modelStateresponse);
                }
                var levelExists = _unitOfWork.Levels.Find(x => x.LevelName == levelDto.LevelName);
                if (levelExists != null)
                {
                    ApiResponse3 levelExistsresponse = new ApiResponse3(message: "Level already exists");
                    return StatusCode(400, levelExistsresponse);
                }

                var level = _mapper.Map<Level>(levelDto);

                _unitOfWork.Levels.Add(level);
                _unitOfWork.Complete();
                ApiResponse5<LevelDto> response = new ApiResponse5<LevelDto>(levelDto, null, "Level created successfully", true, "201");
                return StatusCode(201, response);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 response = new ApiResponse4(message: ex.Message);
                return StatusCode(500, response);
            }
        }



        // create a method to update a level in the database using the unit of work and levelDto the ApiResponse model from the DAL project and try catch block
        [HttpPut("{id}")]
        public IActionResult UpdateLevel(int id, [FromBody] LevelDto levelDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ApiResponse3 modelStateresponse = new ApiResponse3(message: "Invalid model state");
                    return StatusCode(400, modelStateresponse);
                }

                var level = _unitOfWork.Levels.GetById(id);
                if (level == null)
                {
                    ApiResponse3 responsex = new ApiResponse3(message: "Level data is missing");
                    return StatusCode(400, responsex);
                }

                //_mapper.Map<Level>(levelDto);   
                level.LevelName = levelDto.LevelName;

                _unitOfWork.Complete();
                ApiResponse5<LevelDto> response = new ApiResponse5<LevelDto>(levelDto, null, "Level updated successfully", true, "201");
                return StatusCode(201, response);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 response = new ApiResponse4(message: ex.Message);
                return StatusCode(500, response);
            }
        }
        // create a method to delete a level in the database using the unit of work and levelDto the ApiResponse model from the DAL project and try catch block
        [HttpDelete("{id}")]
        public IActionResult DeleteLevel(int id)
        {
            try
            {
                var level = _unitOfWork.Levels.GetById(id);
                if (level == null)
                {
                    ApiResponse3 responsex = new ApiResponse3(message: "Level data is missing");
                    return StatusCode(400, responsex);
                }
                var levelDto = _mapper.Map<LevelDto>(level);
                _unitOfWork.Levels.Delete(level);
                _unitOfWork.Complete();
                ApiResponse<LevelDto> response = new ApiResponse<LevelDto>(data: levelDto, message: "Level deleted successfully");
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 response = new ApiResponse4(message: ex.Message);
                return StatusCode(500, response);
            }
        }
        



    }
}
