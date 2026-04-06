namespace Library.Infrastructure.Data;

public static class EnsureRoles
{
    public static async Task EnsureRolesSeededAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        await RoleSeeder.SeedRolesAsync(scope.ServiceProvider);
    }
}