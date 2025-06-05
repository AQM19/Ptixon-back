using Microsoft.OpenApi.Models;

namespace Presentation.API.Extensions
{
    public static class LoggingConfigurationExtension
    {
        public static IServiceCollection AddLoggerConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" });

                OpenApiSecurityScheme securityScheme = new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };
                c.AddSecurityDefinition("Bearer", securityScheme);

                OpenApiSecurityRequirement secutiryRequirement = new OpenApiSecurityRequirement
                {
                    { securityScheme, new[] {"Bearer"} }
                };
                c.AddSecurityRequirement(secutiryRequirement);
            });

            return services;
        }
    }
}
