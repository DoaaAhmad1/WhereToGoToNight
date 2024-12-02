namespace WhereToGoTonight.DTOs.Ratings
{
    public class RatingDto
    {
        public int Id { get; set; }         // Unique identifier for the rating
        public int PlaceId { get; set; }    // The ID of the rated place
        public string UserId { get; set; }  // The ID of the user who provided the rating
        public int UserRating { get; set; } // The rating value (e.g., 1-5)
    }

}
