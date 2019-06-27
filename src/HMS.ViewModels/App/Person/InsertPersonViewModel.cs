
using System;
using System.ComponentModel.DataAnnotations;
using DNTPersianUtils.Core;
using Microsoft.AspNetCore.Mvc;
using HMS.Entities.Enums;
// ReSharper disable CheckNamespace

namespace HMS.ViewModels.App
{
    public class InsertPersonViewModel
    {
        [ScaffoldColumn(false)]
        [Display(Name = "شناسه")]
        public int Id { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "شناسه سرپرست")]
        public int? ParentId { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا نام  را وارد نمایید")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "نام  باید بین سه تا ۵۰ کاراکتر باشد")]
        [RegularExpression(@"^[\u0600-\u06FF,\u0590-\u05FF,0-9\s]*$", ErrorMessage = "لطفا فقط ازاعداد و حروف  فارسی برای نام  استفاده کنید")]
        public string FirstName { get; set; }

        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "لطفا نام خانوادگی را وارد کنید")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "نام خانوادگی باید بین سه تا ۵۰ کاراکتر باشد")]
        [RegularExpression(@"^[\u0600-\u06FF,\u0590-\u05FF,0-9\s]*$", ErrorMessage = "لطفا فقط ازاعداد و حروف  فارسی برای نام  استفاده کنید")]
        public string LastName { get; set; }

        [Display(Name = "نام پدر")]
        [Required(ErrorMessage = "لطفا نام پدر را وارد نمایید")]
        [RegularExpression(@"^[\u0600-\u06FF,\u0590-\u05FF,0-9\s]*$", ErrorMessage = "لطفا فقط ازاعداد و حروف  فارسی برای نام پدر  استفاده کنید")]
        public String FatherName { get; set; }

        [Display(Name = "نام مادر")]
        [Required(ErrorMessage = "لطفا نام مادر را وارد نمایید")]
        [RegularExpression(@"^[\u0600-\u06FF,\u0590-\u05FF,0-9\s]*$", ErrorMessage = "لطفا فقط ازاعداد و حروف  فارسی برای نام مادر استفاده کنید")]
        public string MotherName { get; set; }

        [Display(Name = "شماره شناسنامه")]
        [Required(ErrorMessage = "لطفا شماره شناسنامه را وارد نمایید")]
        [RegularExpression("[0-9]{2,10}", ErrorMessage = "لطفا شماره شناسنامه را به شکل صحیح وارد کنید")]
        public string IdentityNumber { get; set; }

        [Display(Name = "سری حروفی")]
        [Required(ErrorMessage = "لطفا سری شناسنامه را وارد نمایید")]
        public string IdentitySeries { get; set; }

        [Display(Name = "سری عددی")]
        [Required(ErrorMessage = "لطفا سری شناسنامه را وارد نمایید")]
        public short? IdentitySeriesNumber { get; set; }

        [Display(Name = "سریال شناسنامه")]
        [Required(ErrorMessage = "لطفا سریال شناسنامه را وارد نمایید")]
        [RegularExpression("[0-9]{6}", ErrorMessage = "لطفا سریال شناسنامه را به شکل صحیح وارد کنید")]
        public string IdentitySerial { get; set; }

        [Display(Name = "کد ملی")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "کد ملی وارد شده صحیح نمی باشد")]
        [Remote("IsPersonNationalCodeExist", "Person", ErrorMessage = "یک متقاضی با این کد ملی قبلا در سیستم ثبت شده است", HttpMethod = "POST")]
        [ValidIranianNationalCode(ErrorMessage = "کد ملی وارد شده صحیح نمی باشد")]
        [Required(ErrorMessage = "لطفا کد ملی را وارد نمایید")]
        public virtual String NationalCode { get; set; }

        [Display(Name = "تاریخ تولد")]
        [DataType(DataType.Date)]
        public DateTime? BrithDate { get; set; }

        [Display(Name = "سن")]
        public int? Age { get; private set; }

        [Display(Name = "دین")]
        public Religion? Religion { get; set; }

        [Display(Name = "مذهب")]
        public Denomation? Denomation { get; set; }

        [Display(Name = "جنسیت")]
        public Sex? Sex { get; set; }

        [Display(Name = "استان محل تولد")]
        public int? BrithPlaceProvianceId { get; set; } = null;

        [Display(Name = "استان محل تولد")]
        public string BrithPlaceProvianceName { get; set; }
        
        [Display(Name = "شهرستان محل تولد")]
        public int? BrithPlaceTownshipId { get; set; } = null;

        [Display(Name = "شهرستان محل تولد")]
        public string BrithPlaceTownshipName { get; set; }
        
        [Display(Name = "بخش محل تولد")]
        public int? BrithPlaceSectionId { get; set; } = null;

        [Display(Name = "بخش محل تولد")]
        public string BrithPlaceSectionName { get; set; }

        [Display(Name = "شهرمحل تولد")]
        public int? BrithPlaceCityId { get; set; } = null;

        [Display(Name = "شهرمحل تولد")]
        public string BrithPlaceCityName { get; set; }

        [Display(Name = "نسبت")]
        public short? RelationId { get; set; }
        [ScaffoldColumn(false)]
        public byte[] Timestamp { get; set; }
    }
}