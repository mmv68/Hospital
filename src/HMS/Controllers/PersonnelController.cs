using System;
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
    [DisplayName("مدیریت و نگهداری اطلاعات پرسنلی")]
    public class PersonnelController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public PersonnelController(ApplicationDbContext context,IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        // GET: Personnel
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetPersonnel(DataSourceRequest request, int id)
        {
            return Json((_mapper.Map<List<PersonnelViewModel>>
            (_context.Personnel.Where(x => x.PersonId == id)
                .Include(p=>p.Condition)
                .Include(p=>p.MembershipType)
                .Include(p=>p.Structure)
                .ToList())).ToDataSourceResult(request));
        }

        // GET: Personnel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personnel = await _context.Personnel
                .Include(p => p.Condition)
                .Include(p => p.MembershipType)
                .Include(p => p.MilitaryBranch)
                .Include(p => p.Person)
                .Include(p => p.Structure)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personnel == null)
            {
                return NotFound();
            }

            return View(personnel);
        }

        // GET: Personnel/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Personnel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create (Personnel personnel)
        {
            if (!ModelState.IsValid) return PartialView("_Create",_mapper.Map<PersonnelViewModel>(personnel));
            _context.Add(personnel);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return Content("Success");
        }

        // GET: Personnel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personnel = await _context.Personnel.FindAsync(id);
            if (personnel == null)
            {
                return NotFound();
            }
            ViewData["ConditionId"] = new SelectList(_context.BaseInformations, "Id", "Title", personnel.ConditionId);
            ViewData["MembershipTypeId"] = new SelectList(_context.BaseInformations, "Id", "Title", personnel.MembershipTypeId);
            ViewData["MilitaryBranchId"] = new SelectList(_context.BaseInformations, "Id", "Title", personnel.MilitaryBranchId);
            ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "FatherName", personnel.PersonId);
            ViewData["StructureId"] = new SelectList(_context.Structures, "Id", "Id", personnel.StructureId);
            return View(personnel);
        }

        // POST: Personnel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PersonId,StructureId,Code,CardNumber,ExportDate,MembershipTypeId,MembershipDate,EntryDateCorps,EntryDateHealthcare,EntryDateTreatmentcenter,TransferInDate,TransferOutDate,MilitaryBranchId,DegreeApproved,DegreeSalary,Rating,ConditionId,JobCode,JobName")] Personnel personnel)
        {
            if (id != personnel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personnel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonnelExists(personnel.Id))
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
            ViewData["ConditionId"] = new SelectList(_context.BaseInformations, "Id", "Title", personnel.ConditionId);
            ViewData["MembershipTypeId"] = new SelectList(_context.BaseInformations, "Id", "Title", personnel.MembershipTypeId);
            ViewData["MilitaryBranchId"] = new SelectList(_context.BaseInformations, "Id", "Title", personnel.MilitaryBranchId);
            ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "FatherName", personnel.PersonId);
            ViewData["StructureId"] = new SelectList(_context.Structures, "Id", "Id", personnel.StructureId);
            return View(personnel);
        }

        // GET: Personnel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personnel = await _context.Personnel
                .Include(p => p.Condition)
                .Include(p => p.MembershipType)
                .Include(p => p.MilitaryBranch)
                .Include(p => p.Person)
                .Include(p => p.Structure)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personnel == null)
            {
                return NotFound();
            }

            return View(personnel);
        }

        // POST: Personnel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personnel = await _context.Personnel.FindAsync(id);
            _context.Personnel.Remove(personnel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonnelExists(int id)
        {
            return _context.Personnel.Any(e => e.Id == id);
        }
    }
}
