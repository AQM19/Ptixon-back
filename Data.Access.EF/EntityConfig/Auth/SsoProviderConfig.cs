using Data.Access.EF.Extensions;
using Data.Access.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Access.EF.EntityConfig.Auth
{
    public class SsoProviderConfig : IEntityTypeConfiguration<SsoProvider>
    {
        public void Configure(EntityTypeBuilder<SsoProvider> builder)
        {
            builder.HasKey(e => e.Id).HasName("sso_providers_pkey");

            builder.ToTable("sso_providers",
                schema: nameof(Schemes.auth),
                tb => tb.HasComment("Auth: Manages SSO identity provider information; see saml_providers for SAML."));

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            builder.Property(e => e.CreatedAt).HasColumnName("created_at");
            builder.Property(e => e.ResourceId)
                .HasComment("Auth: Uniquely identifies a SSO provider according to a user-chosen resource ID (case insensitive), useful in infrastructure as code.")
                .HasColumnName("resource_id");
            builder.Property(e => e.UpdatedAt).HasColumnName("updated_at");
        }
    }
}
