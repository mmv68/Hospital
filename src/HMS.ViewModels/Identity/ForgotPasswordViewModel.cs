using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace HMS.ViewModels.Identity
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "(*)")]
        [Display(Name = "نام کاربری")]
        [Remote("ValidateUserName", "ForgotPassword",
            AdditionalFields = nameof(UserName) + "," + ViewModelConstants.AntiForgeryToken, HttpMethod = "POST")]
        public string UserName { get; set; }
    }
}