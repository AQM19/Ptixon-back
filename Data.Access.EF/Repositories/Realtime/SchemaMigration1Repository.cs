using Data.Access.EF.Context;
using Data.Access.Entities.Realtime;
using Data.Access.Interfaces.Repositories.Realtime;
using Microsoft.EntityFrameworkCore;

namespace Data.Access.EF.Repositories.Realtime
{
    public class SchemaMigration1Repository : Repository<SchemaMigration1>, ISchemaMigration1Repository
    {
        public SchemaMigration1Repository(DbContext context) : base(context)
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
