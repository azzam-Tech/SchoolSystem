using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SchoolSystem.DAL.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SchoolSystem.Api.Controllers
{
    public class UserLginModel
    {

        public string UsreName { get; set; }
        public string Password { get; set; }
    }
    //public class x
    //{
    //    public string UsreName { get; set; }
    //    public string Password { get; set; }
    //    public string Role { get; set; }
    //}

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        protected AppDbContext _context;
        public AuthController(AppDbContext context)
        {
            _context = context;
        }
        [HttpPost("authenticate")]
        public async Task<IActionResult> Login(UserLginModel userLginModel)
        {

            if (ModelState.IsValid)
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == userLginModel.UsreName && x.Userpassword == userLginModel.Password);
                if (user != null)
                {
                    var role = await _context.Users
                            .Include(c => c.Role)
                            .SingleOrDefaultAsync(s => s.UserName == userLginModel.UsreName);

                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                        // role is Admin for testing
                        new Claim(ClaimTypes.Role, "Admin"),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                    };


                    var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("sz8eI7OdHBrjrIo8j9nTW/rQyO1OvY0pAQ2wDKQZw/0="));
                    var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);


                    var token = new JwtSecurityToken(
                        issuer: "http://localhost:7036",
                        audience: "http://localhost:7036",
                        claims: claims,
                        expires: DateTime.UtcNow.AddMinutes(30),
                        signingCredentials: signingCredentials
                        );
                    var _token = new JwtSecurityTokenHandler().WriteToken(token);
                    //var _token = new
                    //{
                    //    token = new JwtSecurityTokenHandler().WriteToken(token),
                    //    expires = token.ValidTo,
                    //};


                    return Ok(_token);

                }
                return BadRequest(new { message = "Username or password is incorrect" });


            }
            return BadRequest(ModelState);



        }

        [Authorize]
        [HttpGet("done")]
        public string done()
        {
            return "done";
        }
    }
}
