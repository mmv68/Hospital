using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HMS.Entities.AuditableEntity;

namespace HMS.Entities.App
{
    /// <summary>
    /// ساختار سازمان استفاده کننده از سامانه جهت تقسیم بندی و همچنین تعیین سطح دسترسی های کاربران
    /// </summary>
    public class Structure : IAuditableEntity
    {
        #region Ctor

        #endregion
        #region Properties
        public ushort Id { get; set; }
        [ForeignKey("Parent")]
        public ushort? ParentId { get; set; }
        [StringLength(30)]
        public string Code { get; set; }
        [StringLength(100)]
        public string Title { get; set; }
        [StringLength(11)]
        public string Phone { get; set; }
        [StringLength(5)]
        public string Kousar { get; set; }
        public byte? Proviance { get; set; }
        public ushort? City { get; set; }
        public bool? IsActive { get; set; }
        #endregion
        #region NavigationProperties      
        public virtual Structure Parent { get; set; }
        [InverseProperty("Parent")]
        public virtual ICollection<Structure> Children { get; set; }
        [InverseProperty("Structure")]
        public virtual ICollection<Personnel> Personnel { get; set; }
        #endregion

    }
}