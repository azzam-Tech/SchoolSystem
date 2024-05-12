using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DAL.UnitOfWork;
using SchoolSystem.BLL.DTOs;
using SchoolSystem.DAL.Entites;
using SchoolSystem.DAL.Models;
using AutoMapper;
using SchoolSystem.BLL.DTOs.Students;

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

        //create a new User in the database using the UserlDto , try catch block  and check the model state of the UserlDto whit usng the Response class
        [HttpPost]
        public IActionResult Post([FromBody] UserDto userDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new ApiResponse<object>(null)
                    {
                        Codestate = "400", // Use appropriate HTTP status code for bad request
                        message = "Validation errors occurred",
                        errors = string.Join(", ", ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)))
                    }) ;
                }
                if (userDto == null)
                {
                    return BadRequest(new ApiResponse<object>(null)
                    {
                        Codestate = "400", // Use appropriate HTTP status code for bad request
                        message = "User data is missing"
                    });
                }

                //var user = _mapper.Map<User>(userDto);

                var user = new User
                {
                    RoleId = userDto.RoleId,
                    UserName = userDto.UserName,
                    Userpassword = userDto.Userpassword,
                    Usernumber = userDto.Usernumber,
                    UserImage = userDto.UserImage,
                    IsSupervisor = userDto.IsSupervisor
                };

                _unitOfWork.Users.Add(user);
                _unitOfWork.Complete();
                return Ok(new ApiResponse<UserDto>(userDto)
                {
                    Codestate = "201", // Use appropriate HTTP status code for creation
                    message = "User created successfully",
                    Data = userDto // Assuming UserDto reflects the created user's data
                });
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new ApiResponse<object>(null)
                {
                    Codestate = "500",
                    message = "Internal server error occurred",
                    errors = ex.Message // Consider providing more specific error details if possible
                });
            }
        }

        [HttpPost("addRange")]
        public IActionResult Post([FromBody] IEnumerable<UserDto> usersDto)
        {
            try
            {
                //IEnumerable<Student> studentsfDB = _unitOfWork.Students.Add();

                List<User> users = new List<User>();
                //IEnumerable<StudentDto> studentDtos = [];

                foreach (UserDto userDto in usersDto)
                {
                    var user = new User
                    {
                        RoleId = userDto.RoleId,
                        UserName = userDto.UserName,
                        Userpassword = userDto.Userpassword,
                        Usernumber = userDto.Usernumber,
                        UserImage = userDto.UserImage,
                        IsSupervisor = userDto.IsSupervisor
                    };
                    users.Add(user);
                    
                    
                }
                _unitOfWork.Users.AddRange(users);
                _unitOfWork.Complete();

                Response<IEnumerable<User>> response = new(users);

                return Ok(response);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                string message = ex.Message;
                Response<IEnumerable<User>> response = new(null, message, error);

                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var users = _unitOfWork.Users.GetAll();
                // var userDtos = _mapper.Map<IEnumerable<UserDto>>(users);

                var userDtos = new List<UserDto>();
                foreach (var user in users)
                {
                    var userDto = new UserDto
                    {
                        RoleId = user.RoleId,
                        UserName = user.UserName,
                        Userpassword = user.Userpassword,
                        Usernumber = user.Usernumber,
                        UserImage = user.UserImage,
                        IsSupervisor = user.IsSupervisor
                    };
                    userDtos.Add(userDto);
                }

                Response<IEnumerable<UserDto>> response = new(userDtos);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                string? statusCode = ex.ToString();
                string? erorr = ex.Message;
                Response<User> response = new(null, statusCode, erorr, false);
                return Ok(response);
            }
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var user = _unitOfWork.Users.GetById(id);
                //var userDto = _mapper.Map<UserDto>(user);

                var userDto = new UserDto
                {
                    RoleId = user.RoleId,
                    UserName = user.UserName,
                    Userpassword = user.Userpassword,
                    Usernumber = user.Usernumber,
                    UserImage = user.UserImage,
                    IsSupervisor = user.IsSupervisor
                };

                Response<UserDto> response = new(userDto);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                string? statusCode = ex.ToString();
                string? erorr = ex.Message;
                Response<User> response = new(null, statusCode, erorr, false);
                return Ok(response);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UserDto userDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (userDto == null)
                {
                    return BadRequest();
                }

                //var user = _mapper.Map<User>(userDto);

                var user = new User
                {
                    RoleId = userDto.RoleId,
                    UserName = userDto.UserName,
                    Userpassword = userDto.Userpassword,
                    Usernumber = userDto.Usernumber,
                    UserImage = userDto.UserImage,
                    IsSupervisor = userDto.IsSupervisor
                };

                _unitOfWork.Users.Update(user);
                _unitOfWork.Complete();
                Response<UserDto> response = new(userDto);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                string? statusCode = ex.ToString();
                string? erorr = ex.Message;
                Response<User> response = new(null, statusCode, erorr, false);
                return Ok(response);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var user = _unitOfWork.Users.GetById(id);
                if (user == null)
                {
                    return NotFound();
                }

                _unitOfWork.Users.Delete(user);
                _unitOfWork.Complete();
                Response<UserDto> response = new(null);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                string? statusCode = ex.ToString();
                string? erorr = ex.Message;
                Response<User> response = new(null, statusCode, erorr, false);
                return Ok(response);
            }
        }

        //a method to delete a range of users from the database using the UserDto and the Response class and the try catch block
        [HttpDelete("deleteRange")]
        public IActionResult Delete([FromBody] IEnumerable<UserDto> usersDto)
        {
            try
            {
                List<User> users = new List<User>();
                foreach (UserDto userDto in usersDto)
                {
                    var user = new User
                    {
                        RoleId = userDto.RoleId,
                        UserName = userDto.UserName,
                        Userpassword = userDto.Userpassword,
                        Usernumber = userDto.Usernumber,
                        UserImage = userDto.UserImage,
                        IsSupervisor = userDto.IsSupervisor
                    };
                    users.Add(user);
                }
                _unitOfWork.Users.DeleteRange(users);
                _unitOfWork.Complete();
                Response<IEnumerable<UserDto>> response = new(usersDto);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                string? statusCode = ex.ToString();
                string? erorr = ex.Message;
                Response<User> response = new(null, statusCode, erorr, false);
                return Ok(response);
            }
        }

        //a method to delete a range of users from the database using user ids and the Response class and the try catch block
        [HttpDelete("deleteRangeByIds")]
        public IActionResult Delete([FromBody] IEnumerable<int> ids)
        {
            try
            {
                List<User> users = new List<User>();
                foreach (int id in ids)
                {
                    var user = _unitOfWork.Users.GetById(id);
                    users.Add(user);
                }
                _unitOfWork.Users.DeleteRange(users);
                _unitOfWork.Complete();
                Response<IEnumerable<User>> response = new(users);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                string? statusCode = ex.ToString();
                string? erorr = ex.Message;
                Response<User> response = new(null, statusCode, erorr, false);
                return Ok(response);
            }
        }



    }
}
