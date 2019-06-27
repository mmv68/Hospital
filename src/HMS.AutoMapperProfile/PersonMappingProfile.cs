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
                .ForMember(a => a.BrithPlaceTownshipName, m => m.MapFrom(s => s.BrithPlaceTownship.Title))
                .ForMember(a => a.BrithPlaceSectionName, m => m.MapFrom(s => s.BrithPlaceSection.Title))
                .ForMember(a => a.BrithPlaceCityName, m => m.MapFrom(s => s.BrithPlaceCity.Title))
                .ForMember(a => a.RelationId, m => m.MapFrom(s => s.Relation.Title));
            CreateMap<InsertPersonViewModel, Person>(MemberList.None);
            CreateMap<Person, EditPersonViewModel>(MemberList.None)
                .ForMember(a => a.BrithPlaceProvianceName, m => m.MapFrom(s => s.BrithPlaceProviance.Title))
                .ForMember(a => a.BrithPlaceTownshipName, m => m.MapFrom(s => s.BrithPlaceTownship.Title))
                .ForMember(a => a.BrithPlaceSectionName, m => m.MapFrom(s => s.BrithPlaceSection.Title))
                .ForMember(a => a.BrithPlaceCityName, m => m.MapFrom(s => s.BrithPlaceCity.Title))
                .ForMember(a => a.RelationId, m => m.MapFrom(s => s.Relation.Title));
            CreateMap<EditPersonViewModel, Person>(MemberList.None);
        }
    }
}
