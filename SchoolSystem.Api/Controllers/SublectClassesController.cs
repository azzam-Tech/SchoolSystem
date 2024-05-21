using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DAL.Data;
using SchoolSystem.DAL.UnitOfWork;
using SchoolSystem.BLL.DTOs;
using SchoolSystem.DAL.Entites;
using SchoolSystem.DAL.Models;
using AutoMapper;

namespace SchoolSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SublectClassesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public SublectClassesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //create a method to get all subject classes from the database using the unit of work and subjectClassDto the ApiResponse model from the DAL project and try catch block
        [HttpGet]
        public IActionResult GetSubjectClasses()
        {
            try
            {
                var subjectClasses = _unitOfWork.SubjectClasses.GetAll();
                //var data = _mapper.Map<IEnumerable<SubjectClassDto>>(subjectClasses);

                var data = new List<SubjectClassDto>();
                foreach (var subjectClass in subjectClasses)
                {
                    var subjectClassDto = new SubjectClassDto
                    {
                        SubjectId = subjectClass.SubjectId,
                        ClassId = subjectClass.ClassId,
                        SubjectClassName = subjectClass.SubjectClassName
                    };
                    data.Add(subjectClassDto);
                }

                ApiResponse6<IEnumerable<SubjectClassDto>> response = new ApiResponse6<IEnumerable<SubjectClassDto>>(data, null, "Subject classes retrieved successfully", true, "200");

                return Ok(response);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 response = new ApiResponse4(message: ex.Message);
                return StatusCode(500, response);
            }
        }

        //create a method to get a subject class by id from the database using the unit of work and subjectClassDto the ApiResponse model from the DAL project and try catch block
        [HttpGet("{id}")]
        public IActionResult GetSubjectClass(int id)
        {
            try
            {
                var subjectClass = _unitOfWork.SubjectClasses.GetById(id);
                if (subjectClass == null)
                {
                    ApiResponse3 responsex = new ApiResponse3(message: "Subject class data is missing");
                    return StatusCode(400, responsex);
                }
                //var data = _mapper.Map<SubjectClassDto>(subjectClass);
                var subjectClassDto = new SubjectClassDto
                {
                    SubjectId = subjectClass.SubjectId,
                    ClassId = subjectClass.ClassId,
                    SubjectClassName = subjectClass.SubjectClassName
                };
                ApiResponse6<SubjectClassDto> response = new ApiResponse6<SubjectClassDto>(subjectClassDto, null, "Subject class retrieved successfully", true, "200");
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 response = new ApiResponse4(message: ex.Message);
                return StatusCode(500, response);
            }
        }

        //create a method to create a subject class in the database using the unit of work and subjectClassDto the ApiResponse model from the DAL project and try catch block and check if the subject class already exists and check if the subject and level exist and check the model state
        [HttpPost]
        public IActionResult AddSubjectClass( [FromBody] SubjectClassDto subjectClassDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ApiResponse3 responsex = new ApiResponse3(message: "Model state is invalid");
                    return StatusCode(400, responsex);
                }

                var subjectClassExists = _unitOfWork.SubjectClasses.Find(x => x.SubjectId == subjectClassDto.SubjectId && x.ClassId == subjectClassDto.ClassId);
                if (subjectClassExists != null)
                {
                    ApiResponse3 responsex = new ApiResponse3(message: "Subject class already exists");
                    return StatusCode(400, responsex);
                }

                var subject = _unitOfWork.Subjects.GetById(subjectClassDto.SubjectId);
                if (subject == null)
                {
                    ApiResponse3 responsex = new ApiResponse3(message: "Subject does not exist");
                    return StatusCode(400, responsex);
                }

                var cl = _unitOfWork.Classes.GetById(subjectClassDto.ClassId);
                if (cl == null)
                {
                    ApiResponse3 responsex = new ApiResponse3(message: "class does not exist");
                    return StatusCode(400, responsex);
                }
                //var subjectClass = _mapper.Map<SubjectClass>(subjectClassDto);

                var subjectClass = new SubjectClass
                {
                    SubjectId = subjectClassDto.SubjectId,
                    ClassId = subjectClassDto.ClassId,
                    SubjectClassName = subjectClassDto.SubjectClassName
                };  

                _unitOfWork.SubjectClasses.Add(subjectClass);
                _unitOfWork.Save();
                ApiResponse6<SubjectClassDto> response = new ApiResponse6<SubjectClassDto>(subjectClassDto, null, "Subject class added successfully", true, "200");
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 response = new ApiResponse4(message: ex.Message);
                //return StatusCode(500, response);
                return Ok(ex.InnerException);
            }
        }

        //create a method to update a subject class in the database using whit using tha same structure as the AddSubjectClass method
        [HttpPut("{id}")]
        public IActionResult UpdateSubjectClass(int id, [FromBody] SubjectClassDto subjectClassDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ApiResponse3 responsex = new ApiResponse3(message: "Model state is invalid");
                    return StatusCode(400, responsex);
                }

                var subjectClass1 = _unitOfWork.SubjectClasses.GetById(id);
                if (subjectClass1 == null)
                {
                    ApiResponse3 responsex = new ApiResponse3(message: "Subject class does not exist");
                    return StatusCode(400, responsex);
                }

                var subject = _unitOfWork.Subjects.GetById(subjectClassDto.SubjectId);
                if (subject == null)
                {
                    ApiResponse3 responsex = new ApiResponse3(message: "Subject does not exist");
                    return StatusCode(400, responsex);
                }

                var cl = _unitOfWork.Levels.GetById(subjectClassDto.ClassId);
                if (cl == null)
                {
                    ApiResponse3 responsex = new ApiResponse3(message: "class does not exist");
                    return StatusCode(400, responsex);
                }

                //var data = _mapper.Map<SubjectClass>(subjectClassDto);
                var subjectClass = new SubjectClass
                {
                    SubjectId = subjectClassDto.SubjectId,
                    ClassId = subjectClassDto.ClassId,
                    SubjectClassName = subjectClassDto.SubjectClassName
                };
                //data.SubjectClassId = id;
                _unitOfWork.SubjectClasses.Update(subjectClass);
                _unitOfWork.Save();
                ApiResponse6<SubjectClassDto> response = new ApiResponse6<SubjectClassDto>(subjectClassDto, null, "Subject class updated successfully", true, "200");
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 response = new ApiResponse4(message: ex.Message);
                return StatusCode(500, response);
            }
        }

        //create a method to delet a subjectclass from the database using subjectClassDto the ApiResponse model from the DAL project and try catch block    
        [HttpDelete("{id}")]
        public IActionResult DeleteSubjectClass(int id)
        {
            try
            {
                var subjectClass = _unitOfWork.SubjectClasses.GetById(id);
                if (subjectClass == null)
                {
                    ApiResponse3 responsex = new ApiResponse3(message: "Subject class does not exist");
                    return StatusCode(400, responsex);
                }
                _unitOfWork.SubjectClasses.Delete(subjectClass);
                _unitOfWork.Save();
                //var subjectClassDtoData = _mapper.Map<SubjectClassDto>(subjectClass);
                var subjectClassDto = new SubjectClassDto
                {
                    SubjectId = subjectClass.SubjectId,
                    ClassId = subjectClass.ClassId,
                    SubjectClassName = subjectClass.SubjectClassName
                };
                ApiResponse6<SubjectClassDto> response = new ApiResponse6<SubjectClassDto>(subjectClassDto, null, "Subject class deleted successfully", true, "200");
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 response = new ApiResponse4(message: ex.Message);
                return StatusCode(500, response);
            }
        }

        //create a method to add range of subject classes to the database using the same structure as the AddSubjectClass method
        [HttpPost("addrange")]
        public IActionResult AddRangeSubjectClass([FromBody] IEnumerable<SubjectClassDto> subjectClassesDtos)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ApiResponse3 responsex = new ApiResponse3(message: "Model state is invalid");
                    return StatusCode(400, responsex);
                }

               // var subjectClasses = _mapper.Map<IEnumerable<SubjectClass>>(subjectClassDtos);
               var subjectClasses = new List<SubjectClass>();

                foreach (var subjectClassDto in subjectClassesDtos)
                {
                    var subjectClassExists = _unitOfWork.SubjectClasses.Find(x => x.SubjectId == subjectClassDto.SubjectId && x.ClassId == subjectClassDto.ClassId);
                    if (subjectClassExists != null)
                    {
                        ApiResponse3 responsex = new ApiResponse3(message: "Subject class already exists");
                        return StatusCode(400, responsex);
                    }

                    var subject = _unitOfWork.Subjects.GetById(subjectClassDto.SubjectId);
                    if (subject == null)
                    {
                        ApiResponse3 responsex = new ApiResponse3(message: "Subject does not exist");
                        return StatusCode(400, responsex);
                    }

                    var cl = _unitOfWork.Levels.GetById(subjectClassDto.ClassId);
                    if (cl == null)
                    {
                        ApiResponse3 responsex = new ApiResponse3(message: "class does not exist");
                        return StatusCode(400, responsex);
                    }

                    var x = new SubjectClass
                    {
                        SubjectId = subjectClassDto.SubjectId,
                        ClassId = subjectClassDto.ClassId,
                        SubjectClassName = subjectClassDto.SubjectClassName
                    };
                    subjectClasses.Add(x);   
                }



                var data = _unitOfWork.SubjectClasses.AddRange(subjectClasses);
                _unitOfWork.Save();
                ApiResponse6<IEnumerable<SubjectClassDto>> response = new ApiResponse6<IEnumerable<SubjectClassDto>>(subjectClassesDtos, null, "Subject classes added successfully", true, "200");
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
