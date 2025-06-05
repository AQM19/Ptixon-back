using Data.Access.EF.Context;
using Data.Access.Entities.Auth;
using Data.Access.Interfaces.Repositories.Auth;
using Microsoft.EntityFrameworkCore;

namespace Data.Access.EF.Repositories.Auth
{
    public class OneTimeTokenRepository : Repository<OneTimeToken>, IOneTimeTokenRepository
    {
        public OneTimeTokenRepository(DbContext context) : base(context)
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
