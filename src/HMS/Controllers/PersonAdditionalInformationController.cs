using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HMS.DataLayer.Context;
using HMS.Entities.App;

namespace HMS.Controllers
{
    public class PersonAdditionalInformationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PersonAdditionalInformationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PersonAdditionalInformation
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PersonAdditionalInformations.Include(p => p.Person);
            return View(await applicationDbContext.ToListAsync());
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
            ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "FatherName");
            return View();
        }

        // POST: PersonAdditionalInformation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonId,BloodGroup,HairColor,EyeColor,Weight,Height,ShoeSize,Wrist,ClothingSize,CoverSize,PantsSize")] PersonAdditionalInformation personAdditionalInformation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personAdditionalInformation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "FatherName", personAdditionalInformation.PersonId);
            return View(personAdditionalInformation);
        }

        // GET: PersonAdditionalInformation/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personAdditionalInformation = await _context.PersonAdditionalInformations.FindAsync(id);
            if (personAdditionalInformation == null)
            {
                return NotFound();
            }
            ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "FatherName", personAdditionalInformation.PersonId);
            return View(personAdditionalInformation);
        }

        // POST: PersonAdditionalInformation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PersonId,BloodGroup,HairColor,EyeColor,Weight,Height,ShoeSize,Wrist,ClothingSize,CoverSize,PantsSize")] PersonAdditionalInformation personAdditionalInformation)
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
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "FatherName", personAdditionalInformation.PersonId);
            return View(personAdditionalInformation);
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
