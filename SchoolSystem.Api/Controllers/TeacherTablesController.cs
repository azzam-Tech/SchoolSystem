
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DAL.UnitOfWork;
using SchoolSystem.DAL.Entites;
using SchoolSystem.DAL.Models;
using AutoMapper;
using SchoolSystem.BLL.DTOs.GetDto;
using SchoolSystem.BLL.DTOs.PostDto;

namespace SchoolSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherTablesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public TeacherTablesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }



        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var teacherTablesFDB = await _unitOfWork.TeacherTables.GetAllAsync();
                var teacherTablesDTO = _mapper.Map<IEnumerable<GetTeacherTableDto>>(teacherTablesFDB);
                ApiResponse6<IEnumerable<GetTeacherTableDto>> response = new(teacherTablesDTO);
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
                var teacherTablesFDB = await _unitOfWork.TeacherTables.GetByIdAsync(id);
                if (teacherTablesFDB == null)
                {
                    ApiResponse3 reaponse = new();
                    return NotFound(reaponse);
                }
                var teacherTableDto = _mapper.Map<GetTeacherTableDto>(teacherTablesFDB);

                //foreach (var teachertimetable in teacherTableFDB)
                //{

                //    foreach (var teacherTimeTabledto in teacherTableDto)
                //    {
                //        if (teachertimetable.TeacherTableId == teacherTimeTabledto.TeacherTableId)
                //        {

                //            var periods = new List<string>();
                //            periods.Add(teachertimetable.PeriodOne!);
                //            periods.Add(teachertimetable.PeriodTow!);
                //            periods.Add(teachertimetable.PeriodThree!);
                //            periods.Add(teachertimetable.PeriodFour!);
                //            periods.Add(teachertimetable.PeriodFive!);
                //            periods.Add(teachertimetable.PeriodSix!);
                //            periods.Add(teachertimetable.PeriodSeven!);
                //            periods.Add(teachertimetable.PeriodEight!);

                //            teacherTimeTabledto.Periods = periods;
                //        }
                //    }
                //}
                ApiResponse6<GetTeacherTableDto> response = new(teacherTableDto);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 response = new ApiResponse4(message: ex.Message);
                return StatusCode(500, response);
            }
        }

        [HttpGet("GetByTeacherId/{id}")]
        public async Task<IActionResult> GetByTeacherId(int id)
        {
            try
            {
                var teacherTableFDB = await _unitOfWork.TeacherTables.GetByTeacherIdAsync(id);
                if (teacherTableFDB == null)
                {
                    ApiResponse3 reaponse = new();
                    return NotFound(reaponse);
                }
                var teacherTableDto = _mapper.Map<IEnumerable< GetTeacherTableDto>>(teacherTableFDB);
                ApiResponse6<IEnumerable<GetTeacherTableDto>> response = new(teacherTableDto);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 response = new ApiResponse4(message: ex.Message);
                return StatusCode(500, response);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostTeacherTableDto teacherTableDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ApiResponse2 response2 = new();
                    return BadRequest(response2);
                }
                if (teacherTableDto == null)
                {
                    ApiResponse2 response1 = new();
                    return BadRequest(response1);
                }

                var user = await _unitOfWork.Users.GetByIdAsync(teacherTableDto.UserId);
                if (user == null)
                {
                    ApiResponse2 response3 = new();
                    return BadRequest(response3);
                }

                var teacherTable = _mapper.Map<TeacherTable>(teacherTableDto);
                await _unitOfWork.TeacherTables.AddAsync(teacherTable);
                await _unitOfWork.SaveAsync();
                ApiResponse6<PostTeacherTableDto> response = new(_mapper.Map<PostTeacherTableDto>(teacherTableDto));
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 response = new ApiResponse4(message: ex.Message);
                return StatusCode(500, response);
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PostTeacherTableDto teacherTableDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ApiResponse2 response2 = new();
                    return BadRequest(response2);
                }
                if (teacherTableDto == null)
                {
                    ApiResponse2 response1 = new();
                    return BadRequest(response1);
                }
                var teacherTableFDB = await _unitOfWork.TeacherTables.GetByIdAsync(id);
                if (teacherTableFDB == null)
                {
                    ApiResponse3 response3 = new();
                    return NotFound(response3);
                }
                _mapper.Map(teacherTableDto, teacherTableFDB);
                //_unitOfWork.Solutions.Update(solution);
                await _unitOfWork.SaveAsync();
                ApiResponse5<PostTeacherTableDto> response = new(teacherTableDto);
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
                var teacherTableFDB = await _unitOfWork.TeacherTables.GetByIdAsync(id);
                if (teacherTableFDB == null)
                {
                    ApiResponse3 response3 = new();
                    return NotFound(response3);
                }
                _unitOfWork.TeacherTables.Delete(teacherTableFDB);
                await _unitOfWork.SaveAsync();
                var TeacherTableDto = _mapper.Map<GetTeacherTableDto>(teacherTableFDB);
                ApiResponse6<GetTeacherTableDto> response = new(TeacherTableDto);
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

