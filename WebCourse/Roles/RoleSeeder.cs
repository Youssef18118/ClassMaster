using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

public static class RoleSeeder
{
    public static async Task SeedRolesAndAdminUser(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

        // Define the roles
        string[] roleNames = { "Admin", "User" };

        foreach (var roleName in roleNames)
        {
            // Check if the role already exists, if not, create it
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }

        // Create an admin user if it doesn't already exist
        var adminEmail = "admin@domain.com";
        var adminPassword = "Admin@1234"; // Use a strong password

        var adminUser = await userManager.FindByEmailAsync(adminEmail);

        if (adminUser == null)
        {
            adminUser = new IdentityUser
            {
                UserName = adminEmail,
                Email = adminEmail,
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(adminUser, adminPassword);

            if (result.Succeeded)
            {
                // Assign the user to the "Admin" role
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }
            else
            {
                // Handle errors if the admin user creation failed
                foreach (var error in result.Errors)
                {
                    // Log errors or take necessary actions
                    System.Console.WriteLine($"Error creating admin user: {error.Description}");
                }
            }
        }
    }
}
