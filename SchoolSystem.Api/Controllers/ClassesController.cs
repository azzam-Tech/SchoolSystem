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
    public class ClassesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        //private readonly IMapper _mapper;
        public ClassesController(IUnitOfWork unitOfWork /*IMapper mapper*/)
        {
            _unitOfWork = unitOfWork;
            //_mapper = mapper;
        }

        // create a method to get all classes from the database using the unit of work and classDto the ApiResponse model from the DAL project and try catch block
        [HttpGet]
        public IActionResult GetClasses()
        {
            try
            {
                var classes = _unitOfWork.Classes.GetAll();


                //var data = _mapper.Map<IEnumerable<ClassDto>>(classes);

                var data = new List<ClassDto>();
                foreach (var c in classes)
                {
                    var classDto = new ClassDto
                    {
                        ClassName = c.ClassName,
                        ClassSopervisor = c.ClassSopervisor,
                        LevelId = c.LevelId,
                    };
                    data.Add(classDto);
                }

                ApiResponse6<IEnumerable<ClassDto>> response = new ApiResponse6<IEnumerable<ClassDto>>(data, null, "Classes retrieved successfully", true, "200");

                return Ok(response);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 response = new ApiResponse4(message : ex.Message);
                return StatusCode(500,response);
            }
        }

        // create a method to get a class by id from the database using the unit of work and classDto the ApiResponse model from the DAL project and try catch block    
        [HttpGet("{id}")]
        public IActionResult GetClassById(int id)
        {
            try
            {
                var classs = _unitOfWork.Classes.GetById(id);
                if (classs == null)
                {
                    ApiResponse3 responsex = new ApiResponse3(message: "Class data is missing");
                    return StatusCode(400, responsex);
                }
                //var data = _mapper.Map<ClassDto>(classs);
                var data = new ClassDto
                {
                    ClassName = classs.ClassName,
                    ClassSopervisor = classs.ClassSopervisor,
                    LevelId = classs.LevelId,
                };


                ApiResponse6<ClassDto> response = new ApiResponse6<ClassDto>(data, null, "Class retrieved successfully", true, "200");
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 response = new ApiResponse4(message: ex.Message);
                return StatusCode(500, response);
            }
        }

        [HttpPost]
        public IActionResult AddClass([FromBody] ClassDto classDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ApiResponse3 responsex = new ApiResponse3(message: "Model state is invalid");
                    return StatusCode(400, responsex);
                }

                var classExists = _unitOfWork.Classes.Find(x => x.ClassName == classDto.ClassName && x.LevelId == classDto.LevelId);
                if (classExists != null)
                {
                    ApiResponse3 responsex = new ApiResponse3(message: "Subject class already exists");
                    return StatusCode(400, responsex);
                }

                var level = _unitOfWork.Levels.GetById(classDto.LevelId);
                if (level == null)
                {
                    ApiResponse3 responsex = new ApiResponse3(message: "level does not exist");
                    return StatusCode(400, responsex);
                }

                //var classs = _mapper.Map<Class>(classDto);

                var c = new Class
                {
                    LevelId = classDto.LevelId, 
                    ClassSopervisor = classDto.ClassSopervisor,
                    ClassName = classDto.ClassName,
                };

                _unitOfWork.Classes.Add(c);
                _unitOfWork.Save();
                ApiResponse6<ClassDto> response = new ApiResponse6<ClassDto>(classDto, null, "Subject class added successfully", true, "200");
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 response = new ApiResponse4(message: ex.Message);
                return StatusCode(500, response);
            }
        }

        //create a mthod to add range of classes use apiresponse model from DAL project and try catch block check if model state is valid and if the class already exists in the database and if the level exists in the database
        [HttpPost("addrange")]
        public IActionResult AddRangeOfClasses([FromBody] IEnumerable<ClassDto> classesDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ApiResponse3 responsex = new ApiResponse3(message: "Model state is invalid");
                    return StatusCode(400, responsex);
                }

                foreach (var classDto in classesDto)
                {
                    var classExists = _unitOfWork.Classes.Find(x => x.ClassName == classDto.ClassName && x.LevelId == classDto.LevelId);
                    if (classExists != null)
                    {
                        ApiResponse3 responsex = new ApiResponse3(message: "Subject class already exists");
                        return StatusCode(400, responsex);
                    }

                    var level = _unitOfWork.Levels.GetById(classDto.LevelId);
                    if (level == null)
                    {
                        ApiResponse3 responsex = new ApiResponse3(message: "level does not exist");
                        return StatusCode(400, responsex);
                    }

                    //var classs = _mapper.Map<Class>(classDto);

                    var c = new Class
                    {
                        LevelId = classDto.LevelId,
                        ClassSopervisor = classDto.ClassSopervisor,
                        ClassName = classDto.ClassName,
                    };
                    _unitOfWork.Classes.Add(c);
                }
                _unitOfWork.Save();

                ApiResponse6<IEnumerable<ClassDto>> response = new ApiResponse6<IEnumerable<ClassDto>>(classesDto, null, "Subject classes added successfully", true, "200");
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
