using HMS.ViewModels.App;
using System.Threading.Tasks;

namespace HMS.Services.Contracts.App
{
    public interface IPersonPaymentService
    {
        Task AddNewPersonPayment(PersonPaymentViewModel personPayment);
        void UpdatePersonPayment(PersonPaymentViewModel personPayment);
        void DeletePersonPayment(int id);
        //Task<PersonPaymentViewModel> FindPersonPaymentById(int id);
        //Task<PersonPaymentViewModel> FindFullPersonPaymentById(int id);
        //Task<IList<PersonPaymentViewModel>> GetAllPersonPayments();
        //Task<DataSourceResult> GetPersonPayments(DataSourceRequest request, int personId);
    }
}
