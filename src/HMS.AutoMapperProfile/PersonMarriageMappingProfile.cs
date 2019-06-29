using AutoMapper;
using HMS.Entities.App;
using HMS.ViewModels.App;

namespace HMS.AutoMapper
{
    public class PersonMarriageMappingProfile:Profile
    {
        public PersonMarriageMappingProfile()
        {
            CreateMap<PersonMarriage, PersonMarriageViewModel>(MemberList.None);
            CreateMap<PersonMarriageViewModel, PersonMarriage>(MemberList.None);
        }
    }
}
