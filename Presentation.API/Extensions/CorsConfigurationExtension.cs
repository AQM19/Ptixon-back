namespace Presentation.API.Extensions
{
    public static class CorsConfigurationExtension
    {
        public static IServiceCollection AddCorsConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            string[]? origins = configuration.GetSection("OriginCors").Get<string[]>();

            if (origins == null || origins.Length == 0)
            {
                throw new InvalidOperationException("La configuración de CORS 'OriginCors' no está presente o está vacía.");
            }

            services.AddCors(options =>
            {
                options.AddPolicy("StrictOrigin",
                    builder =>
                    {
                        builder.WithOrigins(origins)
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .SetIsOriginAllowed((host) => true)
                        .AllowCredentials();
                    });
            });

            return services;
        }
    }
}
