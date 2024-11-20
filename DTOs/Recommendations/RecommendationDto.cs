namespace WhereToGoTonight.DTOs.Recommendations
{
    public class RecommendationDto
    {
        public int Id { get; set; }          // The unique identifier of the place
        public string Name { get; set; }    // The name of the recommended place
        public string Type { get; set; }    // The type of the place (e.g., cafe, park)
        public string Address { get; set; } // The address of the recommended place
        public double Latitude { get; set; } // The latitude of the recommended place
        public double Longitude { get; set; } // The longitude of the recommended place
        public double Rating { get; set; }   // The average rating of the recommended place
        public double Distance { get; set; } // The calculated distance from the user
    }
}
