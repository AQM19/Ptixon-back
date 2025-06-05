using Data.Access.EF.Extensions;
using Data.Access.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Access.EF.EntityConfig.Auth
{
    public class MfaFactorConfig : IEntityTypeConfiguration<MfaFactor>
    {
        public void Configure(EntityTypeBuilder<MfaFactor> builder)
        {
            builder.HasKey(e => e.Id).HasName("mfa_factors_pkey");

            builder.ToTable(
                "mfa_factors",
                schema: nameof(Schemes.auth),
                tb => tb.HasComment("auth: stores metadata about factors"));

            builder.HasIndex(e => new { e.UserId, e.CreatedAt }, "factor_id_created_at_idx");

            builder.HasIndex(e => e.LastChallengedAt, "mfa_factors_last_challenged_at_key").IsUnique();

            builder.HasIndex(e => new { e.FriendlyName, e.UserId }, "mfa_factors_user_friendly_name_unique")
                .IsUnique()
                .HasFilter("(TRIM(BOTH FROM friendly_name) <> ''::text)");

            builder.HasIndex(e => e.UserId, "mfa_factors_user_id_idx");

            builder.HasIndex(e => new { e.UserId, e.Phone }, "unique_phone_factor_per_user").IsUnique();

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            builder.Property(e => e.CreatedAt).HasColumnName("created_at");
            builder.Property(e => e.FriendlyName).HasColumnName("friendly_name");
            builder.Property(e => e.LastChallengedAt).HasColumnName("last_challenged_at");
            builder.Property(e => e.Phone).HasColumnName("phone");
            builder.Property(e => e.Secret).HasColumnName("secret");
            builder.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            builder.Property(e => e.UserId).HasColumnName("user_id");
            builder.Property(e => e.WebAuthnAaguid).HasColumnName("web_authn_aaguid");
            builder.Property(e => e.WebAuthnCredential)
                .HasColumnType("jsonb")
                .HasColumnName("web_authn_credential");

            builder.HasOne(d => d.User).WithMany(p => p.MfaFactors)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("mfa_factors_user_id_fkey");
        }
    }
}
