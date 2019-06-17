using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace HMS.ViewModels.Identity
{
    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "(*)")]
        [Display(Name = "نام کاربری")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "(*)")]
        [StringLength(100, ErrorMessage = "{0} باید حداقل {2} و حداکثر {1} حرف باشند.", MinimumLength = 6)]
        [Remote("ValidatePassword", "ForgotPassword",
            AdditionalFields = nameof(UserName) + "," + ViewModelConstants.AntiForgeryToken, HttpMethod = "POST")]
        [DataType(DataType.Password)]
        [Display(Name = "کلمه‌ی عبور")]
        public string Password { get; set; }

        [Required(ErrorMessage = "(*)")]
        [DataType(DataType.Password)]
        [Display(Name = "تکرار کلمه‌ی عبور")]
        [Compare(nameof(Password), ErrorMessage = "کلمات عبور وارد شده با هم تطابق ندارند")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }
}