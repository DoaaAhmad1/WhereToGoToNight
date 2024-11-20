using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WhereToGoTonight.DTOs.Common;
using WhereToGoTonight.Interfaces.Admin;

namespace WhereToGoTonight.Services.Admin
{
    public class RolesService : IRolesService
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesService(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<Result<IEnumerable<string>>> GetAllRolesAsync()
        {
            try
            {
                var roles = await _roleManager.Roles.Select(r => r.Name).ToListAsync();
                return Result<IEnumerable<string>>.Success(roles);
            }
            catch (Exception ex)
            {
                return Result<IEnumerable<string>>.Failure($"Failed to fetch roles: {ex.Message}");
            }
        }

        public async Task<Result<string>> CreateRoleAsync(string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName))
            {
                return Result<string>.Failure("Role name cannot be empty.");
            }

            if (await _roleManager.RoleExistsAsync(roleName))
            {
                return Result<string>.Failure($"Role '{roleName}' already exists.");
            }

            try
            {
                var result = await _roleManager.CreateAsync(new IdentityRole(roleName));
                if (result.Succeeded)
                {
                    return Result<string>.Success($"Role '{roleName}' created successfully.");
                }

                return Result<string>.Failure("Failed to create role.");
            }
            catch (Exception ex)
            {
                return Result<string>.Failure($"Failed to create role: {ex.Message}");
            }
        }

        public async Task<Result<string>> DeleteRoleAsync(string roleName)
        {
            var role = await _roleManager.FindByNameAsync(roleName);
            if (role == null)
            {
                return Result<string>.Failure($"Role '{roleName}' not found.");
            }

            try
            {
                var result = await _roleManager.DeleteAsync(role);
                if (result.Succeeded)
                {
                    return Result<string>.Success($"Role '{roleName}' deleted successfully.");
                }

                return Result<string>.Failure("Failed to delete role.");
            }
            catch (Exception ex)
            {
                return Result<string>.Failure($"Failed to delete role: {ex.Message}");
            }
        }
    }
}
