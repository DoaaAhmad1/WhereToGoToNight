using WhereToGoTonight.DTOs.Common;
using WhereToGoTonight.DTOs.Places;
using WhereToGoTonight.Models;

namespace WhereToGoTonight.Interfaces.Shaired
{
    public interface IPlacesService
    {
        Task<Result<PaginatedList<Place>>> GetPaginatedPlacesAsync(int pageNumber = 1, int pageSize = 10);
        Task<Result<Place>> AddPlaceAsync(CreatePlaceDto model);
        Task<Result<Place>> UpdatePlaceAsync(int id, CreatePlaceDto model);
        Task<Result<string>> DeletePlaceAsync(int id);
    }
}
