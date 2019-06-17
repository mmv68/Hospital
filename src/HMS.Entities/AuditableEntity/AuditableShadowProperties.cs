using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using HMS.Common.IdentityToolkit;

namespace HMS.Entities.AuditableEntity
{
    /// <summary>
    /// More info: http://www.YaZahra.YaAli/post/2577
    /// and http://www.YaZahra.YaAli/post/2578
    /// and http://www.YaZahra.YaAli/post/2507
    /// and http://www.YaZahra.YaAli/post/2232
    /// </summary>
    public static class AuditableShadowProperties
    {
        //public static readonly Func<object, string> EFPropertyDescription =
        //                        entity => EF.Property<string>(entity, Description);
        //public static readonly string Description = nameof(Description);

        public static readonly Func<object, bool?> EFPropertyIsImported =
                                entity => EF.Property<bool?>(entity, IsImported);
        public static readonly string IsImported = nameof(IsImported);

        public static readonly Func<object, bool?> EFPropertyIsDeleted =
                                entity => EF.Property<bool?>(entity, IsDeleted);
        public static readonly string IsDeleted = nameof(IsDeleted);

        public static readonly Func<object, string> EFPropertyCreatedByBrowserName =
                                        entity => EF.Property<string>(entity, CreatedByBrowserName);
        public static readonly string CreatedByBrowserName = nameof(CreatedByBrowserName);

        public static readonly Func<object, string> EFPropertyModifiedByBrowserName =
                                        entity => EF.Property<string>(entity, ModifiedByBrowserName);
        public static readonly string ModifiedByBrowserName = nameof(ModifiedByBrowserName);

        public static readonly Func<object, string> EFPropertyCreatedByIp =
                                        entity => EF.Property<string>(entity, CreatedByIp);
        public static readonly string CreatedByIp = nameof(CreatedByIp);

        public static readonly Func<object, string> EFPropertyModifiedByIp =
                                        entity => EF.Property<string>(entity, ModifiedByIp);
        public static readonly string ModifiedByIp = nameof(ModifiedByIp);

        public static readonly Func<object, int?> EFPropertyCreatedByUserId =
                                        entity => EF.Property<int?>(entity, CreatedByUserId);
        public static readonly string CreatedByUserId = nameof(CreatedByUserId);

        public static readonly Func<object, int?> EFPropertyModifiedByUserId =
                                        entity => EF.Property<int?>(entity, ModifiedByUserId);
        public static readonly string ModifiedByUserId = nameof(ModifiedByUserId);

        public static readonly Func<object, DateTimeOffset?> EFPropertyCreatedDateTime =
                                        entity => EF.Property<DateTimeOffset?>(entity, CreatedDateTime);
        public static readonly string CreatedDateTime = nameof(CreatedDateTime);

        public static readonly Func<object, DateTimeOffset?> EFPropertyModifiedDateTime =
                                        entity => EF.Property<DateTimeOffset?>(entity, ModifiedDateTime);
        public static readonly string ModifiedDateTime = nameof(ModifiedDateTime);


        public static void AddAuditableShadowProperties(this ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model
                                                   .GetEntityTypes()
                                                   .Where(e => typeof(IAuditableEntity).IsAssignableFrom(e.ClrType)))
            {
                //modelBuilder.Entity(entityType.ClrType)
                //            .Property<string>(Description).HasMaxLength(1000);
                modelBuilder.Entity(entityType.ClrType)
                            .Property<bool?>(IsImported);
                modelBuilder.Entity(entityType.ClrType)
                            .Property<bool?>(IsDeleted);

                modelBuilder.Entity(entityType.ClrType)
                            .Property<string>(CreatedByBrowserName).HasMaxLength(1000);
                modelBuilder.Entity(entityType.ClrType)
                            .Property<string>(ModifiedByBrowserName).HasMaxLength(1000);

                modelBuilder.Entity(entityType.ClrType)
                            .Property<string>(CreatedByIp).HasMaxLength(255);
                modelBuilder.Entity(entityType.ClrType)
                            .Property<string>(ModifiedByIp).HasMaxLength(255);

                modelBuilder.Entity(entityType.ClrType)
                            .Property<int?>(CreatedByUserId);
                modelBuilder.Entity(entityType.ClrType)
                            .Property<int?>(ModifiedByUserId);

                modelBuilder.Entity(entityType.ClrType)
                            .Property<DateTimeOffset?>(CreatedDateTime);
                modelBuilder.Entity(entityType.ClrType)
                            .Property<DateTimeOffset?>(ModifiedDateTime);

            }
        }

        /// <summary>
        /// More info: http://www.YaZahra.YaAli/post/2507
        /// </summary>
        public static void SetAuditableEntityPropertyValues(
            this ChangeTracker changeTracker,
            IHttpContextAccessor httpContextAccessor)
        {
            var httpContext = httpContextAccessor?.HttpContext;
            var userAgent = httpContext?.Request?.Headers["User-Agent"].ToString();
            var userIp = httpContext?.Connection?.RemoteIpAddress?.ToString();
            var now = DateTimeOffset.UtcNow;
            var userId = GetUserId(httpContext);

            var modifiedEntries = changeTracker.Entries<IAuditableEntity>()
                                               .Where(x => x.State == EntityState.Modified);
            foreach (var modifiedEntry in modifiedEntries)
            {
                modifiedEntry.Property(ModifiedDateTime).CurrentValue = now;
                modifiedEntry.Property(ModifiedByBrowserName).CurrentValue = userAgent;
                modifiedEntry.Property(ModifiedByIp).CurrentValue = userIp;
                modifiedEntry.Property(ModifiedByUserId).CurrentValue = userId;
            }

            var addedEntries = changeTracker.Entries<IAuditableEntity>()
                                            .Where(x => x.State == EntityState.Added);
            foreach (var addedEntry in addedEntries)
            {
                addedEntry.Property(CreatedDateTime).CurrentValue = now;
                addedEntry.Property(CreatedByBrowserName).CurrentValue = userAgent;
                addedEntry.Property(CreatedByIp).CurrentValue = userIp;
                addedEntry.Property(CreatedByUserId).CurrentValue = userId;
            }

            var deleteEntries = changeTracker.Entries<IAuditableEntity>()
                                            .Where(x => x.State == EntityState.Deleted);
            foreach (var deletedEntry in deleteEntries)
            {
                deletedEntry.State = EntityState.Modified;
                deletedEntry.Property(IsDeleted).CurrentValue = true;
            }
        }

        private static int? GetUserId(HttpContext httpContext)
        {
            int? userId = null;
            var userIdValue = httpContext?.User?.Identity?.GetUserId();
            if (!string.IsNullOrWhiteSpace(userIdValue))
            {
                userId = int.Parse(userIdValue);
            }
            return userId;
        }
    }
}