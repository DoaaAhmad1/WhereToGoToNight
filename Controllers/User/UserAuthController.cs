using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WhereToGoTonight.DTOs.Auth;
using WhereToGoTonight.Interfaces.User;

namespace WhereToGoTonight.Controllers.User
{
    [Route("api/user-auth")]
    [ApiController]
    public class UserAuthController : ControllerBase
    {
        private readonly IUserAuthService _userAuthService;

        public UserAuthController(IUserAuthService userAuthService)
        {
            _userAuthService = userAuthService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto model)
        {
            var result = await _userAuthService.RegisterAsync(model);
            if (!result.Succeeded)
            {
                return BadRequest(new { result.ErrorMessage, result.Errors });
            }

            return Ok(new { result.Data });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            var result = await _userAuthService.LoginAsync(model);
            if (!result.Succeeded)
            {
                return Unauthorized(new { result.ErrorMessage });
            }

            return Ok(new { token = result.Data });
        }
    }
}
