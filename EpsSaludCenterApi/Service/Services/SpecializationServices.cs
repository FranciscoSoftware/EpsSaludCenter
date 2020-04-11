using AutoMapper;
using Data.Models;
using Data.Respository;
using Service.AutoMapper.MapperEntity;
using Service.Interfaces;
using System;
using System.Collections.Generic;

namespace Service
{
    public class SpecializationServices : ISpecializationServices
    {
        private readonly IMapper _mapper;
        IRepository<Specializations> _repository = null;
        public SpecializationServices(IRepository<Specializations> repository, IMapper mapper)
        {
            this._repository = repository;
            _mapper = mapper;
        }

        public List<SpecializationDTO> getSpecialization()
        {
            List<SpecializationDTO> roles = _mapper.Map<IEnumerable<Specializations>, List<SpecializationDTO>>(this._repository.GetAll());
            return roles;
        }

    }
}
