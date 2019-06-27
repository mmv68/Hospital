using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HMS.Common.GuardToolkit;
using HMS.DataLayer.Context;
using HMS.Entities.App;
using HMS.Services.Contracts.App;
using HMS.ViewModels.App;

namespace HMS.Services.App
{
    public class EfPersonService : IPersonService
    {
        // ReSharper disable once PrivateFieldCanBeConvertedToLocalVariable
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Person> _persons;
        private readonly IMapper _mapper;

        public EfPersonService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow??throw new ArgumentNullException(nameof(uow));
            _uow.CheckArgumentIsNull(nameof(_uow));
            _persons = _uow.Set<Person>();
            _mapper = mapper;
        }

        public async Task AddNewPerson(InsertPersonViewModel person)
        {
            await _persons.AddAsync(_mapper.Map<Person>(person)).ConfigureAwait(false);
        }
        public void UpdatePerson(EditPersonViewModel person)
        {
            _persons.Update(_mapper.Map<Person>(person));
        }

        public void DeletePerson(int id)
        {
            _persons.Remove(_persons.FindAsync(id).Result);
        }
        public async Task<EditPersonViewModel> FindPersonByID(int id)
        {
            return _mapper.Map<EditPersonViewModel>(await _persons.FindAsync(id).ConfigureAwait(false));
        }
        public async Task<InsertPersonViewModel> FindFullPersonByID(int id)
        {
            return _mapper.Map<InsertPersonViewModel>
                (await _persons.Include(p => p.BrithPlaceProviance)
                               .Include(p => p.BrithPlaceCity)
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(false));
        }

        public async Task<IList<InsertPersonViewModel>> GetAllPersons()
        {
            return _mapper.Map<List<InsertPersonViewModel>>
                            (await _persons.Include(p => p.BrithPlaceProviance)
                                        .Include(p => p.BrithPlaceCity)
                                        .ToListAsync().ConfigureAwait(false));
        }

        IReadOnlyList<Person> IPersonService.GetPagedPersonAsNoTracking(int pageNumber, int recordsPerPage)
        {
            var skipRecords = pageNumber * recordsPerPage;
            return _persons.AsNoTracking()
                            .Skip(skipRecords)
                            .Take(recordsPerPage)
                            .ToList();
        }
        public Task<bool> IsPersonNationalCodeExist(string nationalCode, int? id)
        {
            //nationalCode = nationalCode.GetEnglishNumber();
            return id == null
                ? (_persons.AnyAsync(a => a.NationalCode == nationalCode))
                : (_persons.AnyAsync(a => a.Id != id.Value && a.NationalCode == nationalCode));
        }

        public Task<bool> IsPersonExist(int id)
        {
            return _persons.AnyAsync(a => a.Id == id);
        }

        public JsonResult GetPersonsAsNoTracking(string searchTerm, int pageSize, int pageNum)
        {
            var personList = (from person in _persons.AsNoTracking()
                              where (person.FirstName.Replace(" ", string.Empty)
                              + person.LastName.Replace(" ", string.Empty)
                              + person.NationalCode.Trim()).Contains(searchTerm.Replace(" ", string.Empty))
                              select new
                              {
                                  person.Id,
                                  FullName = $"{person.FirstName} {person.LastName} ›—“‰œ {person.FatherName}({person.NationalCode})"
                              }
                            ).ToList();
            var result = new
            {
                Total = personList.Count,
                Results = personList.Skip((pageNum * pageSize) - 10).Take(pageSize)
            };
            return new JsonResult(result);
        }
    }
}