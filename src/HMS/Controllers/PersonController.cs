using System.ComponentModel;
using System.Threading.Tasks;
using DNTBreadCrumb.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HMS.DataLayer.Context;
using HMS.Services.Contracts.App;
using HMS.Services.Identity;
using HMS.ViewModels.App;
using HMS.Common.IdentityToolkit;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System;

namespace HMS.Controllers
{
    [Authorize(Policy = ConstantPolicies.DynamicPermission)]
    [BreadCrumb(UseDefaultRouteUrl = true, Order = 0)]
    [DisplayName("مدیریت و نگهداری سرمایه انسانی")]
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;
        private readonly IUnitOfWork _uow;

        public PersonController(IPersonService personService, IUnitOfWork uow)
        {
            _personService = personService?? throw new ArgumentNullException(nameof(personService));
            _uow = uow?? throw new ArgumentNullException(nameof(uow));
        }


        [DisplayName("اطلاعات سرمایه انسانی")]
        //[BreadCrumb(Order = 1)]
        public IActionResult Index()
        {
            return View();
        }
        [DisplayName(" بازیابی اطلاعات سرمایه انسانی ")]
        public JsonResult GetPersons(DataSourceRequest request)
        {
            return Json(_personService.GetAllPersons().Result.ToDataSourceResult(request));
        }

        //[DisplayName("جزئیات اطلاعات سرمایه انسانی")]
        //[BreadCrumb(Order = 1)]
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var person = await _personService.FindFullPersonByID((int)id)
        //                        .ConfigureAwait(false);
        //    if (person == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(person);
        //}
        [DisplayName("فرم ایجاد اطلاعات سرمایه انسانی")]
        [BreadCrumb(Order = 1)]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [DisplayName("ایجاد اطلاعات سرمایه انسانی")]
        [BreadCrumb(Order = 1)]
        public async Task<IActionResult> Create(InsertPersonViewModel person)
        {
            if (ModelState.IsValid)
            {
                await _personService.AddNewPerson(person).ConfigureAwait(false);
                await _uow.SaveChangesAsync().ConfigureAwait(false);
                return Content("success");
            }
            return PartialView("_Create",person);
        }
        [DisplayName("فرم ویرایش اطلاعات سرمایه انسانی")]
        [BreadCrumb(Order = 1)]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _personService.FindPersonByID((int)id).ConfigureAwait(false);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [DisplayName("ویرایش اطلاعات سرمایه انسانی")]
        [BreadCrumb(Order = 1)]
        public async Task<IActionResult> Edit(int id, EditPersonViewModel person)
        {
            if (id != person.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _personService.UpdatePerson(person);
                    await _uow.SaveChangesAsync().ConfigureAwait(false);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_personService.IsPersonExist(person.Id).Result)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Content("success");
            }
            return View(person);
        }
        [DisplayName("فرم حذف اطلاعات سرمایه انسانی")]
        [BreadCrumb(Order = 1)]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _personService
                                .FindFullPersonByID((int)id).ConfigureAwait(false);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [DisplayName("حذف اطلاعات سرمایه انسانی")]
        [BreadCrumb(Order = 1)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _personService.DeletePerson(id);
            await _uow.SaveChangesAsync().ConfigureAwait(false);
            return Content("success");
        }
        [DisplayName("استعلام وجود کد ملی")]
        public virtual async Task<JsonResult> IsPersonNationalCodeExist(string nationalCode, int? id)
        {
            return Json(!await _personService.IsPersonNationalCodeExist(nationalCode, id).ConfigureAwait(false));
        }     
        [HttpGet]
        [DisplayName("جستجوی اطلاعات سرمایه انسانی")]
        public JsonResult GetPersons(string searchTerm, int pageSize, int pageNum)
        {
            return _personService.GetPersonsAsNoTracking(searchTerm, pageSize, pageNum);
        }
    }

}
