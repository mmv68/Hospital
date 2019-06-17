using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using HMS.DataLayer.Context;
using HMS.Services.Contracts.App;

namespace HMS.Controllers
{
    public class StructureController : Controller
    {
        private readonly IStructureService _structureService;
        private readonly IUnitOfWork _uow;

        public StructureController(IStructureService structureService, IUnitOfWork uow)
        {
            _structureService = structureService;
            _uow = uow;
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
