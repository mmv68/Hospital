using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace HMS.ViewModels.Identity
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "(*)")]
        [Display(Name = "نام کاربری")]
        [Remote("ValidateUsername", "Register",
            AdditionalFields = nameof(Username) + "," + ViewModelConstants.AntiForgeryToken, HttpMethod = "POST")]
        [RegularExpression("^[a-zA-Z_]*$", ErrorMessage = "لطفا تنها از حروف انگلیسی استفاده نمائید")]
        public string Username { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "(*)")]
        [StringLength(450)]
        [RegularExpression(@"^[\u0600-\u06FF,\u0590-\u05FF\s]*$",
                          ErrorMessage = "لطفا تنها از حروف فارسی استفاده نمائید")]
        public string FirstName { get; set; }

        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "(*)")]
        [StringLength(450)]
        [RegularExpression(@"^[\u0600-\u06FF,\u0590-\u05FF\s]*$",
                          ErrorMessage = "لطفا تنها از حروف فارسی استفاده نمائید")]
        public string LastName { get; set; }

        [Display(Name = "سطح دسترسی")]
        //[Required(ErrorMessage = "(سطح دسترسی را مشخص نمایید)")]
        public string Location { get; set; }

        [Required(ErrorMessage = "(*)")]
        [StringLength(100, ErrorMessage = "{0} باید حداقل {2} و حداکثر {1} حرف باشند.", MinimumLength = 6)]
        [Remote("ValidatePassword", "Register",
            AdditionalFields = nameof(Username) + "," + ViewModelConstants.AntiForgeryToken, HttpMethod = "POST")]
        [DataType(DataType.Password)]
        [Display(Name = "کلمه‌ی عبور")]
        public string Password { get; set; }

        [Required(ErrorMessage = "(*)")]
        [DataType(DataType.Password)]
        [Display(Name = "تکرار کلمه‌ی عبور")]
        [Compare(nameof(Password), ErrorMessage = "کلمات عبور وارد شده با هم تطابق ندارند")]
        public string ConfirmPassword { get; set; }
    }
}