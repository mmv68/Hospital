using System.Threading.Tasks;
using HMS.ViewModels.App;
using Kendo.Mvc.UI;

namespace HMS.Services.Contracts.App
{
    public  interface IPersonEducationService
    {
        Task AddNewPersonEducation(PersonEducationViewModel personEducation);
        void UpdatePersonEducation(PersonEducationViewModel personEducation);
        void DeletePersonEducation(int id);
        Task<PersonEducationViewModel> FindPersonEducationById(int id);
        Task<DataSourceResult> GetPersonEducations(DataSourceRequest request,int personId);
    }
}
