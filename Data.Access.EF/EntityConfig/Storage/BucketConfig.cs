using Data.Access.EF.Extensions;
using Data.Access.Entities.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Access.EF.EntityConfig.Storage
{
    public class BucketConfig : IEntityTypeConfiguration<Bucket>
    {
        public void Configure(EntityTypeBuilder<Bucket> builder)
        {
            builder.HasKey(e => e.Id).HasName("buckets_pkey");

            builder.ToTable("buckets", schema: nameof(Schemes.storage));

            builder.HasIndex(e => e.Name, "bname").IsUnique();

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.AllowedMimeTypes).HasColumnName("allowed_mime_types");
            builder.Property(e => e.AvifAutodetection)
                .HasDefaultValue(false)
                .HasColumnName("avif_autodetection");
            builder.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            builder.Property(e => e.FileSizeLimit).HasColumnName("file_size_limit");
            builder.Property(e => e.Name).HasColumnName("name");
            builder.Property(e => e.Owner)
                .HasComment("Field is deprecated, use owner_id instead")
                .HasColumnName("owner");
            builder.Property(e => e.OwnerId).HasColumnName("owner_id");
            builder.Property(e => e.Public)
                .HasDefaultValue(false)
                .HasColumnName("public");
            builder.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
        }
    }
}
