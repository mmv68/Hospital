using HMS.Entities.AuditableEntity;
using Microsoft.AspNetCore.Identity;

namespace HMS.Entities.Identity
{
    /// <summary>
    /// More info: http://www.YaZahra.YaAli/post/2577
    /// and http://www.YaZahra.YaAli/post/2578
    /// </summary>
    public class UserLogin : IdentityUserLogin<int>, IAuditableEntity
    {
        public virtual User User { get; set; }
    }
}