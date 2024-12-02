using Microsoft.EntityFrameworkCore;
using WhereToGoTonight.Data;
using WhereToGoTonight.DTOs.Common;
using WhereToGoTonight.DTOs.Places;
using WhereToGoTonight.Interfaces.Shaired;
using WhereToGoTonight.Models;

namespace WhereToGoTonight.Services.Shaired
{
    public class PlacesService : IPlacesService
    {
        private readonly ApplicationDbContext _context;

        public PlacesService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result<PaginatedList<Place>>> GetPaginatedPlacesAsync(int pageNumber, int pageSize)
        {
            try
            {
                var query = _context.Places.AsQueryable();
                var paginatedPlaces = await PaginatedList<Place>.CreateAsync(query, pageNumber, pageSize);
                return Result<PaginatedList<Place>>.Success(paginatedPlaces);
            }
            catch (Exception ex)
            {
                return Result<PaginatedList<Place>>.Failure($"Failed to fetch places: {ex.Message}");
            }
        }

        public async Task<Result<Place>> AddPlaceAsync(CreatePlaceDto model)
        {
            var place = new Place
            {
                Name = model.Name,
                Type = model.Type,
                Address = model.Address,
                Latitude = model.Latitude,
                Longitude = model.Longitude
            };

            try
            {
                _context.Places.Add(place);
                await _context.SaveChangesAsync();
                return Result<Place>.Success(place);
            }
            catch (Exception ex)
            {
                return Result<Place>.Failure($"Failed to add place: {ex.Message}");
            }
        }

        public async Task<Result<Place>> UpdatePlaceAsync(int id, CreatePlaceDto model)
        {
            var place = await _context.Places.FirstOrDefaultAsync(p => p.Id == id);
            if (place == null) return Result<Place>.Failure("Place not found.");

            place.Name = model.Name;
            place.Type = model.Type;
            place.Address = model.Address;
            place.Latitude = model.Latitude;
            place.Longitude = model.Longitude;

            try
            {
                await _context.SaveChangesAsync();
                return Result<Place>.Success(place);
            }
            catch (Exception ex)
            {
                return Result<Place>.Failure($"Failed to update place: {ex.Message}");
            }
        }

        public async Task<Result<string>> DeletePlaceAsync(int id)
        {
            var place = await _context.Places.FirstOrDefaultAsync(p => p.Id == id);
            if (place == null) return Result<string>.Failure("Place not found.");

            try
            {
                _context.Places.Remove(place);
                await _context.SaveChangesAsync();
                return Result<string>.Success("Place deleted successfully.");
            }
            catch (Exception ex)
            {
                return Result<string>.Failure($"Failed to delete place: {ex.Message}");
            }
        }

       }
}
