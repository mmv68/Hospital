﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HMS.DataLayer.Context;
using HMS.Entities.App;
using HMS.Services.Identity;
using Microsoft.AspNetCore.Authorization;

namespace HMS.Controllers
{
    [Authorize(Policy = ConstantPolicies.DynamicPermission)]
    [DisplayName("مدیریت و نگهداری محل سکونت")]
    public class PersonLocationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PersonLocationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PersonLocation
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PersonLocations.Include(p => p.City).Include(p => p.Person).Include(p => p.Proviance).Include(p => p.Section).Include(p => p.Township);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PersonLocation/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personLocation = await _context.PersonLocations
                .Include(p => p.City)
                .Include(p => p.Person)
                .Include(p => p.Proviance)
                .Include(p => p.Section)
                .Include(p => p.Township)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personLocation == null)
            {
                return NotFound();
            }

            return View(personLocation);
        }

        // GET: PersonLocation/Create
        public IActionResult Create()
        {
            ViewData["CityId"] = new SelectList(_context.BaseInformations, "Id", "Title");
            ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "FatherName");
            ViewData["ProvianceId"] = new SelectList(_context.BaseInformations, "Id", "Title");
            ViewData["SectionId"] = new SelectList(_context.BaseInformations, "Id", "Title");
            ViewData["TownshipId"] = new SelectList(_context.BaseInformations, "Id", "Title");
            return View();
        }

        // POST: PersonLocation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PersonId,ProvianceId,TownshipId,SectionId,CityId,Addres,Phone,Mobile,PersonalEmail,OrganizationEmail")] PersonLocation personLocation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personLocation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CityId"] = new SelectList(_context.BaseInformations, "Id", "Title", personLocation.CityId);
            ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "FatherName", personLocation.PersonId);
            ViewData["ProvianceId"] = new SelectList(_context.BaseInformations, "Id", "Title", personLocation.ProvianceId);
            ViewData["SectionId"] = new SelectList(_context.BaseInformations, "Id", "Title", personLocation.SectionId);
            ViewData["TownshipId"] = new SelectList(_context.BaseInformations, "Id", "Title", personLocation.TownshipId);
            return View(personLocation);
        }

        // GET: PersonLocation/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personLocation = await _context.PersonLocations.FindAsync(id);
            if (personLocation == null)
            {
                return NotFound();
            }
            ViewData["CityId"] = new SelectList(_context.BaseInformations, "Id", "Title", personLocation.CityId);
            ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "FatherName", personLocation.PersonId);
            ViewData["ProvianceId"] = new SelectList(_context.BaseInformations, "Id", "Title", personLocation.ProvianceId);
            ViewData["SectionId"] = new SelectList(_context.BaseInformations, "Id", "Title", personLocation.SectionId);
            ViewData["TownshipId"] = new SelectList(_context.BaseInformations, "Id", "Title", personLocation.TownshipId);
            return View(personLocation);
        }

        // POST: PersonLocation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PersonId,ProvianceId,TownshipId,SectionId,CityId,Addres,Phone,Mobile,PersonalEmail,OrganizationEmail")] PersonLocation personLocation)
        {
            if (id != personLocation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personLocation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonLocationExists(personLocation.Id))
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
            ViewData["CityId"] = new SelectList(_context.BaseInformations, "Id", "Title", personLocation.CityId);
            ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "FatherName", personLocation.PersonId);
            ViewData["ProvianceId"] = new SelectList(_context.BaseInformations, "Id", "Title", personLocation.ProvianceId);
            ViewData["SectionId"] = new SelectList(_context.BaseInformations, "Id", "Title", personLocation.SectionId);
            ViewData["TownshipId"] = new SelectList(_context.BaseInformations, "Id", "Title", personLocation.TownshipId);
            return View(personLocation);
        }

        // GET: PersonLocation/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personLocation = await _context.PersonLocations
                .Include(p => p.City)
                .Include(p => p.Person)
                .Include(p => p.Proviance)
                .Include(p => p.Section)
                .Include(p => p.Township)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personLocation == null)
            {
                return NotFound();
            }

            return View(personLocation);
        }

        // POST: PersonLocation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personLocation = await _context.PersonLocations.FindAsync(id);
            _context.PersonLocations.Remove(personLocation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonLocationExists(int id)
        {
            return _context.PersonLocations.Any(e => e.Id == id);
        }
    }
}
