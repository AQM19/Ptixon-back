
using Presentation.VMs.Helpers;

namespace Presentation.API.Extensions
{
    public static class CustomParamsAppAplicationExtension
    {
        public static IServiceCollection AddCustomParamsApplicationConfiguration(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<AppSecurityConfig>(config.GetSection("Security"));
            services.Configure<AppEmailConfig>(config.GetSection("Email"));
            services.Configure<AppEnvironmentConfig>(config.GetSection("Environment"));
            services.Configure<AppJwtConfig>(config.GetSection("Jwt"));
            services.Configure<AppRateLimitingConfig>(config.GetSection("RateLimiting"));
            services.Configure<AppOriginCorsConfig>(config.GetSection("OriginCors"));

            return services;
        }
    }
}
