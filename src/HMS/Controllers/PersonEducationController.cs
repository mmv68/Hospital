using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HMS.DataLayer.Context;
using HMS.Entities.App;
using Kendo.Mvc.UI;

namespace HMS.Controllers
{
    public class PersonEducationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PersonEducationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PersonEducation
        public IActionResult Index()
        {
            //var applicationDbContext = _context.PersonEducations.Include(p => p.CertificateType).Include(p => p.Department).Include(p => p.FieldStudy).Include(p => p.Person);
            //return View(await applicationDbContext.ToListAsync());
            return View();
        }

        public JsonResult GetPersonEducation(DataSourceRequest request)
        {
            return Json("");
        }
        // GET: PersonEducation/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: PersonEducation/Create
        public IActionResult Create()
        {
            ViewData["CertificateTypeId"] = new SelectList(_context.BaseInformations, "Id", "Title");
            ViewData["DepartmentId"] = new SelectList(_context.BaseInformations, "Id", "Title");
            ViewData["FieldStudyId"] = new SelectList(_context.BaseInformations, "Id", "Title");
            ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "FatherName");
            return View();
        }

        // POST: PersonEducation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PersonId,CertificateTypeId,DepartmentId,FieldStudyId,UniversityType,UniversityName,GraduatedDate,Average,Applied")] PersonEducation personEducation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personEducation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CertificateTypeId"] = new SelectList(_context.BaseInformations, "Id", "Title", personEducation.CertificateTypeId);
            ViewData["DepartmentId"] = new SelectList(_context.BaseInformations, "Id", "Title", personEducation.DepartmentId);
            ViewData["FieldStudyId"] = new SelectList(_context.BaseInformations, "Id", "Title", personEducation.FieldStudyId);
            ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "FatherName", personEducation.PersonId);
            return View(personEducation);
        }

        // GET: PersonEducation/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personEducation = await _context.PersonEducations.FindAsync(id);
            if (personEducation == null)
            {
                return NotFound();
            }
            ViewData["CertificateTypeId"] = new SelectList(_context.BaseInformations, "Id", "Title", personEducation.CertificateTypeId);
            ViewData["DepartmentId"] = new SelectList(_context.BaseInformations, "Id", "Title", personEducation.DepartmentId);
            ViewData["FieldStudyId"] = new SelectList(_context.BaseInformations, "Id", "Title", personEducation.FieldStudyId);
            ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "FatherName", personEducation.PersonId);
            return View(personEducation);
        }

        // POST: PersonEducation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PersonId,CertificateTypeId,DepartmentId,FieldStudyId,UniversityType,UniversityName,GraduatedDate,Average,Applied")] PersonEducation personEducation)
        {
            if (id != personEducation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personEducation);
                    await _context.SaveChangesAsync();
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
                return RedirectToAction(nameof(Index));
            }
            ViewData["CertificateTypeId"] = new SelectList(_context.BaseInformations, "Id", "Title", personEducation.CertificateTypeId);
            ViewData["DepartmentId"] = new SelectList(_context.BaseInformations, "Id", "Title", personEducation.DepartmentId);
            ViewData["FieldStudyId"] = new SelectList(_context.BaseInformations, "Id", "Title", personEducation.FieldStudyId);
            ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "FatherName", personEducation.PersonId);
            return View(personEducation);
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
