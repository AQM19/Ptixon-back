using Data.Access.EF.Extensions;
using Data.Access.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Access.EF.EntityConfig.Auth
{
    public class SchemaMigrationConfig : IEntityTypeConfiguration<SchemaMigration>
    {
        public void Configure(EntityTypeBuilder<SchemaMigration> builder)
        {
            builder.HasKey(e => e.Version).HasName("schema_migrations_pkey");

            builder.ToTable("schema_migrations",
                schema: nameof(Schemes.auth),
                tb => tb.HasComment("Auth: Manages updates to the auth system."));

            builder.Property(e => e.Version)
                .HasMaxLength(255)
                .HasColumnName("version");
        }
    }
}
