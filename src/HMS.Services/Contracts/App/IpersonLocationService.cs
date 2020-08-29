using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HMS.ViewModels.App;
using Kendo.Mvc.UI;

namespace HMS.Services.Contracts.App
{
    public interface IPersonLocationService
    {
        Task AddNewPersonLocation(PersonLocationViewModel personLocation);
        void UpdatePersonLocation(PersonLocationViewModel personLocation);
        void DeletePersonLocation(int id);
        Task<PersonLocationViewModel> FindPersonLocationById(int id);
        Task<DataSourceResult> GetPersonLocations(DataSourceRequest request, int personId);
    }
}
