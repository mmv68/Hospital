using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HMS.Entities.AuditableEntity;
using HMS.Entities.Enums;

namespace HMS.Entities.App
{
    public class PersonMarriage:IAuditableEntity
    {
        #region Ctor




        #endregion

        #region Peroperties

        public int Id { get; set; }
        [ForeignKey("Person")]
        public int PersonId { get; set; }
        public MarriageDivorce MarriageDivorce { get; set; }
        [Column(TypeName = "date")]
        public DateTime? IncidentDate { get; set; }
        [StringLength(10)]
        public string OfficeNumber { get; set; }
        [StringLength(10)]
        public string RegisterNumber { get; set; }
        #endregion

        #region NavigationProperties
        public virtual Person Person { get; set; }
        #endregion
    }
}
