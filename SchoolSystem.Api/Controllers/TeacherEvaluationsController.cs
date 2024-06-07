using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DAL.UnitOfWork;
using SchoolSystem.DAL.Entites;
using SchoolSystem.DAL.Models;
using AutoMapper;
using SchoolSystem.BLL.DTOs.GetDto;
using SchoolSystem.BLL.DTOs.PostDto;
using Azure;
using SchoolSystem.BLL.DTOs.EditDto;


namespace SchoolSystem.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TeacherEvaluationsController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public TeacherEvaluationsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        //[HttpGet]
        //public async Task<IActionResult> Get()
        //{
        //    try
        //    {
        //        var teacherEvaluationsFDB = await _unitOfWork.TeacherEvaluations.GetAllAsync();
        //        var teacherEvaluationsDTO = _mapper.Map<IEnumerable<GetTeacherEvaluationDto>>(teacherEvaluationsFDB);
        //        ApiResponse6<IEnumerable<GetTeacherEvaluationDto>> response = new(teacherEvaluationsDTO);
        //        return Ok(response);
        //    }
        //    catch (System.Exception ex)
        //    {
        //        ApiResponse4 reaponse = new(message: ex.Message);
        //        return Ok(reaponse);
        //    }
        //}

        [HttpGet("GetAllwithnameAsync")]
        public async Task<IActionResult> GeGetAllwithnameAsynct()
        {
            try
            {
                var teacherEvaluationsFDB = await _unitOfWork.TeacherEvaluations.GetAllwithnameAsync();

                var getTeacherEvaluationDto = new List<GetTeacherEvaluationDto>();
                foreach(var teacherEvaluationFDB in teacherEvaluationsFDB)
                {
                    if (teacherEvaluationFDB.TeacherEvaluationCounter == 0)
                    {
                        teacherEvaluationFDB.TeacherEvaluationCounter = 1;
                    }
                    var getDto = new GetTeacherEvaluationDto()
                    {
                        TeacherEvaluationId = teacherEvaluationFDB.TeacherEvaluationId,
                        UserId = teacherEvaluationFDB.UserId,   
                        UserName = teacherEvaluationFDB.User.UserName,
                        TeacherEvaluationValueOne = teacherEvaluationFDB.TeacherEvaluationValueOne / teacherEvaluationFDB.TeacherEvaluationCounter,
                        TeacherEvaluationValueTow = teacherEvaluationFDB.TeacherEvaluationValueTow / teacherEvaluationFDB.TeacherEvaluationCounter,

                    };
                    getTeacherEvaluationDto.Add(getDto);




                }

                //var teacherEvaluationsDTO = _mapper.Map<IEnumerable<GetTeacherEvaluationDto>>(teacherEvaluationsFDB);
                ApiResponse6<IEnumerable<GetTeacherEvaluationDto>> response = new(getTeacherEvaluationDto);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 reaponse = new(message: ex.Message);
                return Ok(reaponse);
            }
        }

        //[HttpGet("GetById/{id}")]
        //public async Task<IActionResult> GetById(int id)
        //{
        //    try
        //    {
        //        var teacherTablesFDB = await _unitOfWork.TeacherTables.GetByIdAsync(id);
        //        if (teacherTablesFDB == null)
        //        {
        //            ApiResponse3 reaponse = new();
        //            return NotFound(reaponse);
        //        }
        //        var teacherTableDto = _mapper.Map<GetTeacherTableDto>(teacherTablesFDB);
        //        ApiResponse6<GetTeacherTableDto> response = new(teacherTableDto);
        //        return Ok(response);
        //    }
        //    catch (System.Exception ex)
        //    {
        //        ApiResponse4 response = new ApiResponse4(message: ex.Message);
        //        return StatusCode(500, response);
        //    }
        //}

        [HttpGet("GetByTeacherId/{id}")]
        public async Task<IActionResult> GetByTeacherId(int id)
        {
            try
            {
                var teacherEvaluationsFDB = await _unitOfWork.TeacherEvaluations.GetByTeacherIdAsync(id);
                if (teacherEvaluationsFDB == null)
                {
                    ApiResponse3 reaponse = new();
                    return NotFound(reaponse);
                }
                if (teacherEvaluationsFDB.TeacherEvaluationCounter == 0)
                {
                    teacherEvaluationsFDB.TeacherEvaluationCounter = 1;
                }
                var getDto = new GetTeacherEvaluationDto()
                {
                    TeacherEvaluationId = teacherEvaluationsFDB.TeacherEvaluationId,
                    UserId = teacherEvaluationsFDB.UserId,
                    UserName = teacherEvaluationsFDB.User.UserName,
                    TeacherEvaluationValueOne = teacherEvaluationsFDB.TeacherEvaluationValueOne / teacherEvaluationsFDB.TeacherEvaluationCounter,
                    TeacherEvaluationValueTow = teacherEvaluationsFDB.TeacherEvaluationValueTow / teacherEvaluationsFDB.TeacherEvaluationCounter
                };

                //var teacherEvaluationsDTO = _mapper.Map<GetTeacherEvaluationDto>(teacherEvaluationsFDB);
                ApiResponse6<GetTeacherEvaluationDto> response = new(getDto);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 response = new ApiResponse4(message: ex.Message);
                return StatusCode(500, response);
            }
        }

        //[HttpPost]
        //public async Task<IActionResult> Post([FromBody] PostTeacherEvaluationDto teacherEvaluationDto)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            ApiResponse2 response2 = new();
        //            return BadRequest(response2);
        //        }
        //        if (teacherEvaluationDto == null)
        //        {
        //            ApiResponse2 response1 = new();
        //            return BadRequest(response1);
        //        }

        //        var user = await _unitOfWork.Users.GetByIdAsync(teacherEvaluationDto.UserId);
        //        if (user == null)
        //        {
        //            ApiResponse2 response3 = new();
        //            return BadRequest(response3);
        //        }

        //        var teacherEvaluation = _mapper.Map<TeacherEvaluation>(teacherEvaluationDto);
        //        await _unitOfWork.TeacherEvaluations.AddAsync(teacherEvaluation);
        //        await _unitOfWork.SaveAsync();
        //        ApiResponse6<PostTeacherEvaluationDto> response = new(_mapper.Map<PostTeacherEvaluationDto>(teacherEvaluationDto));
        //        return Ok(response);
        //    }
        //    catch (System.Exception ex)
        //    {
        //        ApiResponse4 response = new ApiResponse4(message: ex.Message);
        //        return StatusCode(500, response);
        //    }
        //}


        [HttpPost]
        public async Task<IActionResult> CreateAll()
        {
            try
            {
                //var usersFDB = await _unitOfWork.TeacherEvaluations.CraeateAll();
                //var teacherEvaluations = new List<TeacherEvaluation>();

                //foreach (var usre in usersFDB)
                //{
                //    var teacherEvaluation = new TeacherEvaluation
                //    {
                //        UserId = usre.UserId,
                //        TeacherEvaluationValueOne = 0,
                //        TeacherEvaluationValueTow = 0,
                //    };
                //    teacherEvaluations.Add(teacherEvaluation);
                //}
                //await _unitOfWork.TeacherEvaluations.AddRangeAsync(teacherEvaluations);
                //await _unitOfWork.SaveAsync();

                await _unitOfWork.TeacherEvaluations.CraeateAll();
                ApiResponse7 response = new ApiResponse7();
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 response = new ApiResponse4(message: ex.Message);
                return StatusCode(500, response);
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EditTeacherEvaluationDto teacherEvaluationDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ApiResponse2 response2 = new();
                    return BadRequest(response2);
                }
                if (teacherEvaluationDto == null)
                {
                    ApiResponse2 response1 = new();
                    return BadRequest(response1);
                }
                var teacherEvaluationFDB = await _unitOfWork.TeacherEvaluations.GetByTeacherIdAsync(id);

                teacherEvaluationFDB.TeacherEvaluationCounter = teacherEvaluationFDB.TeacherEvaluationCounter + 1; 
                //int avarig = teacherEvaluationFDB.TeacherEvaluationCounter;
                teacherEvaluationFDB.TeacherEvaluationValueTow = teacherEvaluationFDB.TeacherEvaluationValueTow + teacherEvaluationDto.TeacherEvaluationValueTow;
                teacherEvaluationFDB.TeacherEvaluationValueOne = teacherEvaluationFDB.TeacherEvaluationValueOne + teacherEvaluationDto.TeacherEvaluationValueOne;
                //teacherEvaluationFDB.TeacherEvaluationValueOne= totalone/ avarig;
                //teacherEvaluationFDB.TeacherEvaluationValueTow = totaltow / avarig;

                //_mapper.Map(teacherEvaluationDto, teacherEvaluationFDB);
                //_unitOfWork.Solutions.Update(solution);
                await _unitOfWork.SaveAsync();
                ApiResponse5<EditTeacherEvaluationDto> response = new(teacherEvaluationDto);
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
