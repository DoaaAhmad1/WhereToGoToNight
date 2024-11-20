using Microsoft.AspNetCore.Identity;
using WhereToGoTonight.Models;

namespace WhereToGoTonight.Data
{
    public static class SeedData
    {
        public static async Task SeedAdminAndRolesAsync(IServiceProvider serviceProvider)
        {
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            // Fetch admin credentials and roles from appsettings.json
            var adminEmail = configuration["SeedAdmin:Email"];
            var adminPassword = configuration["SeedAdmin:Password"];
            var roles = configuration.GetSection("SeedAdmin:Roles").Get<string[]>();

            // Step 1: Ensure all roles exist
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    var result = await roleManager.CreateAsync(new IdentityRole(role));
                    if (!result.Succeeded)
                    {
                        Console.WriteLine($"Failed to create role '{role}': {string.Join(", ", result.Errors.Select(e => e.Description))}");
                    }
                }
            }

            // Step 2: Ensure the admin user exists
            var existingAdmin = await userManager.FindByEmailAsync(adminEmail);
            if (existingAdmin == null)
            {
                var adminUser = new ApplicationUser
                {
                    UserName = "admin",
                    Email = adminEmail
                };

                var result = await userManager.CreateAsync(adminUser, adminPassword);
                if (result.Succeeded)
                {
                    Console.WriteLine("Admin user created successfully.");
                    existingAdmin = adminUser;
                }
                else
                {
                    Console.WriteLine($"Failed to create admin user: {string.Join(", ", result.Errors.Select(e => e.Description))}");
                    return;
                }
            }
            else
            {
                Console.WriteLine("Admin user already exists.");
            }

            // Step 3: Assign the "Admin" role to the admin user
            if (!await userManager.IsInRoleAsync(existingAdmin, "Admin"))
            {
                var result = await userManager.AddToRoleAsync(existingAdmin, "Admin");
                if (result.Succeeded)
                {
                    Console.WriteLine("Admin role assigned to admin user.");
                }
                else
                {
                    Console.WriteLine($"Failed to assign admin role: {string.Join(", ", result.Errors.Select(e => e.Description))}");
                }
            }
        }
    }
}
