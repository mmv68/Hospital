using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HMS.DataLayer.Context;
using HMS.Entities.App;
using HMS.ViewModels.App;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace HMS.Controllers
{
    public class PersonMarriageController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PersonMarriageController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: PersonMarriage
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult GetPersonMarriage(DataSourceRequest request, int id)
        {
            return Json((_mapper.Map<List<PersonMarriageViewModel>>
            (_context.PersonMarriages.Where(x => x.PersonId == id)
                .ToList())).ToDataSourceResult(request));
        }
        // GET: PersonMarriage/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personMarriage = await _context.PersonMarriages
                .Include(p => p.Person)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personMarriage == null)
            {
                return NotFound();
            }

            return View();
        }

        // GET: PersonMarriage/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PersonMarriage/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PersonMarriage personMarriage)
        {
            if (!ModelState.IsValid) return PartialView("_Create");
            _context.Add(personMarriage);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return Content("Success");
        }

        // GET: PersonMarriage/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personMarriage = await _context.PersonMarriages.FindAsync(id);
            if (personMarriage == null)
            {
                return NotFound();
            }
            ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "FatherName", personMarriage.PersonId);
            return View();
        }

        // POST: PersonMarriage/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PersonId,MarriageDivorce,IncidentDate,OfficeNumber,RegisterNumber")] PersonMarriage personMarriage)
        {
            if (id != personMarriage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personMarriage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonMarriageExists(personMarriage.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "FatherName", personMarriage.PersonId);
            return View();
        }

        // GET: PersonMarriage/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personMarriage = await _context.PersonMarriages
                .Include(p => p.Person)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personMarriage == null)
            {
                return NotFound();
            }

            return View();
        }

        // POST: PersonMarriage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personMarriage = await _context.PersonMarriages.FindAsync(id);
            _context.PersonMarriages.Remove(personMarriage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonMarriageExists(int id)
        {
            return _context.PersonMarriages.Any(e => e.Id == id);
        }
    }
}
