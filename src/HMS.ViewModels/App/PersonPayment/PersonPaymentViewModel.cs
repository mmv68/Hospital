using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HMS.ViewModels.App
{
    public class PersonPaymentViewModel
    {
        [ScaffoldColumn(false)]
        [Display(Name = "شناسه")]
        public int id { get; set; }
        [ScaffoldColumn(false)]
        [Display(Name = "شناسه فرد")]
        public int PersonId { get; set; }
        [Display(Name = "شماره حساب")]
        [StringLength(24, MinimumLength = 5, ErrorMessage = "شماره حساب  باید بین 5 تا 24 رقم باشد")]
        public string AccountNumber { get; set; }
        [Display(Name = "شماره کارت")]
        [RegularExpression("[0-9]{16}", ErrorMessage = "لطفا شماره کارت را به شکل صحیح وارد کنید")]
        public string CardNumber { get; set; }
        [Display(Name = "شماره شبا")]
        public string ShabaNumber { get; set; }

    }
}
