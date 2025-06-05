using Data.Access.EF.Extensions;
using Data.Access.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Access.EF.EntityConfig.Auth
{
    public class MfaChallengeConfig : IEntityTypeConfiguration<MfaChallenge>
    {
        public void Configure(EntityTypeBuilder<MfaChallenge> builder)
        {
            builder.HasKey(e => e.Id).HasName("mfa_challenges_pkey");

            builder.ToTable(
                "mfa_challenges",
                schema: nameof(Schemes.auth),
                tb => tb.HasComment("auth: stores metadata about challenge requests made"));

            builder.HasIndex(e => e.CreatedAt, "mfa_challenge_created_at_idx").IsDescending();

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            builder.Property(e => e.CreatedAt).HasColumnName("created_at");
            builder.Property(e => e.FactorId).HasColumnName("factor_id");
            builder.Property(e => e.IpAddress).HasColumnName("ip_address");
            builder.Property(e => e.OtpCode).HasColumnName("otp_code");
            builder.Property(e => e.VerifiedAt).HasColumnName("verified_at");
            builder.Property(e => e.WebAuthnSessionData)
                .HasColumnType("jsonb")
                .HasColumnName("web_authn_session_data");

            builder.HasOne(d => d.Factor).WithMany(p => p.MfaChallenges)
                .HasForeignKey(d => d.FactorId)
                .HasConstraintName("mfa_challenges_auth_factor_id_fkey");
        }
    }
}
