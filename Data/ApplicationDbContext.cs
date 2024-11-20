using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WhereToGoTonight.Models;

namespace WhereToGoTonight.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Place> Places { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<UserPreference> UserPreferences { get; set; }
    }
}
