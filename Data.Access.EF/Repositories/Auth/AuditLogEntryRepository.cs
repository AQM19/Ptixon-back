using Data.Access.EF.Context;
using Data.Access.Entities.Auth;
using Data.Access.Interfaces.Repositories.Auth;
using Microsoft.EntityFrameworkCore;

namespace Data.Access.EF.Repositories.Auth
{
    public class AuditLogEntryRepository : Repository<AuditLogEntry>, IAuditLogEntryRepository
    {
        public AuditLogEntryRepository(DbContext context) : base(context)
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
