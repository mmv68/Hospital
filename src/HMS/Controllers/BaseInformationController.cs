using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using HMS.Services.Contracts.App;
using System;
using System.Diagnostics;
using HMS.Entities.App;
using HMS.Services.Identity;
using Microsoft.AspNetCore.Authorization;

namespace HMS.Controllers
{
    [Authorize(Policy = ConstantPolicies.DynamicPermission)]
    [DisplayName("مدیریت و نگهداری تعاریف اولیه")]
    public class BaseInformationController : Controller
    {
        private readonly IBaseInformationService _baseInformationService;

        public BaseInformationController(IBaseInformationService baseInformationService)
        {
            _baseInformationService = baseInformationService?? throw new ArgumentNullException(nameof(baseInformationService));
        }
        [DisplayName("بازیابی لیست های انخابی ")]
        public JsonResult GetBaseInformation(int id, int? parentid)
        {
            return Json(parentid != null ? _baseInformationService.SelectListBaseInformations(id, (int)parentid) : _baseInformationService.SelectListBaseInformations(id));
        }
        [DisplayName("اطلاعات پایه سیستم")]
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult GetTreeBaseInformation(int? id)
        {
            return Json(_baseInformationService.GetBaseInformations(id).Value);
        }
         public JsonResult SetBaseInformation(BaseInformation baseInformation)
         {
             Debug.Assert(baseInformation.ParentId != null, "baseInformation.ParentId != null");
             var lastBaseInformation= _baseInformationService.FindLastBaseInformation((int)baseInformation.ParentId);
             baseInformation.Value = (short?)(lastBaseInformation.Id+1);
             baseInformation.Type = lastBaseInformation.Title;
             _baseInformationService.AddNewBaseInformation(baseInformation);
             return Json("Success");
         }

    }
}
