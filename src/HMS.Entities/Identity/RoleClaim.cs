using HMS.Entities.AuditableEntity;
using Microsoft.AspNetCore.Identity;

namespace HMS.Entities.Identity
{
    /// <summary>
    /// More info: http://www.YaZahra.YaAli/post/2577
    /// and http://www.YaZahra.YaAli/post/2578
    /// </summary>
    public class RoleClaim : IdentityRoleClaim<int>, IAuditableEntity
    {
        public virtual Role Role { get; set; }
    }
}