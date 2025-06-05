using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Access.EF.Extensions;
using Data.Access.Entities.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Access.EF.EntityConfig.Storage
{
    public class S3MultipartUploadConfig : IEntityTypeConfiguration<S3MultipartUpload>
    {
        public void Configure(EntityTypeBuilder<S3MultipartUpload> builder)
        {
            builder.HasKey(e => e.Id).HasName("s3_multipart_uploads_pkey");

            builder.ToTable("s3_multipart_uploads", schema: nameof(Schemes.storage));

            builder.HasIndex(e => new { e.BucketId, e.Key, e.CreatedAt }, "idx_multipart_uploads_list").UseCollation(new[] { null, "C", null });

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.BucketId).HasColumnName("bucket_id");
            builder.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            builder.Property(e => e.InProgressSize)
                .HasDefaultValue(0L)
                .HasColumnName("in_progress_size");
            builder.Property(e => e.Key)
                .UseCollation("C")
                .HasColumnName("key");
            builder.Property(e => e.OwnerId).HasColumnName("owner_id");
            builder.Property(e => e.UploadSignature).HasColumnName("upload_signature");
            builder.Property(e => e.UserMetadata)
                .HasColumnType("jsonb")
                .HasColumnName("user_metadata");
            builder.Property(e => e.Version).HasColumnName("version");

            builder.HasOne(d => d.Bucket).WithMany(p => p.S3MultipartUploads)
                .HasForeignKey(d => d.BucketId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("s3_multipart_uploads_bucket_id_fkey");
        }
    }
}
