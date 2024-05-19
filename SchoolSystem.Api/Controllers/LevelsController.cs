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
        public async Task<IActionResult> GetLevels()
        {
            try
            {
                var levels = await _unitOfWork.Levels.GetAllAsync();
                var levelsDto = _mapper.Map<IEnumerable<GetLevelDto>>(levels);

                ApiResponse6<IEnumerable<GetLevelDto>> response = new (levelsDto);

                return Ok(response);
            }
            catch (System.Exception ex)
            {
               ApiResponse4 response = new ApiResponse4(message : ex.Message);
                return StatusCode(500,response);
            }
        }


        // create a method to get a level by id from the database using the unit of work and levelDto the ApiResponse model from the DAL project and try catch block    
        [HttpGet("GetLevelById/{id}")]
        public async Task<IActionResult> GetLevelById(int id)
        {
            try
            {
                var level = await _unitOfWork.Levels.GetByIdAsync(id);
                if (level == null)
                {
                    ApiResponse3 responsex = new ();
                    return NotFound(responsex);
                }
                var levelDto = _mapper.Map<GetLevelDto>(level);
                ApiResponse6<GetLevelDto> response = new (levelDto);
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
        public async Task<IActionResult> CreateLevel([FromBody] PostLevelDto levelDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ApiResponse3 modelStateresponse = new ();
                    return BadRequest(modelStateresponse);
                }
                if (levelDto == null)
                {
                    ApiResponse2 response1 = new();
                    return BadRequest(response1);
                }
                var levelExists = await _unitOfWork.Levels.FindAsync(x => x.LevelName == levelDto.LevelName);
                if (levelExists != null)
                {
                    ApiResponse3 levelExistsresponse = new ApiResponse3(message: "Level already exists");
                    return BadRequest(levelExistsresponse);
                }

                var level = _mapper.Map<Level>(levelDto);

                _unitOfWork.Levels.Add(level);
                await _unitOfWork.SaveAsync();
                ApiResponse5<PostLevelDto> response = new ApiResponse5<PostLevelDto>(levelDto);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 response = new ApiResponse4(message: ex.Message);
                return StatusCode(500, response);
            }
        }


        // create a method to update a level in the database using the unit of work and levelDto the ApiResponse model from the DAL project and try catch block
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLevel(int id, [FromBody] PostLevelDto levelDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ApiResponse2 modelStateresponse = new ();
                    return  BadRequest( modelStateresponse);
                }

                if (levelDto == null)
                {
                    ApiResponse2 response1 = new();
                    return BadRequest(response1);
                }

                var level = await _unitOfWork.Levels.GetByIdAsync(id);
                if (level == null)
                {
                    ApiResponse3 response3 = new();
                    return NotFound(response3);
                }

                //_mapper.Map<Level>(levelDto);   
                level.LevelName = levelDto.LevelName;

                await _unitOfWork.SaveAsync();
                ApiResponse5<PostLevelDto> response = new(levelDto);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 response = new ApiResponse4(message: ex.Message);
                return StatusCode(500, response);
            }
        }
        // create a method to delete a level in the database using the unit of work and levelDto the ApiResponse model from the DAL project and try catch block
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLevel(int id)
        {
            try
            {
                var level = await _unitOfWork.Levels.GetByIdAsync(id);
                if (level == null)
                {
                    ApiResponse3 response3 = new();
                    return NotFound(response3);
                }
                var levelDto = _mapper.Map<GetLevelDto>(level);
                _unitOfWork.Levels.Delete(level);
                await _unitOfWork.SaveAsync();
                ApiResponse<GetLevelDto> response = new (levelDto);
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
