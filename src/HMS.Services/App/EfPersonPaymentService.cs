using AutoMapper;
using HMS.DataLayer.Context;
using HMS.Entities.App;
using HMS.Services.Contracts.App;
using HMS.ViewModels.App;
using Microsoft.EntityFrameworkCore;
using System;
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
            throw new NotImplementedException();
        }

        public void UpdatePersonPayment(PersonPaymentViewModel personPayment)
        {
            throw new NotImplementedException();
        }
    }
}
