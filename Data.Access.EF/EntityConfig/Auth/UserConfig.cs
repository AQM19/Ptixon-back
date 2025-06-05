using Data.Access.EF.Extensions;
using Data.Access.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Access.EF.EntityConfig.Auth
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.Id).HasName("users_pkey");

            builder.ToTable("users", 
                schema: nameof(Schemes.auth),
                tb => tb.HasComment("Auth: Stores user login data within a secure schema."));

            builder.HasIndex(e => e.ConfirmationToken, "confirmation_token_idx")
                .IsUnique()
                .HasFilter("((confirmation_token)::text !~ '^[0-9 ]*$'::text)");

            builder.HasIndex(e => e.EmailChangeTokenCurrent, "email_change_token_current_idx")
                .IsUnique()
                .HasFilter("((email_change_token_current)::text !~ '^[0-9 ]*$'::text)");

            builder.HasIndex(e => e.EmailChangeTokenNew, "email_change_token_new_idx")
                .IsUnique()
                .HasFilter("((email_change_token_new)::text !~ '^[0-9 ]*$'::text)");

            builder.HasIndex(e => e.ReauthenticationToken, "reauthentication_token_idx")
                .IsUnique()
                .HasFilter("((reauthentication_token)::text !~ '^[0-9 ]*$'::text)");

            builder.HasIndex(e => e.RecoveryToken, "recovery_token_idx")
                .IsUnique()
                .HasFilter("((recovery_token)::text !~ '^[0-9 ]*$'::text)");

            builder.HasIndex(e => e.Email, "users_email_partial_key")
                .IsUnique()
                .HasFilter("(is_sso_user = false)");

            builder.HasIndex(e => e.InstanceId, "users_instance_id_idx");

            builder.HasIndex(e => e.IsAnonymous, "users_is_anonymous_idx");

            builder.HasIndex(e => e.Phone, "users_phone_key").IsUnique();

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            builder.Property(e => e.Aud)
                .HasMaxLength(255)
                .HasColumnName("aud");
            builder.Property(e => e.BannedUntil).HasColumnName("banned_until");
            builder.Property(e => e.ConfirmationSentAt).HasColumnName("confirmation_sent_at");
            builder.Property(e => e.ConfirmationToken)
                .HasMaxLength(255)
                .HasColumnName("confirmation_token");
            builder.Property(e => e.ConfirmedAt)
                .HasComputedColumnSql("LEAST(email_confirmed_at, phone_confirmed_at)", true)
                .HasColumnName("confirmed_at");
            builder.Property(e => e.CreatedAt).HasColumnName("created_at");
            builder.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            builder.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            builder.Property(e => e.EmailChange)
                .HasMaxLength(255)
                .HasColumnName("email_change");
            builder.Property(e => e.EmailChangeConfirmStatus)
                .HasDefaultValue((short)0)
                .HasColumnName("email_change_confirm_status");
            builder.Property(e => e.EmailChangeSentAt).HasColumnName("email_change_sent_at");
            builder.Property(e => e.EmailChangeTokenCurrent)
                .HasMaxLength(255)
                .HasDefaultValueSql("''::character varying")
                .HasColumnName("email_change_token_current");
            builder.Property(e => e.EmailChangeTokenNew)
                .HasMaxLength(255)
                .HasColumnName("email_change_token_new");
            builder.Property(e => e.EmailConfirmedAt).HasColumnName("email_confirmed_at");
            builder.Property(e => e.EncryptedPassword)
                .HasMaxLength(255)
                .HasColumnName("encrypted_password");
            builder.Property(e => e.InstanceId).HasColumnName("instance_id");
            builder.Property(e => e.InvitedAt).HasColumnName("invited_at");
            builder.Property(e => e.IsAnonymous)
                .HasDefaultValue(false)
                .HasColumnName("is_anonymous");
            builder.Property(e => e.IsSsoUser)
                .HasDefaultValue(false)
                .HasComment("Auth: Set this column to true when the account comes from SSO. These accounts can have duplicate emails.")
                .HasColumnName("is_sso_user");
            builder.Property(e => e.IsSuperAdmin).HasColumnName("is_super_admin");
            builder.Property(e => e.LastSignInAt).HasColumnName("last_sign_in_at");
            builder.Property(e => e.Phone)
                .HasDefaultValueSql("NULL::character varying")
                .HasColumnName("phone");
            builder.Property(e => e.PhoneChange)
                .HasDefaultValueSql("''::character varying")
                .HasColumnName("phone_change");
            builder.Property(e => e.PhoneChangeSentAt).HasColumnName("phone_change_sent_at");
            builder.Property(e => e.PhoneChangeToken)
                .HasMaxLength(255)
                .HasDefaultValueSql("''::character varying")
                .HasColumnName("phone_change_token");
            builder.Property(e => e.PhoneConfirmedAt).HasColumnName("phone_confirmed_at");
            builder.Property(e => e.RawAppMetaData)
                .HasColumnType("jsonb")
                .HasColumnName("raw_app_meta_data");
            builder.Property(e => e.RawUserMetaData)
                .HasColumnType("jsonb")
                .HasColumnName("raw_user_meta_data");
            builder.Property(e => e.ReauthenticationSentAt).HasColumnName("reauthentication_sent_at");
            builder.Property(e => e.ReauthenticationToken)
                .HasMaxLength(255)
                .HasDefaultValueSql("''::character varying")
                .HasColumnName("reauthentication_token");
            builder.Property(e => e.RecoverySentAt).HasColumnName("recovery_sent_at");
            builder.Property(e => e.RecoveryToken)
                .HasMaxLength(255)
                .HasColumnName("recovery_token");
            builder.Property(e => e.Role)
                .HasMaxLength(255)
                .HasColumnName("role");
            builder.Property(e => e.UpdatedAt).HasColumnName("updated_at");
        }
    }
}
