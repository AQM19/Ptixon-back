using Data.Access.EF.Extensions;
using Data.Access.Entities.Auth;
using Data.Access.Entities.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Access.EF.EntityConfig.Storage
{
    public class SupabaseObjectConfig : IEntityTypeConfiguration<SupabaseObject>
    {
        public void Configure(EntityTypeBuilder<SupabaseObject> builder)
        {
            builder.HasKey(e => e.Id).HasName("objects_pkey");

            builder.ToTable("objects", nameof(Schemes.storage));

            builder.HasIndex(e => new { e.BucketId, e.Name }, "bucketid_objname").IsUnique();

            builder.HasIndex(e => new { e.BucketId, e.Name }, "idx_objects_bucket_id_name").UseCollation(new[] { null, "C" });

            builder.HasIndex(e => e.Name, "name_prefix_search").HasOperators(new[] { "text_pattern_ops" });

            builder.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            builder.Property(e => e.BucketId).HasColumnName("bucket_id");
            builder.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            builder.Property(e => e.LastAccessedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("last_accessed_at");
            builder.Property(e => e.Metadata)
                .HasColumnType("jsonb")
                .HasColumnName("metadata");
            builder.Property(e => e.Name).HasColumnName("name");
            builder.Property(e => e.Owner)
                .HasComment("Field is deprecated, use owner_id instead")
                .HasColumnName("owner");
            builder.Property(e => e.OwnerId).HasColumnName("owner_id");
            builder.Property(e => e.PathTokens)
                .HasComputedColumnSql("string_to_array(name, '/'::text)", true)
                .HasColumnName("path_tokens");
            builder.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
            builder.Property(e => e.UserMetadata)
                .HasColumnType("jsonb")
                .HasColumnName("user_metadata");
            builder.Property(e => e.Version).HasColumnName("version");

            builder.HasOne(d => d.Bucket).WithMany(p => p.Objects)
                .HasForeignKey(d => d.BucketId)
                .HasConstraintName("objects_bucketId_fkey");
        }
    }
}
