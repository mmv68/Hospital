using AutoMapper;
using HMS.Entities.App;
using HMS.ViewModels.App;

namespace HMS.AutoMapper
{
    public class PersonLocationMappingProfile : Profile
    {
        public PersonLocationMappingProfile()
        {
            CreateMap<PersonLocation, PersonLocationViewModel>(MemberList.None)
                .ForMember(dm => dm.ProvianceName, m => m.MapFrom(me => me.Proviance.Title))
                .ForMember(dm => dm.TownshipName, m => m.MapFrom(me => me.Township.Title))
                .ForMember(dm => dm.SectionName, m => m.MapFrom(me => me.Section.Title))
                .ForMember(dm => dm.CityName, m => m.MapFrom(me => me.City.Title));
            CreateMap<PersonLocationViewModel, PersonLocation>(MemberList.None);
        }
    }
}
