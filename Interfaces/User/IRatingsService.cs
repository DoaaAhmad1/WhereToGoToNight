using WhereToGoTonight.DTOs.Places;
using WhereToGoTonight.DTOs.Common;

namespace WhereToGoTonight.Interfaces.User
{
    public interface IRatingsService
    {
        Task<Result<string>> AddRatingAsync(RatePlaceDto model, string userId);
    }
}
