using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DAL.Models;
using SchoolSystem.DAL.Services;

namespace SchoolSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        //[HttpPost("token")]
        //public async Task<IActionResult> GetTokenAsync([FromBody] TokenRequestModel model)
        //{
            
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var result = await _authService.GetTokenAsync(model);

        //    if (!result.IsAuthenticated)
        //        return BadRequest(result.Message);

        //    return Ok(result);
        //}

        [HttpPost("token")]
        public async Task<IActionResult> GetTokenAsync([FromBody] TokenRequestModel model)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var result = await _authService.GetTokenAsync(model);
                if (!result.IsAuthenticated)
                {
                    ApiResponse8 response2 = new(message: result.Message);
                    return BadRequest(response2);
                }
                ApiResponse6<AuthModel> response = new(result);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
