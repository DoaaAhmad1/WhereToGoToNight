using System.ComponentModel.DataAnnotations;

namespace WhereToGoTonight.Models
{
    public class Place
    {
        [Key]
        public int Id { get; set; } // Primary Key

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } // Place Name

        [Required]
        [MaxLength(50)]
        public string Type { get; set; } // Type of Place (e.g., cafe, park)

        [Required]
        [MaxLength(200)]
        public string Address { get; set; } // Address of the Place

        [Required]
        public double Latitude { get; set; } // Latitude for Geolocation

        [Required]
        public double Longitude { get; set; } // Longitude for Geolocation

        [Range(0, 5)]
        public double Rating { get; set; } // Average Rating (Default: 0)

        [Range(0, int.MaxValue)]
        public int RatedByCount { get; set; }
    }
}
