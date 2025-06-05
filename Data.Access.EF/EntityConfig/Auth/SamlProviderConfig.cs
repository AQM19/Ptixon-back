using Data.Access.EF.Extensions;
using Data.Access.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Access.EF.EntityConfig.Auth
{
    public class SamlProviderConfig : IEntityTypeConfiguration<SamlProvider>
    {
        public void Configure(EntityTypeBuilder<SamlProvider> builder)
        {
            builder.HasKey(e => e.Id).HasName("saml_providers_pkey");

            builder.ToTable("saml_providers",
                schema: nameof(Schemes.auth),
                tb => tb.HasComment("Auth: Manages SAML Identity Provider connections."));

            builder.HasIndex(e => e.EntityId, "saml_providers_entity_id_key").IsUnique();

            builder.HasIndex(e => e.SsoProviderId, "saml_providers_sso_provider_id_idx");

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            builder.Property(e => e.AttributeMapping)
                .HasColumnType("jsonb")
                .HasColumnName("attribute_mapping");
            builder.Property(e => e.CreatedAt).HasColumnName("created_at");
            builder.Property(e => e.EntityId).HasColumnName("entity_id");
            builder.Property(e => e.MetadataUrl).HasColumnName("metadata_url");
            builder.Property(e => e.MetadataXml).HasColumnName("metadata_xml");
            builder.Property(e => e.NameIdFormat).HasColumnName("name_id_format");
            builder.Property(e => e.SsoProviderId).HasColumnName("sso_provider_id");
            builder.Property(e => e.UpdatedAt).HasColumnName("updated_at");

            builder.HasOne(d => d.SsoProvider).WithMany(p => p.SamlProviders)
                .HasForeignKey(d => d.SsoProviderId)
                .HasConstraintName("saml_providers_sso_provider_id_fkey");
        }
    }
}
