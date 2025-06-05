using Data.Access.EF.Extensions;
using Data.Access.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Access.EF.EntityConfig.Auth
{
    public class AuditLogEntryConfig : IEntityTypeConfiguration<AuditLogEntry>
    {
        public void Configure(EntityTypeBuilder<AuditLogEntry> builder)
        {
            builder.ToTable(
                "audit_log_entries",
                schema: nameof(Schemes.auth),
                tb => tb.HasComment("Auth: Audit trail for user actions.")
                );

            builder.HasKey(e => e.Id).HasName("audit_log_entries_pkey");
            builder.HasIndex(e => e.InstanceId, "audit_logs_instance_id_idx");

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            builder.Property(e => e.CreatedAt).HasColumnName("created_at");
            builder.Property(e => e.InstanceId).HasColumnName("instance_id");
            builder.Property(e => e.IpAddress)
                .HasMaxLength(64)
                .HasDefaultValueSql("''::character varying")
                .HasColumnName("ip_address");
            builder.Property(e => e.Payload)
                .HasColumnType("json")
                .HasColumnName("payload");
        }

    }
}
