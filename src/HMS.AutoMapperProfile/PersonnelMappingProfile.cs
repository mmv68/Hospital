using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using HMS.Entities.App;
using HMS.ViewModels.App;

namespace HMS.AutoMapper
{
    public class PersonnelMappingProfile : Profile
    {
        public PersonnelMappingProfile()
        {
            CreateMap<Personnel, PersonnelViewModel>(MemberList.None)
                .ForMember(dm => dm.ConditionName, m => m.MapFrom(me => me.Condition.Title))
                .ForMember(dm => dm.StructureName, m => m.MapFrom(me => me.Structure.Title))
                .ForMember(dm => dm.MembershipTypeName, m => m.MapFrom(me => me.MembershipType.Title));
            CreateMap<PersonnelViewModel, Personnel>(MemberList.None);
        }
    }
}
