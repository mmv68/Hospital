using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HMS.Entities.App;
using HMS.ViewModels.App;

namespace HMS.Services.Contracts.App
{
    public interface IPersonService
    {
         Task AddNewPerson(InsertPersonViewModel Person);
         void UpdatePerson(EditPersonViewModel Person);
         void DeletePerson(int id);
         Task<EditPersonViewModel> FindPersonByID(int id);
         Task<InsertPersonViewModel> FindFullPersonByID(int id);
         Task<IList<InsertPersonViewModel>> GetAllPersons();
         /// <summary>
         /// get all Persons For Grid By Pagination
         /// </summary>
         /// <param name="pageNumber"> is count of records by per take</param>
         /// <param name="recordsPerPage"> is count of record on page </param>
         /// <returns>count of recore for each page requst</returns>
         IReadOnlyList<Person> GetPagedPersonAsNoTracking(int pageNumber,int recordsPerPage);
         JsonResult GetPersonsAsNoTracking(string searchTerm, int pageSize, int pageNum);
        /// <summary>
        /// چک کردن موجود بودن کدملی فرد
        /// </summary>
        /// <param name="nationalCode">کدملی</param>
        /// /// <param name="id">آی دی <c>میتواند نال باشد</c></param>
        /// <returns></returns>
        Task<bool> IsPersonNationalCodeExist(string nationalCode,int? id);
        Task<bool> IsPersonExist(int id);
    }
}