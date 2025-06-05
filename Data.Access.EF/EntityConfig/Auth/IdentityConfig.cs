using Data.Access.EF.Extensions;
using Data.Access.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Access.EF.EntityConfig.Auth
{
    public class IdentityConfig : IEntityTypeConfiguration<Identity>
    {
        public void Configure(EntityTypeBuilder<Identity> builder)
        {
            builder.HasKey(e => e.Id).HasName("identities_pkey");

            builder.ToTable(
                "identities",
                schema: nameof(Schemes.auth),
                tb => tb.HasComment("Auth: Stores identities associated to a user.")
                );

            builder.HasIndex(e => e.Email, "identities_email_idx").HasOperators(new[] { "text_pattern_ops" });

            builder.HasIndex(e => new { e.ProviderId, e.Provider }, "identities_provider_id_provider_unique").IsUnique();

            builder.HasIndex(e => e.UserId, "identities_user_id_idx");

            builder.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            builder.Property(e => e.CreatedAt).HasColumnName("created_at");
            builder.Property(e => e.Email)
                .HasComputedColumnSql("lower((identity_data ->> 'email'::text))", true)
                .HasComment("Auth: Email is a generated column that references the optional email property in the identity_data")
                .HasColumnName("email");
            builder.Property(e => e.IdentityData)
                .HasColumnType("jsonb")
                .HasColumnName("identity_data");
            builder.Property(e => e.LastSignInAt).HasColumnName("last_sign_in_at");
            builder.Property(e => e.Provider).HasColumnName("provider");
            builder.Property(e => e.ProviderId).HasColumnName("provider_id");
            builder.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            builder.Property(e => e.UserId).HasColumnName("user_id");

            builder.HasOne(d => d.User).WithMany(p => p.Identities)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("identities_user_id_fkey");
        }
    }
}
