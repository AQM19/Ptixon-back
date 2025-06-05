using Data.Access.EF.Extensions;
using Data.Access.Entities.Realtime;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Access.EF.EntityConfig.Realtime
{
    public class SchemaMigration1Config : IEntityTypeConfiguration<SchemaMigration1>
    {
        public void Configure(EntityTypeBuilder<SchemaMigration1> builder)
        {
            builder.HasKey(e => e.Version).HasName("schema_migrations_pkey");

            builder.ToTable("schema_migrations", schema: nameof(Schemes.realtime));

            builder.Property(e => e.Version)
                .ValueGeneratedNever()
                .HasColumnName("version");
            builder.Property(e => e.InsertedAt)
                .HasColumnType("timestamp(0) without time zone")
                .HasColumnName("inserted_at");
        }
    }
}
