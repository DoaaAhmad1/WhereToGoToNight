using Microsoft.AspNetCore.Identity;
using WhereToGoTonight.DTOs.Auth;
using WhereToGoTonight.Interfaces.Admin;
using WhereToGoTonight.Models;
using WhereToGoTonight.DTOs.Common;

namespace WhereToGoTonight.Services.Admin
{
    public class AdminAuthService : IAdminAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminAuthService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<Result<string>> CreateAdminAsync(RegisterDto model)
        {
            if (!await _roleManager.RoleExistsAsync("Admin"))
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            var user = new ApplicationUser { UserName = model.Username, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => new ValidationError { Name = e.Code, Error = e.Description });
                return Result<string>.Failure(errors, "Admin creation failed.");
            }

            await _userManager.AddToRoleAsync(user, "Admin");
            return Result<string>.Success("Admin created successfully.");
        }
    }
}
