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
    public class EfBaseInformationService : IBaseInformationService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<BaseInformation> _baseInformation;

        public EfBaseInformationService(IUnitOfWork uow)
        {
            _uow = uow;
            _uow.CheckArgumentIsNull(nameof(_uow));
            _baseInformation = _uow.Set<BaseInformation>();
        }

        public void AddNewBaseInformation(BaseInformation baseInformation)
        {
            _baseInformation.Add(baseInformation);
        }

        public IReadOnlyList<BaseInformation> GetBaseInformations()
        {
            return _baseInformation.AsNoTracking().ToList();
        }

        public async Task<SelectList> SelectItemBaseInformations(int baseInformationHeaderId)
        {
            return new SelectList(await _baseInformation.AsNoTracking()
                .Select(a => new { a.Value, a.Title })
                .ToListAsync().ConfigureAwait(false), "Value", "Title");
        }

        public async Task<SelectList> SelectItemBaseInformations(int baseInformationHeaderId, int parentId)
        {
            return new SelectList(await _baseInformation.AsNoTracking()
                .Where(x => x.ParentId == parentId)
                .Select(a => new { a.Value, a.Title })
                .ToListAsync().ConfigureAwait(false), "Value", "Title");
        }

        public IReadOnlyList<SelectedListBaseInformation> SelectListBaseInformations(int baseInformationHeaderId)
        {
            return (from baseInformatio in _baseInformation.AsNoTracking()
                    select new SelectedListBaseInformation()
                    {
                        Id = baseInformatio.Id,
                        Title = baseInformatio.Title
                    }).ToList();
        }

        public IReadOnlyList<SelectedListBaseInformation> SelectListBaseInformations(int baseInformationHeaderId, int parentId)
        {
            return (from baseInformatio in _baseInformation.AsNoTracking()
                    where baseInformatio.ParentId == parentId
                    select new SelectedListBaseInformation()
                    {
                        Id = baseInformatio.Id,
                        Title = baseInformatio.Title
                    }).ToList();
        }
    }
}

