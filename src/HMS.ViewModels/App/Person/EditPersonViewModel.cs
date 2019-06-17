using System;
using System.ComponentModel.DataAnnotations;
using DNTPersianUtils.Core;
using Microsoft.AspNetCore.Mvc;
// ReSharper disable CheckNamespace

namespace HMS.ViewModels.App
{
    public class EditPersonViewModel : InsertPersonViewModel
    {
        [Display(Name = "کد ملی")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "کد ملی وارد شده صحیح نمی باشد")]
        [Remote("IsPersonNationalCodeExist", "Person", ErrorMessage = "یک متقاضی با این کد ملی قبلا در سیستم ثبت شده است", HttpMethod = "POST",AdditionalFields = nameof(Id))]
        [ValidIranianNationalCode(ErrorMessage = "کد ملی وارد شده صحیح نمی باشد")]
        [Required(ErrorMessage = "لطفا کد ملی را وارد نمایید")]
        public override String NationalCode { get; set; }

    }
}