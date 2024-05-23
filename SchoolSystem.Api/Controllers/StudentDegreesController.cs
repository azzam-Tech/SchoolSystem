using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DAL.UnitOfWork;
using SchoolSystem.BLL.DTOs;
using SchoolSystem.BLL.DTOs.GetDto;
using SchoolSystem.DAL.Entites;
using SchoolSystem.DAL.Models;
using AutoMapper;
using SchoolSystem.BLL.DTOs.PostDto;
using SchoolSystem.BLL.DTOs.EditDto;
using System.Collections.Generic;

namespace SchoolSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentDegreesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public StudentDegreesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var studentDegrees = await _unitOfWork.StudentDegrees.GetAllAsync();
                var studentDegreesDTO = _mapper.Map<IEnumerable<GetStudentDegreeDto>>(studentDegrees);
                ApiResponse6<IEnumerable<GetStudentDegreeDto>> response = new(studentDegreesDTO);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 reaponse = new(message: ex.Message);
                return Ok(reaponse);
            }
        }

        [HttpGet("GetBySbjectClassIdandDegreeTypeId/{sbjectClassId}/{degreeTypeId}")]
        public async Task<IActionResult> GetBySbjectClassIdandDegreeTypeId(int sbjectClassId , int degreeTypeId)
        {
            try
            {
                var studentDegree = await _unitOfWork.StudentDegrees.GetBySbjectClassIdandDegreeTypeId(sbjectClassId , degreeTypeId);
                if (studentDegree == null)
                {
                    ApiResponse3 reaponse = new();
                    return NotFound(reaponse);
                }
                //var studentDegreeDto = _mapper.Map<GetStudentDegreeDto>(studentDegree);

                List<GetStudentDegreeDto> studentDegreeDto = new List<GetStudentDegreeDto>();
                foreach (var item in studentDegree)
                {
                    studentDegreeDto.Add(new GetStudentDegreeDto
                    {
                        StudentDegreeId = item.StudentDegreeId,
                        StudentName = item.Student.User.UserName,   
                        StudentDegreeValue = item.StudentDegreeValue,

                    });
                }

                ApiResponse6<IEnumerable<GetStudentDegreeDto>> response = new(studentDegreeDto);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 response = new ApiResponse4(message: ex.Message);
                return StatusCode(500, response);
            }
        }

        [HttpPost("createAllmarks")]
        public async Task<IActionResult> createAllmarks()
        {
            try
            {
                var studentDegrees = await _unitOfWork.StudentDegrees.GetAllAsync();
                var studentsFDB = await _unitOfWork.StudentDegrees.GetAllStudent();
               var degreeTypeFDB = await _unitOfWork.StudentDegrees.GetAllDegreeType();
               var subjectClassesFDB = await _unitOfWork.StudentDegrees.GetAllSubjectClass();
                if (studentsFDB == null || studentsFDB.Count() == 0) 
                {
                    ApiResponse2 response3 = new();
                    return BadRequest(response3);
                }

                var studentsDegrees = new List<StudentDegree>();
                foreach (var student in studentsFDB)
                {
                    foreach (var degreeType in degreeTypeFDB)
                    {
                        foreach( var subjectClasse in subjectClassesFDB )
                        {
                            if(student.ClassId == subjectClasse.ClassId)
                            {
                                studentsDegrees.Add(new StudentDegree
                                {
                                    StudentId = student.StudentId,
                                    DegreeTypeId = degreeType.DegreeTypeId,
                                    StudentDegreeValue = 0,
                                    SubjectClassId = subjectClasse.SubjectClassId,
                                    TermId = 1,
                                });
                            }

                            //var x = new StudentDegree
                            //{
                            //    StudentId = student.StudentId,
                            //    DegreeTypeId = degreeType.DegreeTypeId,
                            //    StudentDegreeValue = 0,
                            //    SubjectClassId = subjectClasse.SubjectClassId,
                            //    TermId = 1,
                            //};

                            //foreach (var item in studentDegrees)
                            //{
                            //    if (item.StudentId != x.StudentId && item.DegreeTypeId != x.DegreeTypeId && item.SubjectClassId != x.SubjectClassId)
                            //    {

                            //        studentsDegrees.Add(x);
                            //    }
                            //}

                        }

                    }
                }

                await _unitOfWork.StudentDegrees.AddRangeAsync(studentsDegrees);
                await _unitOfWork.SaveAsync();
                ApiResponse7 response = new();
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 response = new(message: ex.Message);
                return StatusCode(500, response);
            }
        }

        //[HttpGet("GetByStudentId/{id}")]
        //public async Task<IActionResult> GetGetByStudentIdById(int id)
        //{
        //    try
        //    {
        //        var studentDegree = await _unitOfWork.StudentDegrees.GetStudentDegreesByStudentId(id);
        //        if (studentDegree == null)
        //        {
        //            ApiResponse3 reaponse = new();
        //            return NotFound(reaponse);
        //        }
        //        List<GetStudentDegreeDto> studentDegreeDto = new List<GetStudentDegreeDto>(); 
        //        foreach (var item in studentDegree)
        //        {
        //            studentDegreeDto.Add(new GetStudentDegreeDto
        //            {
        //                SubjectClassId = item.SubjectClassId,
        //                DegreeTypeId = item.DegreeTypeId,
        //                StudentDegreeValue = item.StudentDegreeValue,
        //            });
        //        }
        //        ApiResponse6<IEnumerable<GetStudentDegreeDto>> response = new(studentDegreeDto);
        //        return Ok(response);
        //    }
        //    catch (System.Exception ex)
        //    {
        //        ApiResponse4 response = new ApiResponse4(message: ex.Message);
        //        return StatusCode(500, response);
        //    }
        //}

        [HttpPut("Edit")]
        public async Task<IActionResult> Put( [FromBody] List<EditStudentDegreeDto> editStudentDegreesDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ApiResponse2 response2 = new();
                    return BadRequest(response2);
                }
                if (editStudentDegreesDto == null)
                {
                    ApiResponse2 response1 = new();
                    return BadRequest(response1);
                }
                var studentDegrees = await _unitOfWork.StudentDegrees.GetAllAsync();
                if (studentDegrees == null || studentDegrees.Count() == 0)
                {
                    ApiResponse3 response3 = new();
                    return NotFound(response3);
                }

                foreach(var studentDegree in studentDegrees)
                {
                    foreach( var editStudentDegreeDto in editStudentDegreesDto)
                        if(editStudentDegreeDto.StudentDegreeId == studentDegree.StudentDegreeId) 
                        { studentDegree.StudentDegreeValue = editStudentDegreeDto.StudentDegreeValue; }
                          
                }


                await _unitOfWork.SaveAsync();
                ApiResponse5<IEnumerable< EditStudentDegreeDto>> response = new(editStudentDegreesDto);
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
