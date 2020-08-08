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
using System.Threading.Tasks;

namespace HMS.Services.App
{
    public class EfPersonPaymentService : IPersonPaymentService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<PersonPayment> _personPayment;
        private readonly IMapper _mapper;
        public EfPersonPaymentService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow ?? throw new ArgumentNullException(nameof(uow));
            _personPayment = _uow.Set<PersonPayment>();
            _mapper = mapper;
        }

        public async Task AddNewPersonPayment(PersonPaymentViewModel personPayment)
        {
            await _personPayment.AddAsync(_mapper.Map<PersonPayment>(personPayment)).ConfigureAwait(false);
            await _uow.SaveChangesAsync().ConfigureAwait(false);
        }

        public void DeletePersonPayment(int id)
        {
            _personPayment.Remove(_personPayment.FindAsync(id).Result);
            _uow.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<DataSourceResult> FindPersonPaymentsById(DataSourceRequest request,int id)
        {
            return _mapper.Map<List<PersonPaymentViewModel>>
            (await _personPayment.Where(p => p.PersonId == id)
                .ToListAsync().ConfigureAwait(false)
            ).ToDataSourceResult(request);
        }

        public async Task<PersonPaymentViewModel> FindPeymentByID(int id)
        {
            return _mapper.Map<PersonPaymentViewModel>(await _personPayment.FindAsync(id).ConfigureAwait(false));
        }

        public void UpdatePersonPayment(PersonPaymentViewModel personPayment)
        {
            _personPayment.Update(_mapper.Map<PersonPayment>(personPayment));
            _uow.SaveChangesAsync();
        }
    }
}
