using Data.Access.EF.Extensions;
using Data.Access.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Access.EF.EntityConfig.Auth
{
    public class FlowStateConfig : IEntityTypeConfiguration<FlowState>
    {
        public void Configure(EntityTypeBuilder<FlowState> builder)
        {
            builder.HasKey(e => e.Id).HasName("flow_state_pkey");

            builder.ToTable(
                "flow_state",
                schema: nameof(Schemes.auth),
                tb => tb.HasComment("stores metadata for pkce logins")
                );

            builder.HasIndex(e => e.CreatedAt, "flow_state_created_at_idx").IsDescending();

            builder.HasIndex(e => e.AuthCode, "idx_auth_code");

            builder.HasIndex(e => new { e.UserId, e.AuthenticationMethod }, "idx_user_id_auth_method");

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            builder.Property(e => e.AuthCode).HasColumnName("auth_code");
            builder.Property(e => e.AuthCodeIssuedAt).HasColumnName("auth_code_issued_at");
            builder.Property(e => e.AuthenticationMethod).HasColumnName("authentication_method");
            builder.Property(e => e.CodeChallenge).HasColumnName("code_challenge");
            builder.Property(e => e.CreatedAt).HasColumnName("created_at");
            builder.Property(e => e.ProviderAccessToken).HasColumnName("provider_access_token");
            builder.Property(e => e.ProviderRefreshToken).HasColumnName("provider_refresh_token");
            builder.Property(e => e.ProviderType).HasColumnName("provider_type");
            builder.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            builder.Property(e => e.UserId).HasColumnName("user_id");
        }
    }
}
