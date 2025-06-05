using Data.Access.EF.Context;
using Data.Access.Entities.Auth;
using Data.Access.Interfaces.Repositories.Auth;
using Microsoft.EntityFrameworkCore;

namespace Data.Access.EF.Repositories.Auth
{
    public class MfaFactorRepository : Repository<MfaFactor>, IMfaFactorRepository
    {
        public MfaFactorRepository(DbContext context) : base(context)
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
