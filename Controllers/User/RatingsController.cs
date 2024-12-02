using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WhereToGoTonight.DTOs.Places;
using WhereToGoTonight.Interfaces.User;

namespace WhereToGoTonight.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingsController : ControllerBase
    {
        private readonly IRatingsService _ratingsService;

        public RatingsController(IRatingsService ratingsService)
        {
            _ratingsService = ratingsService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddRating([FromBody] RatePlaceDto model)
        {
            var userId = User.FindFirst("userId")?.Value;
            if (string.IsNullOrEmpty(userId)) return Unauthorized("User ID is missing in the token.");

            var result = await _ratingsService.AddRatingAsync(model, userId);

            if (!result.Succeeded)
            {
                return BadRequest(new { result.ErrorMessage });
            }

            return Ok(new { result.Data });
        }
        [HttpGet("place/{placeId}/average")]
        public async Task<IActionResult> GetAverageRatingForPlace(int placeId)
        {
            var result = await _ratingsService.GetAverageRatingForPlaceAsync(placeId);
            if (!result.Succeeded)
                return BadRequest(new { result.ErrorMessage });

            return Ok(new { averageRating = result.Data });
        }
    }
}
