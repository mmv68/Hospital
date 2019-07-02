using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using HMS.DataLayer.Context;
using HMS.Services.Contracts.App;
using HMS.Services.Identity;
using Microsoft.AspNetCore.Authorization;

namespace HMS.Controllers
{
    [Authorize(Policy = ConstantPolicies.DynamicPermission)]
    [DisplayName("مدیریت و نگهداری ساختار")]
    public class StructureController : Controller
    {
        private readonly IStructureService _structureService;

        public StructureController(IStructureService structureService)
        {
            _structureService = structureService;
        }

        [DisplayName("بازیابی لیست ساختار ")]
        public JsonResult GetStructure()
        {
            return Json(_structureService.SelectListStructures());
        }

        [DisplayName("بازیابی لیست درختی ساختار ")]
        public JsonResult GetStructureTree(int? id)
        {
            return Json( _structureService.GetAllStructures(id));
        }
    }
}
