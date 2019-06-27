
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HMS.Entities.AuditableEntity;
using HMS.Entities.Enums;

namespace HMS.Entities.App
{
    public class PersonEducation: IAuditableEntity
    {
        #region Ctor


        #endregion

        #region Properties
        public int Id { get; set; }
        [ForeignKey("Person")]
        public int PersonId { get; set; }
        [ForeignKey("CertificateType")]
        public int CertificateTypeId { get; set; }
        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }
        [ForeignKey("FieldStudy")]
        public int? FieldStudyId { get; set; }
        public UniversityType UniversityType { get; set; }
        [StringLength(50)]
        public string UniversityName { get; set; }
        [Column(TypeName = "date")]
        public DateTime? GraduatedDate { get; set; }
        /// <summary>
        /// معدل
        /// </summary>
        [Column(TypeName = "decimal(4, 2)")]
        public decimal? Average { get; set; }
        public bool? Applied { get; set; }
        #endregion

        #region NavigationProperties
        public  virtual  Person Person { get; set; }
        public  virtual BaseInformation CertificateType { get; set; }
        public  virtual BaseInformation Department { get; set; }
        public  virtual BaseInformation FieldStudy { get; set; }
        #endregion


    }
}
