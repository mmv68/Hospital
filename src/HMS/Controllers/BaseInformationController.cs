using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using HMS.Services.Contracts.App;
using System;
using HMS.DataLayer.Context;
using HMS.Services.Identity;
using Microsoft.AspNetCore.Authorization;

namespace HMS.Controllers
{
    [Authorize(Policy = ConstantPolicies.DynamicPermission)]
    [DisplayName("مدیریت و نگهداری تعاریف اولیه")]
    public class BaseInformationController : Controller
    {
        private readonly IBaseInformationService _baseInformationService;
        private readonly IUnitOfWork _uow;

        public BaseInformationController(IBaseInformationService baseInformationService,IUnitOfWork uow)
        {
            _baseInformationService = baseInformationService?? throw new ArgumentNullException(nameof(baseInformationService));
            _uow = uow;
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

    }
}
