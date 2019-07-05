using System;
using System.ComponentModel.DataAnnotations;

namespace HMS.ViewModels.App
{
    public class PersonnelViewModel
    {
        [ScaffoldColumn(false)]
        [Display(Name = "شناسه")]
        public int Id { get; set; }
        [ScaffoldColumn(false)]
        [Display(Name = "شناسه فرد")]
        public int PersonId { get; set; }
        [Display(Name = "رده")]
        [Required(ErrorMessage = "ورود رده فرد اجباری می باشد!")]
        public ushort StructureId { get; set; }
        [Display(Name = "کد پرسنلی")]
        [MaxLength(10,ErrorMessage = "محدودیت شما در ورود تعداد ارقام 10 می باشد!")]
        public string Code { get; set; }
        [Display(Name = "کد کارت")]
        [MaxLength(10, ErrorMessage = "محدودیت شما در ورود تعداد ارقام 10 می باشد!")]
        public string CardNumber { get; set; }
        [Display(Name = "تاریخ صدور")]
        public DateTime? ExportDate { get; set; }
        [Display(Name = "نوع عضویت")]
        public int? MembershipTypeId { get; set; }
        [Display(Name = "تاریخ عضویت")]
        public DateTime? MembershipDate { get; set; }
        [Display(Name = "تاریخ ورود به سپاه")]
        public DateTime? EntryDateCorps { get; set; }
        [Display(Name = "تاریخ ورود به ف بهی")]
        public DateTime? EntryDateHealthcare { get; set; }
        [Display(Name = "تاریخ ورود به مرکز درمانی")]
        public DateTime? EntryDateTreatmentcenter { get; set; }
        [Display(Name = "تاریخ انتقال به نیرو")]
        public DateTime? TransferInDate { get; set; }
        [Display(Name = "تاریخ انتقال از نیرو")]
        public DateTime? TransferOutDate { get; set; }
        [Display(Name = "رسته")]
        public int? MilitaryBranchId { get; set; }
        [Display(Name = "درجه مصوب")]
        public byte? DegreeApproved { get; set; }
        [Display(Name = "درجه حقوق")]
        public byte? DegreeSalary { get; set; }
        [Display(Name = "رتبه")]
        public byte? Rating { get; set; }
        [Display(Name = "وضعیت خدمتی")]
        public int? ConditionId { get; set; }
        [Display(Name = "کد شغل")]
        public string JobCode { get; set; }
        [Display(Name = "نام شغل")]
        public string JobName { get; set; }
    }
}
