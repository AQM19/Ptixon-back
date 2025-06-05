using Data.Access.EF.Context;


namespace Data.Access.EF.Extensions
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext dbContext)
        {
            ArgumentNullException.ThrowIfNull(dbContext, nameof(dbContext));
            dbContext.Database.EnsureCreated();

            // Check if the database is already seeded
            // Seed database if necessary

            dbContext.SaveChanges();

        }

    }
}
