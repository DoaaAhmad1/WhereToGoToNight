using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WhereToGoTonight.Models
{
    public class UserPreference
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; } // Reference to Identity User

        [Required]
        [MaxLength(50)]
        public string Preference { get; set; } // e.g., cafe, park
    }
}
