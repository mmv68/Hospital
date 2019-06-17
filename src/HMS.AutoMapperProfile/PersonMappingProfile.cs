using AutoMapper;
using HMS.Entities.App;
using HMS.ViewModels.App;

namespace HMS.AutoMapper
{
    public class PersonMappingProfile : Profile
    {
        public PersonMappingProfile()
        {
            CreateMap<Person, InsertPersonViewModel>(MemberList.None)
                .ForMember(a => a.BrithPlaceProvianceName, m => m.MapFrom(s => s.BrithPlaceProviance.Title))
                .ForMember(a => a.BrithPlaceCityName, m => m.MapFrom(s => s.BrithPlaceCity.Title));
            CreateMap<InsertPersonViewModel, Person>(MemberList.None);
            CreateMap<Person, EditPersonViewModel>(MemberList.None)
                .ForMember(a => a.BrithPlaceProvianceName, m => m.MapFrom(s => s.BrithPlaceProviance.Title))
                .ForMember(a => a.BrithPlaceCityName, m => m.MapFrom(s => s.BrithPlaceCity.Title));
            CreateMap<EditPersonViewModel, Person>(MemberList.None);
        }
    }
}
