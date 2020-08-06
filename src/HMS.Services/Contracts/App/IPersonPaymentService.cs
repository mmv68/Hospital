using HMS.ViewModels.App;
using Kendo.Mvc.UI;
using System.Threading.Tasks;

namespace HMS.Services.Contracts.App
{
    public interface IPersonPaymentService
    {
        Task AddNewPersonPayment(PersonPaymentViewModel personPayment);
        void UpdatePersonPayment(PersonPaymentViewModel personPayment);
        void DeletePersonPayment(int id);
        Task<DataSourceResult> FindPersonPaymentsById(DataSourceRequest request,int id);
        Task<PersonPaymentViewModel> FindPeymentByID(int id);
        //Task<IList<PersonPaymentViewModel>> GetAllPersonPayments();
        //Task<DataSourceResult> GetPersonPayments(DataSourceRequest request, int personId);
    }
}
