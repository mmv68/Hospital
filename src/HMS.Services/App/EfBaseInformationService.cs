using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HMS.Common.GuardToolkit;
using HMS.DataLayer.Context;
using HMS.Entities.App;
using HMS.Services.Contracts.App;
using HMS.ViewModels.App;
using Kendo.Mvc.Extensions;
using Microsoft.AspNetCore.Mvc;

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

        public async Task AddNewBaseInformation(BaseInformation baseInformation)
        {
           await _baseInformation.AddAsync(baseInformation);
           await _uow.SaveChangesAsync();
        }

        public JsonResult GetBaseInformations(int? id)
        {
            var bf = from e in _baseInformation
                where (id.HasValue ? e.ParentId == id : e.ParentId == null)
                select new
                {
                    id = e.Id,
                    Name = $"{e.Value}-{e.Title}",
                    hasChildren = (from q in _baseInformation
                            where (q.ParentId == e.Id)
                            select q
                        ).Any()
                };


            return new JsonResult(bf.ToList());
        }

        public IReadOnlyList<SelectedListBaseInformation> SelectListBaseInformations(int baseInformationHeaderId)
        {
            return (from baseInformation in _baseInformation.AsNoTracking()
                    where baseInformation.ParentId==baseInformationHeaderId
                    select new SelectedListBaseInformation()
                    {
                        Id = baseInformation.Id,
                        Title = baseInformation.Title
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

        public  SelectedListBaseInformation FindLastBaseInformation(int id)
        {
            var lastBaseInformation = _baseInformation.LastOrDefault(x => x.ParentId ==id);
           var selectedListBaseInformation = new SelectedListBaseInformation
           {
               Title = lastBaseInformation.Type,
               Id = (int)lastBaseInformation.Value
           };
            return selectedListBaseInformation;
        }

    }
}

