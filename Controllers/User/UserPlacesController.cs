using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WhereToGoTonight.Interfaces.Shaired;

namespace WhereToGoTonight.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserPlacesController : ControllerBase
    {
        private readonly IPlacesService _placesService;

        public UserPlacesController(IPlacesService placesService)
        {
            _placesService = placesService;
        }

        [HttpGet]
        [Authorize] // Authorized for logged-in users
        public async Task<IActionResult> GetAllPlaces([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var result = await _placesService.GetPaginatedPlacesAsync(pageNumber, pageSize);

            if (!result.Succeeded)
            {
                return BadRequest(new { result.ErrorMessage });
            }

            return Ok(result.Data);
        }


    }
}
