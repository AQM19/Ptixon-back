using Data.Access.EF.Extensions;
using Data.Access.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Access.EF.EntityConfig.Auth
{
    public class InstanceConfig : IEntityTypeConfiguration<Instance>
    {
        public void Configure(EntityTypeBuilder<Instance> builder)
        {
            builder.HasKey(e => e.Id).HasName("instances_pkey");

            builder.ToTable(
                "instances",
                schema: nameof(Schemes.auth),
                tb => tb.HasComment("Auth: Manages users across multiple sites.")
                );

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            builder.Property(e => e.CreatedAt).HasColumnName("created_at");
            builder.Property(e => e.RawBaseConfig).HasColumnName("raw_base_config");
            builder.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            builder.Property(e => e.Uuid).HasColumnName("uuid");
        }
    }
}
