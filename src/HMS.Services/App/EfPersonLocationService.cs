using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HMS.DataLayer.Context;
using HMS.Entities.App;
using HMS.Services.Contracts.App;
using HMS.ViewModels.App;
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
            throw new NotImplementedException();
        }

        public Task<PersonLocationViewModel> FindFullPersonLocationById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PersonLocationViewModel> FindPersonLocationById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<PersonLocationViewModel>> GetAllPersonLocations()
        {
            throw new NotImplementedException();
        }

        public Task<DataSourceResult> GetPersonLocations(DataSourceRequest request, int personId)
        {
            throw new NotImplementedException();
        }

        public void UpdatePersonLocation(PersonLocationViewModel personLocation)
        {
            throw new NotImplementedException();
        }
    }
}
