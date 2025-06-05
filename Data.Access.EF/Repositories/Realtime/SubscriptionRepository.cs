using Data.Access.EF.Context;
using Data.Access.Entities.Realtime;
using Data.Access.Interfaces.Repositories.Realtime;
using Microsoft.EntityFrameworkCore;

namespace Data.Access.EF.Repositories.Realtime
{
    public class SubscriptionRepository : Repository<Subscription>, ISubscriptionRepository
    {
        public SubscriptionRepository(DbContext context) : base(context)
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
