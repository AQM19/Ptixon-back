using Data.Access.EF.Extensions;
using Data.Access.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Access.EF.EntityConfig.Auth
{
    public class SessionConfig : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.HasKey(e => e.Id).HasName("sessions_pkey");

            builder.ToTable("sessions",
                schema: nameof(Schemes.auth),
                tb => tb.HasComment("Auth: Stores session data associated to a user."));

            builder.HasIndex(e => e.NotAfter, "sessions_not_after_idx").IsDescending();

            builder.HasIndex(e => e.UserId, "sessions_user_id_idx");

            builder.HasIndex(e => new { e.UserId, e.CreatedAt }, "user_id_created_at_idx");

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            builder.Property(e => e.CreatedAt).HasColumnName("created_at");
            builder.Property(e => e.FactorId).HasColumnName("factor_id");
            builder.Property(e => e.Ip).HasColumnName("ip");
            builder.Property(e => e.NotAfter)
                .HasComment("Auth: Not after is a nullable column that contains a timestamp after which the session should be regarded as expired.")
                .HasColumnName("not_after");
            builder.Property(e => e.RefreshedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("refreshed_at");
            builder.Property(e => e.Tag).HasColumnName("tag");
            builder.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            builder.Property(e => e.UserAgent).HasColumnName("user_agent");
            builder.Property(e => e.UserId).HasColumnName("user_id");

            builder.HasOne(d => d.User).WithMany(p => p.Sessions)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("sessions_user_id_fkey");
        }
    }
}
