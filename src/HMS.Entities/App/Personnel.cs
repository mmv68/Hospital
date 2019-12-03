using System;
using System.ComponentModel.DataAnnotations.Schema;
using HMS.Entities.AuditableEntity;

namespace HMS.Entities.App
{
    public class Personnel:IAuditableEntity
    {
        public int Id { get; set; }
        [ForeignKey("Person")]
        public int PersonId { get; set; }
        [ForeignKey("Structure")]
        public ushort StructureId { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string Code { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string CardNumber { get; set; }
        [Column(TypeName = "date")]
        public DateTime? ExportDate { get; set; }
        [ForeignKey("MembershipType")]
        public int? MembershipTypeId { get; set; }
        [Column(TypeName = "date")]
        public DateTime? MembershipDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? EntryDateCorps { get; set; }
        [Column(TypeName = "date")]
        public DateTime? EntryDateHealthcare { get; set; }
        [Column(TypeName = "date")]
        public DateTime? EntryDateTreatmentcenter { get; set; }
        [Column(TypeName = "date")]
        public DateTime? TransferInDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? TransferOutDate { get; set; }
        [ForeignKey("MilitaryBranch")]
        public int? MilitaryBranchId { get; set; }
        public byte? DegreeApproved { get; set; }
        public byte? DegreeSalary { get; set; }
        public byte? Rating { get; set; }
        [ForeignKey("Condition")]
        public int? ConditionId { get; set; }
        [Column(TypeName = "varchar(40)")]
        public string JobCode { get; set; }
        public string JobName { get; set; }

        #region NavigationProperties
        public virtual Person Person { get; set; }
        public virtual Structure Structure { get; set; }
        public virtual BaseInformation MembershipType { get; set; }
        public virtual BaseInformation MilitaryBranch { get; set; }
        public virtual BaseInformation Condition { get; set; }
        #endregion

    }
}
