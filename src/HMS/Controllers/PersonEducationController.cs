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
        private readonly ApplicationDbContext _context;
        private readonly IPersonEducationService _personEducationService;
        private readonly IMapper _mapper;
      
        public PersonEducationController(ApplicationDbContext context, IPersonEducationService personEducationService, IUnitOfWork uow, IMapper mapper)
        {
            _context = context;
            _personEducationService = personEducationService;
            _mapper = mapper;
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

        // POST: PersonEducation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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
                    if (!PersonEducationExists(personEducation.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                //return RedirectToAction(nameof(Index));
            return Content("Success");
        }

        // GET: PersonEducation/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personEducation = await _context.PersonEducations
                .Include(p => p.CertificateType)
                .Include(p => p.Department)
                .Include(p => p.FieldStudy)
                .Include(p => p.Person)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personEducation == null)
            {
                return NotFound();
            }

            return View(personEducation);
        }

        // POST: PersonEducation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personEducation = await _context.PersonEducations.FindAsync(id);
            _context.PersonEducations.Remove(personEducation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonEducationExists(int id)
        {
            return _context.PersonEducations.Any(e => e.Id == id);
        }
    }
}
