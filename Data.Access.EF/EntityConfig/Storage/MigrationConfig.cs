using Data.Access.EF.Extensions;
using Data.Access.Entities.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Access.EF.EntityConfig.Storage
{
    public class MigrationConfig : IEntityTypeConfiguration<Migration>
    {
        public void Configure(EntityTypeBuilder<Migration> builder)
        {
            builder.HasKey(e => e.Id).HasName("migrations_pkey");

            builder.ToTable("migrations", nameof(Schemes.storage));

            builder.HasIndex(e => e.Name, "migrations_name_key").IsUnique();

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            builder.Property(e => e.ExecutedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("executed_at");
            builder.Property(e => e.Hash)
                .HasMaxLength(40)
                .HasColumnName("hash");
            builder.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        }
    }
}
