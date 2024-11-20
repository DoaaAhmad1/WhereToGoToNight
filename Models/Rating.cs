using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WhereToGoTonight.Models
{
    public class Rating
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; } // Reference to Identity User

        [Required]
        public int PlaceId { get; set; }

        [ForeignKey("PlaceId")]
        public virtual Place Place { get; set; } // Reference to Place

        [Required]
        [Range(1, 5)]
        public int UserRating { get; set; }
    }
}
