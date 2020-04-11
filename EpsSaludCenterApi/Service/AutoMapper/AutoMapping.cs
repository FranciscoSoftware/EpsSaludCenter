using AutoMapper;
using Data.Domain;
using Data.Models;
using Service.AutoMapper.MapperEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.AutoMapper
{
    public class AutoMapping: Profile
    {
        public AutoMapping() 
        {            
            CreateMap<Roles, RolesDTO>();
            CreateMap<UserDomainView, UserLoginDTO>();
            CreateMap<UserDomainView, UserListDTO>();
            CreateMap<UserListDTO,UserDomainView>();
            CreateMap<UserDomainView, UserEditDTO>();
            CreateMap<Specializations, SpecializationDTO>();
            CreateMap<PersonEditView,PersonEditDomainView>();
            CreateMap<PersonEditDomainView, PersonEditView>();
            CreateMap<UserEditDomainView, UserEditView>();
            CreateMap<UserEditView,UserEditDomainView>();
        }
    }
}
