using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WhereToGoTonight.DTOs.Recommendations;
using WhereToGoTonight.Interfaces.User;

namespace WhereToGoTonight.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecommendationsController : ControllerBase
    {
        private readonly IRecommendationsService _recommendationsService;

        public RecommendationsController(IRecommendationsService recommendationsService)
        {
            _recommendationsService = recommendationsService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetRecommendations([FromQuery] string location, [FromQuery] double maxDistance = 5)
        {
            var userId = User.FindFirst("userId")?.Value;
            if (string.IsNullOrEmpty(userId)) return Unauthorized("User ID is missing in the token.");

            var result = await _recommendationsService.GetRecommendationsAsync(location, maxDistance, userId);

            if (!result.Succeeded)
            {
                return BadRequest(new { result.ErrorMessage });
            }

            return Ok(result.Data);
        }
    }
}
