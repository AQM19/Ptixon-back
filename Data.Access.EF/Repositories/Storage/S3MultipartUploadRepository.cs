using Data.Access.EF.Context;
using Data.Access.Entities.Storage;
using Data.Access.Interfaces.Repositories.Storage;
using Microsoft.EntityFrameworkCore;

namespace Data.Access.EF.Repositories.Storage
{
    public class S3MultipartUploadRepository : Repository<S3MultipartUpload>, IS3MultipartUploadRepository
    {
        public S3MultipartUploadRepository(DbContext context) : base(context)
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
