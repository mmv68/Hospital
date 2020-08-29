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
using HMS.Services.Identity;
using HMS.ViewModels.App;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using Microsoft.AspNetCore.Authorization;
using HMS.Services.Contracts.App;

namespace HMS.Controllers
{
    [Authorize(Policy = ConstantPolicies.DynamicPermission)]
    [DisplayName("مدیریت و نگهداری اطلاعات تأهل")]
    public class PersonMarriageController : Controller
    {
        private readonly IPersonMarriageService _personMarriageService;
        public PersonMarriageController(IPersonMarriageService personMarriageService)
        {
            _personMarriageService = personMarriageService;
        }

        [DisplayName("لیست تأهل")]
        public IActionResult Index(int id, string title)
        {
            return View();
        }
        [DisplayName("بازیابی لیست تأهل")]
        public JsonResult GetPersonMarriage(DataSourceRequest request, int id)
        {
            return Json(_personMarriageService.GetPersonMarriages(request,id).Result);
        }

        [DisplayName("فرم ایجاد تأهل")]
        public IActionResult Create()
        {
            return View();
        }

        [DisplayName("ایجاد تأهل")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PersonMarriageViewModel personMarriage)
        {
            if (!ModelState.IsValid) return PartialView("_Create");
            await _personMarriageService.AddNewPersonMarriage(personMarriage).ConfigureAwait(false);
            return Content("Success");
        }

        [DisplayName("فرم ویرایش تأهل")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var personMarriage = await _personMarriageService.FindPersonMarriageById((int)id);
            if (personMarriage == null) return NotFound();
            return View(personMarriage);
        }

        [DisplayName("ویرایش  تأهل")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, PersonMarriageViewModel personMarriage)
        {
            if (id != personMarriage.Id) return NotFound();
            if (!ModelState.IsValid) return View(personMarriage);
                try
                {
                _personMarriageService.UpdatePersonMarriage(personMarriage);
                }
                catch (DbUpdateConcurrencyException)
                {
                   
                }
            return Content("Success");
        }

        [DisplayName("فرم حذف تأهل")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var personMarriage = await _personMarriageService.FindPersonMarriageById((int)id);
            if (personMarriage == null) return NotFound();
            return View(personMarriage);
        }

        [DisplayName("حذف تأهل")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _personMarriageService.DeletePersonMarriage(id);
            return Content("success");
        }
    }
}
