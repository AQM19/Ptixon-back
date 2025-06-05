using Data.Access.EF.Context;
using Data.Access.EF.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Presentation.API.Extensions
{
    public static class MigrationsAndSeedingDDBB
    {
        public static void CheckMigrationsAndSeedDB(this IApplicationBuilder app)
        {
            using (IServiceScope serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>())
                {
                    if(context != null)
                    {
                        context.Migrate();
                        context.Seed();
                    }
                }
            }
        }

        private static void Migrate(this ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
            if(context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
        }

        private static void Seed(this ApplicationDbContext context)
        {
            DbInitializer.Initialize(context);
        }
    }
}
