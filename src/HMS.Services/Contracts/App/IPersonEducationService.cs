using System.Collections.Generic;
using System.Threading.Tasks;
using HMS.ViewModels.App;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;

namespace HMS.Services.Contracts.App
{
    public  interface IPersonEducationService
    {
        Task AddNewPersonEducation(PersonEducationViewModel personEducation);
        void UpdatePersonEducation(PersonEducationViewModel personEducation);
        void DeletePersonEducation(int id);
        Task<PersonEducationViewModel> FindPersonEducationById(int id);
        Task<PersonEducationViewModel> FindFullPersonEducationById(int id);
        Task<IList<PersonEducationViewModel>> GetAllPersonEducations();
        Task<DataSourceResult> GetPersonEducations(DataSourceRequest request,int personId);
    }
}
