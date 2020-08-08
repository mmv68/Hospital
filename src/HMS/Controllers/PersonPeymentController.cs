using System;
using System.ComponentModel;
using System.Threading.Tasks;
using AutoMapper;
using HMS.DataLayer.Context;
using HMS.Services.Contracts.App;
using HMS.Services.Identity;
using HMS.ViewModels.App;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HMS.Controllers
{
    [Authorize(Policy = ConstantPolicies.DynamicPermission)]
    [DisplayName("مدیریت و نگهداری اطلاعات مالی")]
    public class PersonPeymentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IPersonPaymentService _personPaymentService;
        private readonly IMapper _mapper;
        public PersonPeymentController(ApplicationDbContext context, IPersonPaymentService personPaymentService, IMapper mapper)
        {
            _context = context;
            _personPaymentService = personPaymentService;
            _mapper = mapper;
        }
        [DisplayName("لیست اطلاعات بانکی")]
        public IActionResult Index(int id, string title)
        {
            return View();
        }
        [DisplayName("فرم ایجاد اطلاعات بانکی")]
        public IActionResult Create()
        {
            return View();
        }
        [DisplayName(" بازیابی اطلاعات بانکی ")]
        public JsonResult GetPersonPayment(DataSourceRequest request, int id)
        {
            return Json(_personPaymentService.FindPersonPaymentsById(request,id).Result);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [DisplayName("ایجاداطلاعات بانکی")]
        public async Task<IActionResult> Create(PersonPaymentViewModel personPayment)
        {
            if (!ModelState.IsValid) return PartialView("_Create", personPayment);
            await _personPaymentService.AddNewPersonPayment(personPayment).ConfigureAwait(false);
            return Content("Success");
        }
        [DisplayName("فرم ویرایش اطلاعات بانکی")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var payment = await _personPaymentService.FindPeymentByID((int)id).ConfigureAwait(false);
            if (payment == null) return NotFound();
            return View(payment);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [DisplayName("ویرایش اطلاعات بانکی")]
        //[BreadCrumb(Order = 1)]
        public IActionResult Edit(int id, PersonPaymentViewModel person)
        {
            if (id != person.Id) return NotFound();
            if (!ModelState.IsValid) return View(person);
                try
                {
                _personPaymentService.UpdatePersonPayment(person);
            }
                catch (Exception ex)
                {
                //if (!_personPaymentService.IsPersonExist(person.Id).Result)
                //{
                //    return NotFound();
                //}
                //else
                //{
                    return Content(ex.Message);
                //}
            }
            return Content("Success");
        }
        [DisplayName("فرم حذف اطلاعات بانکی")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var person = await _personPaymentService.FindPeymentByID((int)id);
            if (person == null) return NotFound();
            return View(person);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [DisplayName("حذف اطلاعات بانکی")]
        public IActionResult DeleteConfirmed(int id)
        {
            _personPaymentService.DeletePersonPayment(id);
            return Content("success");
        }
    }
}
