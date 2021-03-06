﻿using System.ComponentModel;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HMS.Services.Identity;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Authorization;
using HMS.Services.Contracts.App;
using HMS.ViewModels.App;

namespace HMS.Controllers
{
    [Authorize(Policy = ConstantPolicies.DynamicPermission)]
    [DisplayName("مدیریت و نگهداری تحصیلات")]
    public class PersonEducationController : Controller
    {
        private readonly IPersonEducationService _personEducationService;
      
        public PersonEducationController( IPersonEducationService personEducationService)
        {
            _personEducationService = personEducationService;
        }
        [DisplayName("لیست اطلاعات تحصیلی")]
        public IActionResult Index(int id,string title)
        {
            return View();
        }
        [DisplayName("بازیابی اطلاعات تحصیلی")]
        public JsonResult GetPersonEducation(DataSourceRequest request,int id)
        {
            return Json(_personEducationService.GetPersonEducations(request, id).Result);
        }

        [DisplayName("فرم ایجاد اطلاعات تحصیلی")]
        public IActionResult Create(int personId)
        {
            return View();
        }
        [DisplayName("ایجاد اطلاعات تحصیلی")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PersonEducationViewModel personEducation)
        {
            if (!ModelState.IsValid) return PartialView("_Create", personEducation);
            await _personEducationService.AddNewPersonEducation(personEducation).ConfigureAwait(false);
            return Content("Success");
        }

        [DisplayName("فرم ویرایش اطلاعات تحصیلی")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var personEducation = await _personEducationService.FindPersonEducationById((int)id);
            if (personEducation == null) return NotFound();
            return View(personEducation);
        }

        [DisplayName("ویرایش اطلاعات تحصیلی")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,PersonEducationViewModel personEducation)
        {
            if (id != personEducation.Id) return NotFound();
            if (!ModelState.IsValid) return View(personEducation);
                try
                {
                    _personEducationService.UpdatePersonEducation(personEducation);
                }
                catch (DbUpdateConcurrencyException)
                {

                }
            return Content("Success");
        }

        [DisplayName("فرم حذف اطلاعات تحصیلی")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var personEducation = await _personEducationService.FindPersonEducationById((int)id);
            if (personEducation == null) return NotFound();
            return View(personEducation);
        }

        [DisplayName("حذف اطلاعات تحصیلی")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _personEducationService.DeletePersonEducation(id);
            return Content("success");
        }
    }
}
