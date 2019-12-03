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
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Authorization;

namespace HMS.Controllers
{
    [Authorize(Policy = ConstantPolicies.DynamicPermission)]
    [DisplayName("مدیریت و نگهداری اطلاعات تکمیلی")]
    public class PersonAdditionalInformationController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PersonAdditionalInformationController(ApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        // GET: PersonAdditionalInformation
        public IActionResult Index(int id, string title)
        {
            return View();
        }
        public JsonResult GetPersonAdditionalInformation(DataSourceRequest request, int id)
        {
            return Json(_context.PersonAdditionalInformations.Where(x => x.PersonId == id)
                .ToList().ToDataSourceResult(request));
        }

        // GET: PersonAdditionalInformation/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personAdditionalInformation = await _context.PersonAdditionalInformations
                .Include(p => p.Person)
                .FirstOrDefaultAsync(m => m.PersonId == id);
            if (personAdditionalInformation == null)
            {
                return NotFound();
            }

            return View(personAdditionalInformation);
        }

        // GET: PersonAdditionalInformation/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PersonAdditionalInformation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( PersonAdditionalInformation personAdditionalInformation)
        {
            if (!ModelState.IsValid) return PartialView("_Create");
            _context.Add(personAdditionalInformation);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return Content("Success");
        }

        // GET: PersonAdditionalInformation/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personAdditionalInformation = await _context.PersonAdditionalInformations.FindAsync(id).ConfigureAwait(false);
            if (personAdditionalInformation == null)
            {
                return NotFound();
            }
            return View(personAdditionalInformation);
        }

        // POST: PersonAdditionalInformation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,PersonAdditionalInformation personAdditionalInformation)
        {
            if (id != personAdditionalInformation.PersonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personAdditionalInformation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonAdditionalInformationExists(personAdditionalInformation.PersonId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Content("Success");
            }
            return PartialView("_Create");
        }

        // GET: PersonAdditionalInformation/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personAdditionalInformation = await _context.PersonAdditionalInformations
                .Include(p => p.Person)
                .FirstOrDefaultAsync(m => m.PersonId == id);
            if (personAdditionalInformation == null)
            {
                return NotFound();
            }

            return View(personAdditionalInformation);
        }

        // POST: PersonAdditionalInformation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personAdditionalInformation = await _context.PersonAdditionalInformations.FindAsync(id);
            _context.PersonAdditionalInformations.Remove(personAdditionalInformation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonAdditionalInformationExists(int id)
        {
            return _context.PersonAdditionalInformations.Any(e => e.PersonId == id);
        }
    }
}
