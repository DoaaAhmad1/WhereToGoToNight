using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WhereToGoTonight.DTOs.Places;
using WhereToGoTonight.Interfaces.Shaired;

namespace WhereToGoTonight.Controllers.Admain
{

    [Route("api/admin-places")]
    [ApiController]
    
    public class AdminPlacesController : ControllerBase
    {
        private readonly IPlacesService _placesService;

        public AdminPlacesController(IPlacesService placesService)
        {
            _placesService = placesService;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddPlace([FromBody] CreatePlaceDto model)
        {
            var result = await _placesService.AddPlaceAsync(model);
            if (!result.Succeeded)
                return BadRequest(new { result.ErrorMessage });

            return Ok(result.Data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlace(int id, [FromBody] CreatePlaceDto model)
        {
            var result = await _placesService.UpdatePlaceAsync(id, model);
            if (!result.Succeeded)
                return BadRequest(new { result.ErrorMessage });

            return Ok(result.Data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlace(int id)
        {
            var result = await _placesService.DeletePlaceAsync(id);
            if (!result.Succeeded)
                return BadRequest(new { result.ErrorMessage });

            return Ok(result.Data);
        }
    }
}
