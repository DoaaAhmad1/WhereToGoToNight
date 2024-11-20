using WhereToGoTonight.DTOs.Common;

namespace WhereToGoTonight.Interfaces.Admin
{
    public interface IRolesService
    {
        Task<Result<IEnumerable<string>>> GetAllRolesAsync();
        Task<Result<string>> CreateRoleAsync(string roleName);
        Task<Result<string>> DeleteRoleAsync(string roleName);
    }
}
