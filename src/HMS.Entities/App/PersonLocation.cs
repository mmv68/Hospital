using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HMS.Entities.AuditableEntity;

namespace HMS.Entities.App
{
    public class PersonLocation:IAuditableEntity
    {
        #region Ctor




        #endregion

        #region Peroperties

        public int Id { get; set; }
        [ForeignKey("Person")]
        public int PersonId { get; set; }
        /// <summary>
        /// Gets or sets the شناسه استان 
        /// </summary>
        [ForeignKey("Provianc")]
        public int? ProvianceId { get; set; }
        /// <summary>
        /// Gets or sets the شناسه شهرستان
        /// </summary>
        [ForeignKey("Township")]
        public int? TownshipId { get; set; }
        /// <summary>
        /// Gets or sets the شناسه بخش
        /// </summary>
        [ForeignKey("Section")]
        public int? SectionId { get; set; }
        /// <summary>
        /// Gets or sets the شناسه شهر 
        /// </summary>
        [ForeignKey("City")]
        public int? CityId { get; set; }
        /// <summary>
        /// Gets or sets the Addres
        /// </summary>
        [DataType(DataType.MultilineText)]
        public string Addres { get; set; }
        /// <summary>
        /// Gets or sets the Phone
        /// </summary>
        [Column(TypeName = "varchar(11)")]
        public string Phone { get; set; }
        /// <summary>
        /// Gets or sets the Mobile
        /// </summary>
        [Column(TypeName = "varchar(11)")]
        public string Mobile { get; set; }
        public string PersonalEmail { get; set; }
        public string OrganizationEmail { get; set; }
        #endregion

        #region NavigationProperties
        public virtual Person Person { get; set; }

        /// <summary>
        /// Gets or sets the استان
        /// </summary>
        public virtual BaseInformation Proviance { get; set; }

        /// <summary>
        /// Gets or sets the شهرستان 
        /// </summary>
        public virtual BaseInformation Township { get; set; }

        /// <summary>
        /// Gets or sets the بخش
        /// </summary>
        public virtual BaseInformation Section { get; set; }

        /// <summary>
        /// Gets or sets the شهر 
        /// </summary>
        public virtual BaseInformation City { get; set; }

        #endregion
    }
}
