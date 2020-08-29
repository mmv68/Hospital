using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HMS.DataLayer.Context;
using HMS.Entities.App;
using HMS.Services.Contracts.App;
using HMS.Services.Identity;
using HMS.ViewModels.App;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Authorization;

namespace HMS.Controllers
{
    [Authorize(Policy = ConstantPolicies.DynamicPermission)]
    [DisplayName("مدیریت و نگهداری محل سکونت")]
    public class PersonLocationController : Controller
    {
        private readonly IPersonLocationService _personLocationService;
        public PersonLocationController( IPersonLocationService personLocationService)
        {
            _personLocationService = personLocationService;
        }

        [DisplayName("لیست محل های سکونت")]
        public IActionResult Index(int id, string title)
        {
            return View();
        }
        [DisplayName("بازیابی محل های سکونت")]
        public JsonResult GetPersonLocation(DataSourceRequest request, int id)
        {
            return Json(_personLocationService.GetPersonLocations(request, id).Result);
        }

        [DisplayName("فرم ایجاد محل های سکونت")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [DisplayName("ایجاد محل های سکونت")]
        public async Task<IActionResult> Create(PersonLocationViewModel personLocation)
        {
            if (!ModelState.IsValid) return PartialView("_Create", personLocation);
            await _personLocationService.AddNewPersonLocation(personLocation).ConfigureAwait(false);
            return Content("Success");

        }

        [DisplayName("فرم ویرایش محل های سکونت")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var personLocation = await _personLocationService.FindPersonLocationById((int)id);
            if (personLocation == null) return NotFound();
            return View(personLocation);
        }

        [DisplayName("ویرایش محل های سکونت")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, PersonLocationViewModel personLocation)
        {
            if (id != personLocation.Id) return NotFound();
            if (!ModelState.IsValid) return View(personLocation);
                try
                {
                _personLocationService.UpdatePersonLocation(personLocation);
                }
                catch (DbUpdateConcurrencyException)
                {

                }
            return Content("Success");
        }

        [DisplayName("فرم حذف محل های سکونت")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var personLocation = await _personLocationService.FindPersonLocationById((int)id);
            if (personLocation == null) return NotFound();
            return View(personLocation);
        }

        [DisplayName("حذف محل های سکونت")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _personLocationService.DeletePersonLocation(id);
            return Content("success");
        }
    }
}
