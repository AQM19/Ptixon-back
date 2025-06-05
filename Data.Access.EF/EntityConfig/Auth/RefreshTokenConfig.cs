using Data.Access.EF.Extensions;
using Data.Access.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Access.EF.EntityConfig.Auth
{
    public class RefreshTokenConfig : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.HasKey(e => e.Id).HasName("refresh_tokens_pkey");

            builder.ToTable("refresh_tokens",
                schema: nameof(Schemes.auth),
                tb => tb.HasComment("Auth: Store of tokens used to refresh JWT tokens once they expire."));

            builder.HasIndex(e => e.InstanceId, "refresh_tokens_instance_id_idx");

            builder.HasIndex(e => new { e.InstanceId, e.UserId }, "refresh_tokens_instance_id_user_id_idx");

            builder.HasIndex(e => e.Parent, "refresh_tokens_parent_idx");

            builder.HasIndex(e => new { e.SessionId, e.Revoked }, "refresh_tokens_session_id_revoked_idx");

            builder.HasIndex(e => e.Token, "refresh_tokens_token_unique").IsUnique();

            builder.HasIndex(e => e.UpdatedAt, "refresh_tokens_updated_at_idx").IsDescending();

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.CreatedAt).HasColumnName("created_at");
            builder.Property(e => e.InstanceId).HasColumnName("instance_id");
            builder.Property(e => e.Parent)
                .HasMaxLength(255)
                .HasColumnName("parent");
            builder.Property(e => e.Revoked).HasColumnName("revoked");
            builder.Property(e => e.SessionId).HasColumnName("session_id");
            builder.Property(e => e.Token)
                .HasMaxLength(255)
                .HasColumnName("token");
            builder.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            builder.Property(e => e.UserId)
                .HasMaxLength(255)
                .HasColumnName("user_id");

            builder.HasOne(d => d.Session).WithMany(p => p.RefreshTokens)
                .HasForeignKey(d => d.SessionId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("refresh_tokens_session_id_fkey");
        }
    }
}
