using WhereToGoTonight.Data;
using WhereToGoTonight.DTOs.Places;
using WhereToGoTonight.Models;
using Microsoft.EntityFrameworkCore;
using WhereToGoTonight.DTOs.Common;
using WhereToGoTonight.Interfaces.User;

namespace WhereToGoTonight.Services.User
{
    public class RatingsService : IRatingsService
    {
        private readonly ApplicationDbContext _context;

        public RatingsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result<string>> AddRatingAsync(RatePlaceDto model, string userId)
        {
            var place = await _context.Places.FirstOrDefaultAsync(p => p.Id == model.PlaceId);
            if (place == null) return Result<string>.Failure("Place not found.");

            var existingRating = await _context.Ratings.FirstOrDefaultAsync(r => r.PlaceId == model.PlaceId && r.UserId == userId);
            if (existingRating != null) return Result<string>.Failure("You have already rated this place.");

            var rating = new Rating
            {
                UserId = userId,
                PlaceId = model.PlaceId,
                UserRating = model.UserRating
            };

            // Update place rating
            place.Rating = (place.Rating * place.RatedByCount + model.UserRating) / (place.RatedByCount + 1);
            place.RatedByCount++;

            _context.Ratings.Add(rating);

            try
            {
                await _context.SaveChangesAsync();
                return Result<string>.Success("Rating added successfully.");
            }
            catch (Exception ex)
            {
                return Result<string>.Failure($"Failed to add rating: {ex.Message}");
            }
        }
    }
}
