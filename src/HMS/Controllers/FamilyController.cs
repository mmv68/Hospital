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
    public class FamilyController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FamilyController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Family
        public async Task<IActionResult> Index()
        {
            return View();
        }

        // GET: Family/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Persons
                .Include(p => p.BrithPlaceCity)
                .Include(p => p.BrithPlaceProviance)
                .Include(p => p.Parent)
                .Include(p => p.Relation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // GET: Family/Create
        public IActionResult Create()
        {
            ViewData["BrithPlaceCityId"] = new SelectList(_context.BaseInformations, "Id", "Title");
            ViewData["BrithPlaceProvianceId"] = new SelectList(_context.BaseInformations, "Id", "Title");
            ViewData["ParentId"] = new SelectList(_context.Persons, "Id", "FatherName");
            ViewData["RelationId"] = new SelectList(_context.BaseInformations, "Id", "Title");
            return View();
        }

        // POST: Family/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ParentId,FirstName,LastName,FatherName,MotherName,IdentityNumber,IdentitySeries,IdentitySeriesNumber,IdentitySerial,NationalCode,BrithDate,BrithPlaceProvianceId,BrithPlaceCityId,Religion,Denomation,Sex,RelationId,Timestamp")] Person person)
        {
            if (ModelState.IsValid)
            {
                _context.Add(person);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrithPlaceCityId"] = new SelectList(_context.BaseInformations, "Id", "Title", person.BrithPlaceCityId);
            ViewData["BrithPlaceProvianceId"] = new SelectList(_context.BaseInformations, "Id", "Title", person.BrithPlaceProvianceId);
            ViewData["ParentId"] = new SelectList(_context.Persons, "Id", "FatherName", person.ParentId);
            ViewData["RelationId"] = new SelectList(_context.BaseInformations, "Id", "Title", person.RelationId);
            return View(person);
        }

        // GET: Family/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Persons.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            ViewData["BrithPlaceCityId"] = new SelectList(_context.BaseInformations, "Id", "Title", person.BrithPlaceCityId);
            ViewData["BrithPlaceProvianceId"] = new SelectList(_context.BaseInformations, "Id", "Title", person.BrithPlaceProvianceId);
            ViewData["ParentId"] = new SelectList(_context.Persons, "Id", "FatherName", person.ParentId);
            ViewData["RelationId"] = new SelectList(_context.BaseInformations, "Id", "Title", person.RelationId);
            return View(person);
        }

        // POST: Family/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ParentId,FirstName,LastName,FatherName,MotherName,IdentityNumber,IdentitySeries,IdentitySeriesNumber,IdentitySerial,NationalCode,BrithDate,BrithPlaceProvianceId,BrithPlaceCityId,Religion,Denomation,Sex,RelationId,Timestamp")] Person person)
        {
            if (id != person.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(person);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonExists(person.Id))
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
            ViewData["BrithPlaceCityId"] = new SelectList(_context.BaseInformations, "Id", "Title", person.BrithPlaceCityId);
            ViewData["BrithPlaceProvianceId"] = new SelectList(_context.BaseInformations, "Id", "Title", person.BrithPlaceProvianceId);
            ViewData["ParentId"] = new SelectList(_context.Persons, "Id", "FatherName", person.ParentId);
            ViewData["RelationId"] = new SelectList(_context.BaseInformations, "Id", "Title", person.RelationId);
            return View(person);
        }

        // GET: Family/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Persons
                .Include(p => p.BrithPlaceCity)
                .Include(p => p.BrithPlaceProviance)
                .Include(p => p.Parent)
                .Include(p => p.Relation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // POST: Family/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var person = await _context.Persons.FindAsync(id);
            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonExists(int id)
        {
            return _context.Persons.Any(e => e.Id == id);
        }
    }
}
