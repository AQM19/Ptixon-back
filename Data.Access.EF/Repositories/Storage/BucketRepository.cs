using Data.Access.EF.Context;
using Data.Access.Entities.Storage;
using Data.Access.Interfaces.Repositories.Storage;
using Microsoft.EntityFrameworkCore;

namespace Data.Access.EF.Repositories.Storage
{
    public class BucketRepository : Repository<Bucket>, IBucketRepository
    {
        public BucketRepository(DbContext context) : base(context)
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
