using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DAL.UnitOfWork;
using SchoolSystem.BLL.DTOs;
using SchoolSystem.DAL.Entites;
using SchoolSystem.DAL.Models;

namespace SchoolSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public SubjectsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetSubjects()
        {
            try
            {
                var subjects = _unitOfWork.Subjects.GetAll();
                var data = _mapper.Map<IEnumerable<SubjectDto>>(subjects);

                ApiResponse6<IEnumerable<SubjectDto>> response = new ApiResponse6<IEnumerable<SubjectDto>>(data, null, "Subjects retrieved successfully", true, "200");

                return Ok(response);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 response = new ApiResponse4(message: ex.Message);
                return StatusCode(500, response);
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetSubjectById(int id)
        {
            try
            {
                var subject = _unitOfWork.Subjects.GetById(id);
                if (subject == null)
                {
                    ApiResponse3 responsex = new ApiResponse3(message: "Subject data is missing");
                    return StatusCode(400, responsex);
                }
                var data = _mapper.Map<SubjectDto>(subject);
                ApiResponse6<SubjectDto> response = new ApiResponse6<SubjectDto>(data, null, "Subject retrieved successfully", true, "200");
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 response = new ApiResponse4(message: ex.Message);
                return StatusCode(500, response);
            }
        }
        [HttpPost]
        public IActionResult AddSubject(SubjectDto subjectDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ApiResponse3 modelStateresponse = new ApiResponse3(message: "Subject data is missing");
                    return StatusCode(400, modelStateresponse);
                }
                var subject = _mapper.Map<Subject>(subjectDto);
                
                var subjectExist = _unitOfWork.Subjects.Find(x => x.SubjectName == subject.SubjectName && x.LevelId == subject.LevelId);
                if (subjectExist != null)
                {
                    ApiResponse3 subjectExistresponse = new ApiResponse3(message: "Subject already exists");
                    return StatusCode(400, subjectExistresponse);
                }

                _unitOfWork.Subjects.Add(subject);
                _unitOfWork.Complete();
                ApiResponse6<SubjectDto> response = new ApiResponse6<SubjectDto>(subjectDto, null, "Subject added successfully", true, "200");
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 response = new ApiResponse4(message: ex.Message);
                return StatusCode(500, response);
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateSubject(int id, SubjectDto subjectDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ApiResponse3 modelStateresponse = new ApiResponse3(message: "Invalid model state");
                    return StatusCode(400, modelStateresponse);
                }

                var subject = _unitOfWork.Subjects.GetById(id);
                if (subject == null)
                {
                    ApiResponse3 responsex = new ApiResponse3(message: "Subject data is missing");
                    return StatusCode(400, responsex);
                }
                _mapper.Map(subjectDto, subject);
                _unitOfWork.Complete();
                ApiResponse6<SubjectDto> response = new ApiResponse6<SubjectDto>(subjectDto, null, "Subject updated successfully", true, "200");
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 response = new ApiResponse4(message: ex.Message);
                return StatusCode(500, response);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSubject(int id)
        {
            try
            {
                var subject = _unitOfWork.Subjects.GetById(id);
                if (subject == null)
                {
                    ApiResponse3 responsex = new ApiResponse3(message: "Subject data is missing");
                    return StatusCode(400, responsex);
                }
                _unitOfWork.Subjects.Delete(subject);
                _unitOfWork.Complete();
                ApiResponse6<SubjectDto> response = new ApiResponse6<SubjectDto>(null, null, "Subject deleted successfully", true, "200");
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
