using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HMS.Entities.AuditableEntity;
using HMS.Entities.Enums;

namespace HMS.Entities.App
{
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
            PersonEducation=new HashSet<PersonEducation>();
            PersonLocation=new HashSet<PersonLocation>();
            PersonMarriage=new HashSet<PersonMarriage>();
            Personnel=new HashSet<Personnel>();
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
        /// Gets or sets the شناسه شهرستان محل تولد
        /// </summary>
        [ForeignKey("BrithPlaceTownship")]
        public int? BrithPlaceTownshipId { get; set; }
        
        /// <summary>
        /// Gets or sets the شناسه بخش محل تولد
        /// </summary>
        [ForeignKey("BrithPlaceSection")]
        public int? BrithPlaceSectionId { get; set; }

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
        /// Gets or sets the شهرستان محل تولد
        /// </summary>
        public virtual BaseInformation BrithPlaceTownship { get; set; }
        
        /// <summary>
        /// Gets or sets the بخش محل تولد
        /// </summary>
        public virtual BaseInformation BrithPlaceSection { get; set; }

        /// <summary>
        /// Gets or sets the شهر محل تولد 
        /// </summary>
        public virtual BaseInformation BrithPlaceCity {get; set; }
        
        /// <summary>
        /// Gets or sets the نسبت 
        /// </summary>
        public virtual BaseInformation Relation {get; set; } 

        /// <summary>
        /// Gets or sets the تحصیلات فرد 
        /// </summary>
        public virtual ICollection<PersonEducation> PersonEducation { get; set; }
        
        /// <summary>
        /// Gets or sets the  وضعیت تأهل فرد 
        /// </summary>
        public virtual ICollection<PersonMarriage> PersonMarriage { get; set; }

        /// <summary>
        /// Gets or sets the  محل سکونت فرد 
        /// </summary>
        public virtual ICollection<PersonLocation> PersonLocation { get; set; }

        [InverseProperty("Person")]
        public virtual PersonAdditionalInformation PersonAdditionalInformation { get; set; }

        /// <summary>
        /// Gets or sets the  اطلاعات پرسنلی
        /// </summary>
        public virtual ICollection<Personnel> Personnel { get; set; }

        #endregion


    }
}
