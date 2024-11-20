using WhereToGoTonight.Data;
using WhereToGoTonight.DTOs.Recommendations;
using Microsoft.EntityFrameworkCore;
using WhereToGoTonight.DTOs.Common;
using WhereToGoTonight.Interfaces.User;

namespace WhereToGoTonight.Services.User
{
    public class RecommendationsService : IRecommendationsService
    {
        private readonly ApplicationDbContext _context;

        public RecommendationsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result<IEnumerable<RecommendationDto>>> GetRecommendationsAsync(string location, double maxDistance, string userId)
        {
            try
            {
                var userPreferences = await _context.UserPreferences
                    .Where(up => up.UserId == userId)
                    .Select(up => up.Preference)
                    .ToListAsync();

                if (!userPreferences.Any())
                {
                    return Result<IEnumerable<RecommendationDto>>.Failure("No preferences found for the user.");
                }

                var userLocation = location.Split(',').Select(double.Parse).ToArray();
                var userLat = userLocation[0];
                var userLng = userLocation[1];

                var recommendations = await _context.Places
                    .Where(p => userPreferences.Contains(p.Type))
                    .Select(p => new RecommendationDto
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Type = p.Type,
                        Address = p.Address,
                        Latitude = p.Latitude,
                        Longitude = p.Longitude,
                        Rating = p.Rating,
                        Distance = CalculateDistance(userLat, userLng, p.Latitude, p.Longitude)
                    })
                    .Where(r => r.Distance <= maxDistance)
                    .OrderByDescending(r => r.Rating)
                    .ThenBy(r => r.Distance)
                    .ToListAsync();

                return Result<IEnumerable<RecommendationDto>>.Success(recommendations);
            }
            catch (Exception ex)
            {
                return Result<IEnumerable<RecommendationDto>>.Failure($"Failed to fetch recommendations: {ex.Message}");
            }
        }

        private double CalculateDistance(double lat1, double lng1, double lat2, double lng2)
        {
            var r = 6371; // Radius of the Earth in km
            var dLat = (lat2 - lat1) * Math.PI / 180;
            var dLng = (lng2 - lng1) * Math.PI / 180;

            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                    Math.Cos(lat1 * Math.PI / 180) * Math.Cos(lat2 * Math.PI / 180) *
                    Math.Sin(dLng / 2) * Math.Sin(dLng / 2);

            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return r * c; // Distance in km
        }
    }
}
