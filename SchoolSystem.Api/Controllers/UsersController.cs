using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DAL.UnitOfWork;
using SchoolSystem.BLL.DTOs;
using SchoolSystem.DAL.Entites;
using SchoolSystem.DAL.Models;
using AutoMapper;
using SchoolSystem.BLL.DTOs.Students;
using SchoolSystem.BLL.DTOs.PostDto;
using SchoolSystem.BLL.DTOs.GetDto;
using SchoolSystem.BLL.DTOs.EditDto;

namespace SchoolSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        //create a new User in the database using the UserlDto , try catch block  and check the model state of the UserlDto whit usng the Response class

        //inject the UnitOfWork
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UsersController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var usersFDB = await _unitOfWork.Users.GetAllAsync();
                var usersDTO = _mapper.Map<IEnumerable<GetUserDto>>(usersFDB);
                ApiResponse6<IEnumerable<GetUserDto>> response = new(usersDTO);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 reaponse = new(message: ex.Message);
                return Ok(reaponse);
            }
        }


        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] PostUserDto postUserDto )
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ApiResponse2 response2 = new();
                    return BadRequest(response2);
                }
                if (postUserDto == null)
                {
                    ApiResponse2 response1 = new();
                    return BadRequest(response1);
                }

                var userTDB = _mapper.Map<User>(postUserDto);
                userTDB.Userpassword = "123456789";
                await _unitOfWork.Users.AddAsync(userTDB);
                await _unitOfWork.SaveAsync();
                ApiResponse5<PostUserDto> response = new(postUserDto);
                return Ok(response);


            }
            catch (System.Exception ex)
            {
                ApiResponse4 response = new(message: ex.Message);
                return StatusCode(500, response);
            }
        }


        [HttpPost("CreateRangeUser")]
        public async Task<IActionResult> CreateRangeUser([FromBody] IEnumerable<PostUserDto> postUserDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ApiResponse2 response2 = new();
                    return BadRequest(response2);
                }
                if (postUserDto == null)
                {
                    ApiResponse2 response1 = new();
                    return BadRequest(response1);
                }

                var users = _mapper.Map<IEnumerable<User>>(postUserDto);  
                foreach (var user in users)
                {
                    user.Userpassword = "123456789";
                }
                await _unitOfWork.Users.AddRangeAsync(users);
                await _unitOfWork.SaveAsync();
                ApiResponse5<IEnumerable<PostUserDto>> response = new(postUserDto);
                return Ok(response);


            }
            catch (System.Exception ex)
            {
                ApiResponse4 response = new(message: ex.Message);
                return StatusCode(500, response);
            }
        }



       


        //[HttpGet("GetByRoleId/{id}")]
        //public IActionResult GetByRoleId(int id)
        //{
        //    try
        //    {
        //        var users = _unitOfWork.Users.GetByRoleId(id);
        //        if (users == null)
        //        {
        //            ApiResponse3 reaponse = new();
        //            return NotFound(reaponse);
        //        }
        //        //var userDto = _mapper.Map<IEnumerable<GetUserDto>>(users);
        //        var userDto = new List<GetUserDto>();   
        //        foreach (var user in users)
        //        {
        //            var d = new GetUserDto
        //            {
        //                RoleId = user.RoleId,
        //                UserName = user.UserName, 
        //                Userpassword = user.Userpassword 
        //            };
        //            userDto.Add(d);
        //        }

        //        ApiResponse6<IEnumerable< GetUserDto>> response = new(userDto);
        //        return Ok(response);

        //    }
        //    catch (System.Exception ex)
        //    {
        //        ApiResponse4 response = new(message: ex.Message);
        //        return StatusCode(500, response);
        //    }
        //}

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EditUserDto userDto)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    ApiResponse2 response2 = new();
                    return BadRequest(response2);
                }
                if (userDto == null)
                {
                    ApiResponse2 response1 = new();
                    return BadRequest(response1);
                }
                var userFDB = await _unitOfWork.Users.GetByIdAsync(id);
                if (userFDB == null)
                {
                    ApiResponse3 response3 = new();
                    return NotFound(response3);
                }
                _mapper.Map(userDto, userFDB);
                await _unitOfWork.SaveAsync();
                ApiResponse5<EditUserDto> response = new(userDto);
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
                var userFDB = await _unitOfWork.Users.GetByIdAsync(id);
                if (userFDB == null)
                {
                    ApiResponse3 response3 = new();
                    return NotFound(response3);
                }
                _unitOfWork.Users.Delete(userFDB);
                await _unitOfWork.SaveAsync();
                var userDto = _mapper.Map<GetUserDto>(userFDB);
                ApiResponse6<GetUserDto> response = new(userDto);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 response = new(message: ex.Message);
                return StatusCode(500, response);
            }
        }

        //a method to delete a range of users from the database using the UserDto and the Response class and the try catch block



        [HttpDelete("deleteRange")]
        public async Task<IActionResult> DeleteRange([FromBody] List<int> ids)
        {
            try
            {
                var usersFDB = new List<User>();   
                foreach (int id in ids)
                {
                    var userFDB = await _unitOfWork.Users.GetByIdAsync(id);
                    usersFDB.Add(userFDB);
                }

                _unitOfWork.Users.DeleteRange(usersFDB);
                await _unitOfWork.SaveAsync();
                var userDto = _mapper.Map<IEnumerable< GetUserDto>>(usersFDB);
                ApiResponse6<IEnumerable<GetUserDto>> response = new(userDto);
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
