using Data.Access.EF.Context;
using Data.Access.Entities.Storage;
using Data.Access.Interfaces.Repositories.Storage;
using Microsoft.EntityFrameworkCore;

namespace Data.Access.EF.Repositories.Storage
{
    public class S3MultipartUploadPartRepository : Repository<S3MultipartUploadPart>, IS3MultipartUploadPartRepository
    {
        public S3MultipartUploadPartRepository(DbContext context) : base(context)
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
