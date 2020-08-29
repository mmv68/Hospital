using AutoMapper;
using HMS.DataLayer.Context;
using HMS.Entities.App;
using HMS.Services.Contracts.App;
using HMS.ViewModels.App;

using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Services.App
{
    public class EFPersonMarriageService : IPersonMarriageService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<PersonMarriage> _personMarriages;
        private readonly IMapper _mapper;

        public EFPersonMarriageService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow ?? throw new ArgumentNullException(nameof(uow));
            _personMarriages = _uow.Set<PersonMarriage>();
            _mapper = mapper;
        }
        public async Task AddNewPersonMarriage(PersonMarriageViewModel personMarriage)
        {
            await _personMarriages.AddAsync(_mapper.Map<PersonMarriage>(personMarriage));
            await _uow.SaveChangesAsync().ConfigureAwait(false);
        }

        public void DeletePersonMarriage(int id)
        {
            _personMarriages.Remove(_personMarriages.Find(id));
            _uow.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<PersonMarriageViewModel> FindPersonMarriageById(int id)
        {
            return _mapper.Map<PersonMarriageViewModel>(await _personMarriages.FindAsync(id).ConfigureAwait(false));

        }

        public async Task<DataSourceResult> GetPersonMarriages(DataSourceRequest request, int personId)
        {
            return _mapper.Map<List<PersonMarriageViewModel>>
                (await _personMarriages.Where(p=>p.PersonId==personId)
                .ToListAsync().ConfigureAwait(false)                
                ).ToDataSourceResult(request);
        }

        public void UpdatePersonMarriage(PersonMarriageViewModel personMarriage)
        {
            _personMarriages.Update(_mapper.Map<PersonMarriage>(personMarriage));
            _uow.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
