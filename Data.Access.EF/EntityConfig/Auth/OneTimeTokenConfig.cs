using Data.Access.EF.Extensions;
using Data.Access.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Access.EF.EntityConfig.Auth
{
    public class OneTimeTokenConfig : IEntityTypeConfiguration<OneTimeToken>
    {
        public void Configure(EntityTypeBuilder<OneTimeToken> builder)
        {
            builder.HasKey(e => e.Id).HasName("one_time_tokens_pkey");

            builder.ToTable("one_time_tokens", schema: nameof(Schemes.auth));

            builder.HasIndex(e => e.RelatesTo, "one_time_tokens_relates_to_hash_idx").HasMethod("hash");

            builder.HasIndex(e => e.TokenHash, "one_time_tokens_token_hash_hash_idx").HasMethod("hash");

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            builder.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            builder.Property(e => e.RelatesTo).HasColumnName("relates_to");
            builder.Property(e => e.TokenHash).HasColumnName("token_hash");
            builder.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            builder.Property(e => e.UserId).HasColumnName("user_id");

            builder.HasOne(d => d.User).WithMany(p => p.OneTimeTokens)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("one_time_tokens_user_id_fkey");
        }
    }
}
