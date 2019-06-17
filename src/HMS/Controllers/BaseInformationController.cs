using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using HMS.Services.Contracts.App;
using System;

namespace HMS.Controllers
{
    public class BaseInformationController : Controller
    {
        private readonly IBaseInformationService _baseInformationService;
        //private readonly IUnitOfWork _uow;

        public BaseInformationController(IBaseInformationService baseInformationService)
        {
            _baseInformationService = baseInformationService?? throw new ArgumentNullException(nameof(baseInformationService));
            //_uow = uow;
        }
        [DisplayName("بازیابی لیست های انخابی ")]
        public JsonResult GetBaseInformation(int id, int? parentid)
        {
            return Json(parentid != null ? _baseInformationService.SelectListBaseInformations(id, (int)parentid) : _baseInformationService.SelectListBaseInformations(id));
        }

    }
}
