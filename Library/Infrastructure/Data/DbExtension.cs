using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Infrastructure.Data;

public static class DbExtension
{
    public static IServiceCollection AddLibraryDbContext(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddDbContext<OnlineLibDbContext>(
            options =>
                options.UseSqlServer(configuration
                    .GetConnectionString("OnlineLibDBConnectionString"))
        );
        return services;
    }
}