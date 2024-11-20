using WhereToGoTonight.DTOs.Auth;
using WhereToGoTonight.DTOs.Common;

namespace WhereToGoTonight.Interfaces.Admin
{
    public interface IAdminAuthService
    {
        Task<Result<string>> CreateAdminAsync(RegisterDto model);
    }
}
