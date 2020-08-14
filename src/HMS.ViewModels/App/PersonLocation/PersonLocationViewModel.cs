using System.ComponentModel.DataAnnotations;

namespace HMS.ViewModels.App
{
    public class PersonLocationViewModel
    {
        [ScaffoldColumn(false)]
        [Display(Name = "شناسه")]
        public int Id { get; set; }
        [ScaffoldColumn(false)]
        [Display(Name = "شناسه فرد")]
        public int PersonId { get; set; }
        [Display(Name = "استان")]
        public int? ProvianceId { get; set; }
        [Display(Name = "استان")]
        public string ProvianceName { get; set; }
        [Display(Name = "شهرستان")]
        public int? TownshipId { get; set; }
        [Display(Name = "شهرستان")]
        public string TownshipName { get; set; }
        [Display(Name = "بخش")]
        public int? SectionId { get; set; }
        [Display(Name = "بخش")]
        public string SectionName { get; set; }
        [Display(Name = "شهر")]
        public int? CityId { get; set; }
        [Display(Name = "شهر")]
        public string CityName { get; set; }
        [Display(Name = "آدرس")]
        [StringLength(1000, MinimumLength = 15, ErrorMessage = "آدرس را باید به صورت کامل وارد نمایید")]
        public string Addres { get; set; }
        [Display(Name = "تلفن ثابت")]
        [RegularExpression("^0[1-9]{2}[1-9]{1}[0-9]{7}$", ErrorMessage = "لطفا شماره تلفن ثابت را به شکل صحیح وارد کنید")]
        public string Phone { get; set; }
        [Display(Name = "تلفن همراه")]
        [StringLength(11, ErrorMessage = "شماره همراه باید حداکثر 11 کاراکتر باشد")]
        //[RegularExpression("09(1[0-9]|3[1-9]|2[1-9])-?[0-9]{3}-?[0-9]{4}", ErrorMessage = "لطفا شماره همراه را به شکل صحیح وارد کنید")]
        public string Mobile { get; set; }
        [Display(Name = "رایانامه شخصی")]
        [EmailAddress(ErrorMessage = "لطفا {0} معتبر را وارد نمایید")]
        public string PersonalEmail { get; set; }
        [Display(Name = "رایانامه سازمانی")]
        [EmailAddress(ErrorMessage = "لطفا {0} معتبر را وارد نمایید")]
        public string OrganizationEmail { get; set; }
    }
}
