using Data.Access.EF.Extensions;
using Data.Access.Entities.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Access.EF.EntityConfig.Storage
{
    internal class S3MultipartUploadsPartConfig : IEntityTypeConfiguration<S3MultipartUploadPart>
    {
        public void Configure(EntityTypeBuilder<S3MultipartUploadPart> builder)
        {
            builder.HasKey(e => e.Id).HasName("s3_multipart_uploads_parts_pkey");

            builder.ToTable("s3_multipart_uploads_parts", schema: nameof(Schemes.storage));

            builder.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            builder.Property(e => e.BucketId).HasColumnName("bucket_id");
            builder.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            builder.Property(e => e.Etag).HasColumnName("etag");
            builder.Property(e => e.Key)
                .UseCollation("C")
                .HasColumnName("key");
            builder.Property(e => e.OwnerId).HasColumnName("owner_id");
            builder.Property(e => e.PartNumber).HasColumnName("part_number");
            builder.Property(e => e.Size)
                .HasDefaultValue(0L)
                .HasColumnName("size");
            builder.Property(e => e.UploadId).HasColumnName("upload_id");
            builder.Property(e => e.Version).HasColumnName("version");

            builder.HasOne(d => d.Bucket).WithMany(p => p.S3MultipartUploadsParts)
                .HasForeignKey(d => d.BucketId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("s3_multipart_uploads_parts_bucket_id_fkey");

            builder.HasOne(d => d.Upload).WithMany(p => p.S3MultipartUploadsParts)
                .HasForeignKey(d => d.UploadId)
                .HasConstraintName("s3_multipart_uploads_parts_upload_id_fkey");
        }
    }
}
