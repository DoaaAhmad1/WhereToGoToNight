using WhereToGoTonight.DTOs.Recommendations;
using WhereToGoTonight.DTOs.Common;

namespace WhereToGoTonight.Interfaces.User
{
    public interface IRecommendationsService
    {
        Task<Result<IEnumerable<RecommendationDto>>> GetRecommendationsAsync(string location, double maxDistance, string userId);
    }
}
