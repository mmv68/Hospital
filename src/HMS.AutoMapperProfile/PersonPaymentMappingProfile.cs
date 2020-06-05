using AutoMapper;
using HMS.Entities.App;
using HMS.ViewModels.App;

namespace HMS.AutoMapper
{
    public class PersonPaymentMappingProfile:Profile
    {
        public PersonPaymentMappingProfile()
        {
            CreateMap<PersonPayment, PersonPaymentViewModel>(MemberList.None);
            CreateMap<PersonPaymentViewModel, PersonPayment>(MemberList.None);
        }
    }
}
