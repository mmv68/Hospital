using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HMS.DataLayer.Context;
using HMS.Entities.App;
using HMS.Services.Contracts.App;
using HMS.ViewModels.App;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HMS.Services.App
{
    public class EfPersonEducationService : IPersonEducationService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<PersonEducation> _personEducations;
        private readonly IMapper _mapper;

        public EfPersonEducationService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow ?? throw new ArgumentNullException(nameof(uow));
            _personEducations = _uow.Set<PersonEducation>();
            _mapper = mapper;
        }

        public async Task AddNewPersonEducation(PersonEducationViewModel personEducation)
        {
            await _personEducations.AddAsync(_mapper.Map<PersonEducation>(personEducation)).ConfigureAwait(false);
            await _uow.SaveChangesAsync().ConfigureAwait(false);

        }

        public void UpdatePersonEducation(PersonEducationViewModel personEducation)
        {
            _personEducations.Update(_mapper.Map<PersonEducation>(personEducation));
            _uow.SaveChangesAsync().ConfigureAwait(false);
        }

        public void DeletePersonEducation(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<PersonEducationViewModel> FindPersonEducationById(int id)
        {
          return _mapper.Map <PersonEducationViewModel>(await _personEducations.FindAsync(id).ConfigureAwait(false));
        }

        public async Task<PersonEducationViewModel> FindFullPersonEducationById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<PersonEducationViewModel>> GetAllPersonEducations()
        {
            throw new NotImplementedException();
        }

        public async Task<DataSourceResult> GetPersonEducations(DataSourceRequest request,int personId)
        {
            return _mapper.Map<List<PersonEducationViewModel>>
            (await _personEducations.Where(p => p.PersonId == personId)
                .Include(p => p.CertificateType)
                .Include(p => p.Department)
                .Include(p => p.FieldStudy)
                .ToListAsync().ConfigureAwait(false)
            ).ToDataSourceResult(request);
        }
    }
}
