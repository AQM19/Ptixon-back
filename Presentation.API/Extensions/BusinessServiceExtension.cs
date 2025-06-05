using Business.Interfaces.Auth;
using Business.Services.Auth;
using Data.Access.EF;
using Data.Access.Interfaces;

namespace Presentation.API.Extensions
{
    public static class BusinessServiceExtension
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            #region Auth
            services.AddScoped<IUserService, UserService>();
            #endregion

            return services;
        }
    }
}
