namespace WhereToGoTonight.DTOs.Places
{
    public class PlaceDto
    {
        public int Id { get; set; }          // The unique identifier of the place
        public string Name { get; set; }    // The name of the place
        public string Type { get; set; }    // The type of the place (e.g., cafe, park)
        public string Address { get; set; } // The address of the place
        public double Latitude { get; set; } // The latitude of the place
        public double Longitude { get; set; } // The longitude of the place
        public double Rating { get; set; }
    }
}
