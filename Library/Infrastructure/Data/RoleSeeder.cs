using Library.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Infrastructure.Data;

public static class RoleSeeder
{
    public static async Task SeedRolesAsync(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();

        foreach (var role in new[] { "Admin", "Librarian", "User" })
        {
            if (!await roleManager.RoleExistsAsync(role))
                await roleManager.CreateAsync(new IdentityRole(role));
        }

        const string adminEmail = "admin@onlinelib.com";
        const string adminPassword = "Admin123!";

        if (await userManager.FindByEmailAsync(adminEmail) is null)
        {
            var admin = new AppUser
            {
                FirstName = "Farid",
                UserName = adminEmail,
                Email = adminEmail,
                PhoneNumber = "+994 050 555 99 88",
                LastName = "Abbasli",
                Address = "String",
                Birthday = new DateTime(2006, 1, 31),
                CreatedAt = DateTimeOffset.UtcNow  
            };

            var result = await userManager.CreateAsync(admin, adminPassword);
            if (result.Succeeded)
                await userManager.AddToRoleAsync(admin, "Admin");
        }
        
        const string librarianEmail = "libian@onlinelib.com";
        const string librarianPassword = "Lib4ian123!";

        if (await userManager.FindByEmailAsync(librarianEmail) is null)
        {
            var librarian = new AppUser
            {
                FirstName = "Elnur",
                UserName = librarianEmail,
                Email = librarianEmail,
                PhoneNumber = "+994 055 500 77 66",
                Address = "String",
                LastName = "Hasanov",
                Birthday = new DateTime(2006, 3, 3),
                CreatedAt = DateTimeOffset.UtcNow  
            };

            var result = await userManager.CreateAsync(librarian, librarianPassword);
            if (result.Succeeded)
                await userManager.AddToRoleAsync(librarian, "Librarian");
        }
    }
}