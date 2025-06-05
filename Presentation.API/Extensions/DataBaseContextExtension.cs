using Data.Access.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace Presentation.API.Extensions
{
    public static class DataBaseContextExtension
    {
        public static IServiceCollection AddDataBaseContextConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(
            options => options.UseNpgsql( // Npgsql to Postgre
                configuration.GetConnectionString("DefaultConnection"),
                    builder =>
                    {
                        builder.MigrationsAssembly("Data.Access.EF");
                    }
                ));

            return services;
        }
    }
}
