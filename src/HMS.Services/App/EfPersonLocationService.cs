using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HMS.DataLayer.Context;
using HMS.Entities.App;
using HMS.Services.Contracts.App;
using HMS.ViewModels.App;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.EntityFrameworkCore;

namespace HMS.Services.App
{
    public class EfPersonLocationService:IPersonLocationService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<PersonLocation> _personLocations;
        private readonly IMapper _mapper;

        public EfPersonLocationService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow ?? throw new ArgumentNullException(nameof(uow));
            _personLocations = _uow.Set<PersonLocation>();
            _mapper = mapper;
        }

        public async Task AddNewPersonLocation(PersonLocationViewModel personLocation)
        {
            await _personLocations.AddAsync(_mapper.Map<PersonLocation>(personLocation)).ConfigureAwait(false);
            await _uow.SaveChangesAsync().ConfigureAwait(false);
        }

        public void DeletePersonLocation(int id)
        {
            _personLocations.Remove(_personLocations.Find(id));
            _uow.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<PersonLocationViewModel> FindPersonLocationById(int id)
        {
            return _mapper.Map<PersonLocationViewModel>(await _personLocations.FindAsync(id).ConfigureAwait(false));
        }

        public async Task<DataSourceResult> GetPersonLocations(DataSourceRequest request, int personId)
        {
            return _mapper.Map<List<PersonLocationViewModel>>
                (await _personLocations.Where(p => p.PersonId == personId)
                .Include(p => p.Proviance)
                .Include(p => p.Township)
                .Include(p=>p.Section)
                .Include(p=>p.City)
                .ToListAsync().ConfigureAwait(false)
                ).ToDataSourceResult(request);
        }

        public void UpdatePersonLocation(PersonLocationViewModel personLocation)
        {
            _personLocations.Update(_mapper.Map<PersonLocation>(personLocation));
            _uow.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
