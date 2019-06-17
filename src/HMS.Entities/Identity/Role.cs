using System.Collections.Generic;
using HMS.Entities.AuditableEntity;
using Microsoft.AspNetCore.Identity;

namespace HMS.Entities.Identity
{
    /// <summary>
    /// More info: http://www.YaZahra.YaAli/post/2577
    /// and http://www.YaZahra.YaAli/post/2578
    /// </summary>
    public class Role : IdentityRole<int>, IAuditableEntity
    {
        public Role()
        {
        }

        public Role(string name)
            : this()
        {
            Name = name;
        }

        public Role(string name, string description)
            : this(name)
        {
            RoleDescription = description;
        }

        public string RoleDescription { get; set; }

        public virtual ICollection<UserRole> Users { get; set; }

        public virtual ICollection<RoleClaim> Claims { get; set; }
    }
}