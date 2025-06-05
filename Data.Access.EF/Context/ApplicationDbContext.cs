using Data.Access.Entities.Auth;
using Data.Access.Entities.Realtime;
using Data.Access.Entities.Storage;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Data.Access.EF.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        #region Auth
        public virtual DbSet<AuditLogEntry> AuditLogEntries { get; set; }
        public virtual DbSet<FlowState> FlowStates { get; set; }
        public virtual DbSet<Identity> Identities { get; set; }
        public virtual DbSet<Instance> Instances { get; set; }
        public virtual DbSet<MfaAmrClaim> MfaAmrClaims { get; set; }
        public virtual DbSet<MfaChallenge> MfaChallenges { get; set; }
        public virtual DbSet<MfaFactor> MfaFactors { get; set; }
        public virtual DbSet<OneTimeToken> OneTimeTokens { get; set; }
        public virtual DbSet<RefreshToken> RefreshTokens { get; set; }
        public virtual DbSet<SamlProvider> SamlProviders { get; set; }
        public virtual DbSet<SamlRelayState> SamlRelayStates { get; set; }
        public virtual DbSet<SchemaMigration> SchemaMigrations { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<SsoDomain> SsoDomains { get; set; }
        public virtual DbSet<SsoProvider> SsoProviders { get; set; }
        public virtual DbSet<User> Users { get; set; }
        #endregion

        #region Realtime
        public virtual DbSet<SchemaMigration1> SchemaMigrations1 { get; set; }
        public virtual DbSet<Subscription> Subscriptions { get; set; }
        #endregion

        #region Storage
        public virtual DbSet<Migration> Migrations { get; set; }
        public virtual DbSet<S3MultipartUpload> S3MultipartUploads { get; set; }
        public virtual DbSet<S3MultipartUploadPart> S3MultipartUploadsParts { get; set; }
        public virtual DbSet<Bucket> Buckets { get; set; }
        public virtual DbSet<SupabaseObject> Objects { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasPostgresEnum("auth", "aal_level", new[] { "aal1", "aal2", "aal3" })
                .HasPostgresEnum("auth", "code_challenge_method", new[] { "s256", "plain" })
                .HasPostgresEnum("auth", "factor_status", new[] { "unverified", "verified" })
                .HasPostgresEnum("auth", "factor_type", new[] { "totp", "webauthn", "phone" })
                .HasPostgresEnum("auth", "one_time_token_type", new[] { "confirmation_token", "reauthentication_token", "recovery_token", "email_change_token_new", "email_change_token_current", "phone_change_token" })
                .HasPostgresEnum("realtime", "action", new[] { "INSERT", "UPDATE", "DELETE", "TRUNCATE", "ERROR" })
                .HasPostgresEnum("realtime", "equality_op", new[] { "eq", "neq", "lt", "lte", "gt", "gte", "in" })
                .HasPostgresExtension("extensions", "pg_stat_statements")
                .HasPostgresExtension("extensions", "pgcrypto")
                .HasPostgresExtension("extensions", "pgjwt")
                .HasPostgresExtension("extensions", "uuid-ossp")
                .HasPostgresExtension("graphql", "pg_graphql")
                .HasPostgresExtension("vault", "supabase_vault");

            modelBuilder.HasSequence<int>("seq_schema_version", "graphql").IsCyclic();

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
