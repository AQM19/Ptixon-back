using Microsoft.AspNetCore.Authentication.Cookies;

namespace Presentation.API.Extensions
{
    public static class AuthenticationCofigurationExtension
    {
        public static IServiceCollection AddAuthenticationConfigurationExtension(this IServiceCollection services, IConfiguration config)
        {

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;

            })
            .AddCookie();

            services.AddControllersWithViews();

            return services;
        }
    }
}
