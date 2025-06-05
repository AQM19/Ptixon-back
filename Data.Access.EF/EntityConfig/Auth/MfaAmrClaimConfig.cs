using Data.Access.EF.Extensions;
using Data.Access.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Access.EF.EntityConfig.Auth
{
    public class MfaAmrClaimConfig : IEntityTypeConfiguration<MfaAmrClaim>
    {
        public void Configure(EntityTypeBuilder<MfaAmrClaim> builder)
        {
            builder.HasKey(e => e.Id).HasName("amr_id_pk");

            builder.ToTable(
                "mfa_amr_claims",
                schema: nameof(Schemes.auth),
                tb => tb.HasComment("auth: stores authenticator method reference claims for multi factor authentication")
                );

            builder.HasIndex(e =>
                new { e.SessionId, e.AuthenticationMethod },
                "mfa_amr_claims_session_id_authentication_method_pkey").IsUnique();

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            builder.Property(e => e.AuthenticationMethod).HasColumnName("authentication_method");
            builder.Property(e => e.CreatedAt).HasColumnName("created_at");
            builder.Property(e => e.SessionId).HasColumnName("session_id");
            builder.Property(e => e.UpdatedAt).HasColumnName("updated_at");

            builder.HasOne(d => d.Session).WithMany(p => p.MfaAmrClaims)
                .HasForeignKey(d => d.SessionId)
                .HasConstraintName("mfa_amr_claims_session_id_fkey");
        }
    }
}
