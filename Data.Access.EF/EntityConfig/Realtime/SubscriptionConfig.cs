using Data.Access.EF.Extensions;
using Data.Access.Entities.Realtime;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Access.EF.EntityConfig.Realtime
{
    public class SubscriptionConfig : IEntityTypeConfiguration<Subscription>
    {
        public void Configure(EntityTypeBuilder<Subscription> builder)
        {
            builder.HasKey(e => e.Id).HasName("pk_subscription");

            builder.ToTable("subscription", schema: nameof(Schemes.realtime));

            builder.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            builder.Property(e => e.Claims)
                .HasColumnType("jsonb")
                .HasColumnName("claims");
            builder.Property(e => e.CreatedAt)
                .HasDefaultValueSql("timezone('utc'::text, now())")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            builder.Property(e => e.SubscriptionId).HasColumnName("subscription_id");
        }
    }
}
