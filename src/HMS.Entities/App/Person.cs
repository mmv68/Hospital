namespace HMS.Entities.App
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using AuditableEntity;
    using Enums;

    /// <summary>
    /// جهت نگهداری و مدیریت اطلاعات سرمایه انسانی سامانه
    /// </summary>
    public class Person : IAuditableEntity
    {
        #region Ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// </summary>
        public Person()
        {
            Children=new HashSet<Person>();
        }
        #endregion

        #region Properties
        /// <summary>
        /// شناسه
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// والد
        /// </summary>
        [ForeignKey("Parent")]
        public int? ParentId { get; set; }

        /// <summary>
        /// Gets or sets the نام
        /// </summary>
        [StringLength(50)]
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the نام خانوادگی
        /// </summary>
        [StringLength(80)]
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the نام پدر
        /// </summary>
        [StringLength(50)]
        [Required]
        public string FatherName { get; set; }

        /// <summary>
        /// Gets or sets the نام مادر
        /// </summary>
        [StringLength(50)]
        [Required]
        public string MotherName { get; set; }

        /// <summary>
        /// Gets or sets the شماره شناسنامه
        /// </summary>
        [Column(TypeName = "varchar(10)")]
        public string IdentityNumber { get; set; }

        /// <summary>
        /// Gets or sets the سری حرفی شناسنامه
        /// </summary>
        [Column(TypeName = "nvarchar(3)")]
        public string IdentitySeries { get; set; }
        
        /// <summary>
        /// Gets or sets the سری عددی شناسنامه
        /// </summary>
        public short? IdentitySeriesNumber { get; set; }

        /// <summary>
        /// Gets or sets the سریال شناسنامه
        /// </summary>
        [Column(TypeName = "varchar(6)")]
        public string IdentitySerial { get; set; }

        /// <summary>
        /// Gets or sets the کد ملی
        /// </summary>
        [Column(TypeName = "varchar(10)")]
        [Required]
        public string NationalCode { get; set; }

        /// <summary>
        /// Gets or sets the تاریخ تولد
        /// </summary>
        [Column(TypeName = "date")]
        public DateTime? BrithDate { get; set; }

        /// <summary>
        /// Gets the سن
        /// </summary>
        [NotMapped]
        public int? Age => (BrithDate != null) ? DateTimeOffset.UtcNow.Year - BrithDate.Value.Year : 0;

        /// <summary>
        /// Gets or sets the شناسه استان محل تولد
        /// </summary>
        [ForeignKey("BrithPlaceProvianc")]
        public int? BrithPlaceProvianceId { get; set; }

        /// <summary>
        /// Gets or sets the شناسه شهر محل تولد
        /// </summary>
        [ForeignKey("BrithPlaceCity")]
        public int? BrithPlaceCityId { get; set; }

        /// <summary>
        /// Gets or sets the دین
        /// </summary>
        public Religion? Religion { get; set; }

        /// <summary>
        /// Gets or sets the مذهب
        /// </summary>
        public Denomation? Denomation { get; set; }

        /// <summary>
        /// Gets or sets the جنسیت
        /// </summary>
        public Sex? Sex { get; set; }

        /// <summary>
        /// Gets or sets the نسبت
        /// </summary>
        [ForeignKey("Relation")]
        public int? RelationId { get; set; }

        /// <summary>
        /// Gets or sets the کنترل همروندی
        /// </summary>
        [Timestamp]
        [ConcurrencyCheck]
        [MaxLength(8)]
        public byte[] Timestamp { get; set; }

        #endregion

        #region NavigationProperties

        /// <summary>
        /// Gets or sets the Parent
        /// </summary>
        public virtual Person Parent { get; set; }

        /// <summary>
        /// Gets or sets the Children
        /// </summary>
        [InverseProperty("Parent")]
        public virtual ICollection<Person> Children { get; set; }

        /// <summary>
        /// Gets or sets the استان محل تولد
        /// </summary>
        public virtual BaseInformation BrithPlaceProviance { get; set; }

        /// <summary>
        /// Gets or sets the شهر محل تولد 
        /// </summary>
        public virtual BaseInformation BrithPlaceCity {get; set; }
        
        /// <summary>
        /// Gets or sets the نسبت 
        /// </summary>
        public virtual BaseInformation Relation {get; set; }

        #endregion


    }
}
