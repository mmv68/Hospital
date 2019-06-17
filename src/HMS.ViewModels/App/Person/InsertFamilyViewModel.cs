
using System;
using System.ComponentModel.DataAnnotations;
using DNTPersianUtils.Core;
using Microsoft.AspNetCore.Mvc;
using HMS.Entities.Enums;
// ReSharper disable CheckNamespace

namespace HMS.ViewModels.App
{
    public class InsertFamilyViewModel:InsertPersonViewModel
    {
        [ScaffoldColumn(false)]
        [Display(Name = "شناسه سرپرست")]
        public int ParentId { get; set; }
        //public new short Relation { get; set; } = 1;

    }
}