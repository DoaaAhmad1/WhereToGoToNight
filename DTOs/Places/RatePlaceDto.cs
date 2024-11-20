namespace WhereToGoTonight.DTOs.Places
{
    public class RatePlaceDto
    {
        public int PlaceId { get; set; }     // Unique identifier of the place being rated
        public int UserRating { get; set; } // Rating value (1-5) given by the user
    }

}
