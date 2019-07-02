using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using HMS.Entities.Enums;

namespace HMS.ViewModels.App
{
    public class PersonEducationViewModel
    {
        [ScaffoldColumn(false)]
        [Display(Name = "شناسه")]
        public int Id { get; set; }
        [ScaffoldColumn(false)]
        [Display(Name = "شناسه فرد")]
        public int? PersonId { get; set; }
        [Display(Name = "نوع مدرک")]
        [Required(ErrorMessage = "لطفا نوع مدرک را انتخاب نمایید")]
        public int CertificateTypeId { get; set; }
        [Display(Name = "نوع مدرک")]
        public string CertificateTypeName { get; set; }
        [Display(Name = "گروه تحصیلی")]
        public int? DepartmentId { get; set; }
        [Display(Name = "گروه تحصیلی")]
        public string DepartmentName { get; set; }
        [Display(Name = "رشته تحصیلی")]
        public int? FieldStudyId { get; set; }
        [Display(Name = "رشته تحصیلی")]
        public string FieldStudyName { get; set; }
        [Display(Name = "نوع دانشگاه")]
        [Required(ErrorMessage = "لطفا نوع دانشگاه را انتخاب نمایید")]
        public UniversityType UniversityType { get; set; }
        [Display(Name = "نام دانشگاه")]
        public string UniversityName { get; set; }
        [Display(Name = "تاریخ فارغ التحصیلی")]
        public DateTime? GraduatedDate { get; set; }
        [Range(0,20.00,ErrorMessage = "لازم به یادآوری می باشد معدل بین 0 تا 20 می باشد!")]
        [Display(Name = "معدل")]
        public decimal? Average { get; set; }
        [Display(Name = "مدرک اعمال شده")]
        public bool? Applied { get; set; }
    }
}
