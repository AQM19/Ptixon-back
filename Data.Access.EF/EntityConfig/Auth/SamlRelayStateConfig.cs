using Data.Access.EF.Extensions;
using Data.Access.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Access.EF.EntityConfig.Auth
{
    public class SamlRelayStateConfig : IEntityTypeConfiguration<SamlRelayState>
    {
        public void Configure(EntityTypeBuilder<SamlRelayState> builder)
        {
            builder.HasKey(e => e.Id).HasName("saml_relay_states_pkey");

            builder.ToTable("saml_relay_states",
                schema: nameof(Schemes.auth),
                tb => tb.HasComment("Auth: Contains SAML Relay State information for each Service Provider initiated login."));

            builder.HasIndex(e => e.CreatedAt, "saml_relay_states_created_at_idx").IsDescending();

            builder.HasIndex(e => e.ForEmail, "saml_relay_states_for_email_idx");

            builder.HasIndex(e => e.SsoProviderId, "saml_relay_states_sso_provider_id_idx");

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            builder.Property(e => e.CreatedAt).HasColumnName("created_at");
            builder.Property(e => e.FlowStateId).HasColumnName("flow_state_id");
            builder.Property(e => e.ForEmail).HasColumnName("for_email");
            builder.Property(e => e.RedirectTo).HasColumnName("redirect_to");
            builder.Property(e => e.RequestId).HasColumnName("request_id");
            builder.Property(e => e.SsoProviderId).HasColumnName("sso_provider_id");
            builder.Property(e => e.UpdatedAt).HasColumnName("updated_at");

            builder.HasOne(d => d.FlowState).WithMany(p => p.SamlRelayStates)
                .HasForeignKey(d => d.FlowStateId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("saml_relay_states_flow_state_id_fkey");

            builder.HasOne(d => d.SsoProvider).WithMany(p => p.SamlRelayStates)
                .HasForeignKey(d => d.SsoProviderId)
                .HasConstraintName("saml_relay_states_sso_provider_id_fkey");
        }
    }
}
