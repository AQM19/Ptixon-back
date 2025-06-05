using Data.Access.EF.Context;
using Data.Access.Entities.Storage;
using Data.Access.Interfaces.Repositories.Storage;
using Microsoft.EntityFrameworkCore;

namespace Data.Access.EF.Repositories.Storage
{
    public class MigrationRepository : Repository<Migration>, IMigrationRepository
    {
        public MigrationRepository(DbContext context) : base(context)
        {
        }
        private ApplicationDbContext ApplicationDbContext
        {
            get
            {
                return (ApplicationDbContext)_context;
            }
        }
    }
}
