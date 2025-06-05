using Data.Access.EF.Extensions;
using Data.Access.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Access.EF.EntityConfig.Auth
{
    public class SsoDomainConfig : IEntityTypeConfiguration<SsoDomain>
    {
        public void Configure(EntityTypeBuilder<SsoDomain> builder)
        {
            builder.HasKey(e => e.Id).HasName("sso_domains_pkey");

            builder.ToTable("sso_domains",
                schema: nameof(Schemes.auth),
                tb => tb.HasComment("Auth: Manages SSO email address domain mapping to an SSO Identity Provider."));

            builder.HasIndex(e => e.SsoProviderId, "sso_domains_sso_provider_id_idx");

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            builder.Property(e => e.CreatedAt).HasColumnName("created_at");
            builder.Property(e => e.Domain).HasColumnName("domain");
            builder.Property(e => e.SsoProviderId).HasColumnName("sso_provider_id");
            builder.Property(e => e.UpdatedAt).HasColumnName("updated_at");

            builder.HasOne(d => d.SsoProvider).WithMany(p => p.SsoDomains)
                .HasForeignKey(d => d.SsoProviderId)
                .HasConstraintName("sso_domains_sso_provider_id_fkey");
        }
    }
}
