using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WhereToGoTonight.DTOs.Auth;
using WhereToGoTonight.Interfaces.Admin;

namespace WhereToGoTonight.Controllers.Admain
{
    [Route("api/admin-auth")]
    [ApiController]
    [Authorize(Roles = "Admin")] // Apply admin-level authorization
    public class AdminAuthController : ControllerBase
    {
        private readonly IAdminAuthService _adminAuthService;

        public AdminAuthController(IAdminAuthService adminAuthService)
        {
            _adminAuthService = adminAuthService;
        }

        [HttpPost("create-admin")]
        public async Task<IActionResult> CreateAdmin([FromBody] RegisterDto model)
        {
            var result = await _adminAuthService.CreateAdminAsync(model);
            if (!result.Succeeded)
            {
                return BadRequest(new { result.ErrorMessage, result.Errors });
            }

            return Ok(new { result.Data });
        }
    }
}
