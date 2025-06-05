using Data.Access.EF.Context;
using Data.Access.Entities.Auth;
using Data.Access.Interfaces.Repositories.Auth;
using Microsoft.EntityFrameworkCore;

namespace Data.Access.EF.Repositories.Auth
{
    public class IdentityRepository : Repository<Identity>, IIdentityRepository
    {
        public IdentityRepository(DbContext context) : base(context)
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
