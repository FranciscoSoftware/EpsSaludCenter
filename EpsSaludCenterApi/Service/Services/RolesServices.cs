using AutoMapper;
using Data.Models;
using Data.Respository;
using Service.AutoMapper.MapperEntity;
using Service.Interfaces;
using System;
using System.Collections.Generic;

namespace Service
{
    public class RolesServices : IRolesServices
    {
        private readonly IMapper _mapper;
        IRepository<Roles> _repository = null;
        public RolesServices(IRepository<Roles> repository, IMapper mapper)
        {
            this._repository = repository;
            _mapper = mapper;
        }

        public List<RolesDTO> getRoles()
        {
            List<RolesDTO> roles = _mapper.Map<IEnumerable<Roles>, List<RolesDTO>>(this._repository.GetAll());
            return roles;
        }

    }
}
