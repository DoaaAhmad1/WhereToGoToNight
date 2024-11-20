using WhereToGoTonight.DTOs.Auth;
using WhereToGoTonight.DTOs.Common;

namespace WhereToGoTonight.Interfaces.User
{
    public interface IUserAuthService
    {
        Task<Result<string>> RegisterAsync(RegisterDto model);
        Task<Result<string>> LoginAsync(LoginDto model);
    }
}
