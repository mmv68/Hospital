using HMS.ViewModels.App;
using Kendo.Mvc.UI;
using System.Threading.Tasks;

namespace HMS.Services.Contracts.App
{
    public interface IPersonMarriageService
    {
        Task AddNewPersonMarriage(PersonMarriageViewModel personMarriage);
        void UpdatePersonMarriage(PersonMarriageViewModel personMarriage);
        void DeletePersonMarriage(int id);
        Task<PersonMarriageViewModel> FindPersonMarriageById(int id);
        Task<DataSourceResult> GetPersonMarriages(DataSourceRequest request, int personId);
    }
}
