using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WhereToGoTonight.Interfaces.Admin;

namespace WhereToGoTonight.Controllers.Admain
{
    [ApiController]
    [Route("api/roles")]
    [Authorize(Roles = "Admin")]
    public class RolesController : ControllerBase
    {
        private readonly IRolesService _rolesService;

        public RolesController(IRolesService rolesService)
        {
            _rolesService = rolesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            var result = await _rolesService.GetAllRolesAsync();
            if (!result.Succeeded)
            {
                return BadRequest(new { result.ErrorMessage });
            }

            return Ok(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            var result = await _rolesService.CreateRoleAsync(roleName);
            if (!result.Succeeded)
            {
                return BadRequest(new { result.ErrorMessage });
            }

            return Ok(new { result.Data });
        }

        [HttpDelete("{roleName}")]
        public async Task<IActionResult> DeleteRole(string roleName)
        {
            var result = await _rolesService.DeleteRoleAsync(roleName);
            if (!result.Succeeded)
            {
                return BadRequest(new { result.ErrorMessage });
            }

            return Ok(new { result.Data });
        }
    }
}
