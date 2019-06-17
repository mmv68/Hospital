using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HMS.Common.GuardToolkit;
using HMS.DataLayer.Context;
using HMS.Entities.App;
using HMS.Services.Contracts.App;
using HMS.ViewModels.App;

namespace HMS.Services.App
{
    public class EfStructureService : IStructureService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Structure> _structures;

        public EfStructureService(IUnitOfWork uow)
        {
            _uow = uow;
            _uow.CheckArgumentIsNull(nameof(_uow));
            _structures = _uow.Set<Structure>();
        }

        public void AddNewStructure(Structure structure)
        {
            _structures.Add(structure);
        }

        public IList<TreedListStructures> GetAllStructures(int? id)
        {
            return (from structures in _structures.AsNoTracking()
                    where (id.HasValue ? structures.ParentId == id : structures.ParentId == null)
                    select new TreedListStructures()
                    {
                        Id=structures.Id,
                        Title=structures.Title,
                        Code= structures.Code,
                        hasChildren = (from structure in _structures.AsNoTracking()
                                       where structure.ParentId == structures.Id
                                       select structure).Count() > 0
                    }).ToList();
        }

        public async Task<SelectList> SelectItemStructures()
        {
            return new SelectList(await _structures.AsNoTracking()
                .Select(a => new { a.Id, a.Title })
                .ToListAsync().ConfigureAwait(false), "Id", "Title");
        }

        public IReadOnlyList<SelectedListStructures> SelectListStructures()
        {
            return (from structure in _structures.AsNoTracking()
                    select new SelectedListStructures()
                    {
                        Id = structure.Id,
                        Title = structure.Title,
                    }).ToList();
        }

        public string StructureCode(int id)
        {
            return _structures.FirstOrDefault(x=>x.Id==id).Code;
        }
    }
}
