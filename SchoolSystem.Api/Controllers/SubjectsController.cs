using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DAL.UnitOfWork;
using SchoolSystem.BLL.DTOs;
using SchoolSystem.DAL.Entites;
using SchoolSystem.DAL.Models;
using SchoolSystem.BLL.DTOs.GetDto;
using SchoolSystem.BLL.DTOs.PostDto;


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
        public async Task<IActionResult> GetSubjects()
        {
            try
            {
                var subjects = await _unitOfWork.Subjects.GetAllAsync();
                var subjectDto = _mapper.Map<IEnumerable<GetSubjectDto>>(subjects);

                ApiResponse6<IEnumerable<GetSubjectDto>> response = new (subjectDto);

                return Ok(response);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 reaponse = new(message: ex.Message);
                return Ok(reaponse);
            }
        }


        [HttpGet("GetSubjectById/{id}")]
        public async Task<IActionResult> GetSubjectById(int id)
        {
            try
            {
                var subject = await _unitOfWork.Subjects.GetByIdAsync(id);
                if (subject == null)
                {
                    ApiResponse3 reaponse = new();
                    return NotFound(reaponse);
                }
                var Dtodata = _mapper.Map<GetSubjectDto>(subject);
                ApiResponse6<GetSubjectDto> response = new (Dtodata);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 reaponse = new(message: ex.Message);
                return Ok(reaponse);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddSubject([FromBody] PostSubjectDto subjectDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ApiResponse2 response2 = new();
                    return BadRequest(response2);
                }

                if (subjectDto == null)
                {
                    ApiResponse2 response1 = new();
                    return BadRequest(response1);
                }     
                var subjectExist = await _unitOfWork.Subjects.FindAsync(x => x.SubjectName == subjectDto.SubjectName && x.LevelId == subjectDto.LevelId);
                if (subjectExist != null)
                {
                    ApiResponse2 response1 = new(message: "Subject already exists");
                    return BadRequest(response1);
                }

                var subject = _mapper.Map<Subject>(subjectDto);
                await _unitOfWork.Subjects.AddAsync(subject);
                await _unitOfWork.SaveAsync();
                ApiResponse6<PostSubjectDto> response = new (subjectDto);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 reaponse = new(message: ex.Message);
                return Ok(reaponse);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSubject(int id, PostSubjectDto subjectDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ApiResponse2 response2 = new();
                    return BadRequest(response2);
                }

                if (subjectDto == null)
                {
                    ApiResponse2 response1 = new();
                    return BadRequest(response1);
                }
                var subject = _unitOfWork.Subjects.GetByIdAsync(id);
                if (subject == null)
                {
                    ApiResponse3 response1 = new();
                    return NotFound(response1);
                }


                 _mapper.Map(subjectDto, subject);
                

                await _unitOfWork.SaveAsync();
                ApiResponse5<PostSubjectDto> response = new (subjectDto);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 reaponse = new(message: ex.Message);
                return Ok(reaponse);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            try
            {
                var subject = await _unitOfWork.Subjects.GetByIdAsync(id);
                if (subject == null)
                {
                    ApiResponse3 response3 = new();
                    return NotFound(response3);
                }
                var subjectDto = _mapper.Map<GetSubjectDto>(subject);
                _unitOfWork.Subjects.Delete(subject);
                await _unitOfWork.SaveAsync();
                ApiResponse6<GetSubjectDto> response = new (subjectDto);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 reaponse = new(message: ex.Message);
                return Ok(reaponse);
            }
        }

    }
}
