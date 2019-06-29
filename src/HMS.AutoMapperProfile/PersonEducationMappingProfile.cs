using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using HMS.Entities.App;
using HMS.ViewModels.App;

namespace HMS.AutoMapper
{
    public class PersonEducationMappingProfile : Profile
    {
        public PersonEducationMappingProfile()
        {
            CreateMap<PersonEducation, PersonEducationViewModel>(MemberList.None)
                .ForMember(dm => dm.CertificateTypeName, m => m.MapFrom(me => me.CertificateType.Title))
                .ForMember(dm => dm.DepartmentName, m => m.MapFrom(me => me.Department.Title))
                .ForMember(dm => dm.FieldStudyName, m => m.MapFrom(me => me.FieldStudy.Title));
            CreateMap<PersonEducationViewModel, PersonEducation>(MemberList.None);

        }
    }
}
