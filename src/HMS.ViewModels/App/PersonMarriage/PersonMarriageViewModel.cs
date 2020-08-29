using System;
using System.ComponentModel.DataAnnotations;
using HMS.Entities.Enums;

namespace HMS.ViewModels.App
{
    public class PersonMarriageViewModel
    {
        [ScaffoldColumn(false)]
        [Display(Name = "شناسه")]
        public int Id { get; set; }
        [ScaffoldColumn(false)]
        [Display(Name = "شناسه فرد")]
        public int PersonId { get; set; }
        [Display(Name = "نوع واقعه")]
        public MarriageDivorce MarriageDivorce { get; set; }
        [Display(Name = "تاریخ وقوع")]
        [DataType(DataType.Date)]
        public DateTime? IncidentDate { get; set; }
        [Display(Name = "شماره دفترخانه")]
        public string OfficeNumber { get; set; }
        [Display(Name = "شماره ثبت")]
        public string RegisterNumber { get; set; }
    }
}
