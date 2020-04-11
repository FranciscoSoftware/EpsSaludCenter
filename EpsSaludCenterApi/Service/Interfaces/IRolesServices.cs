using Data.Models;
using Service.AutoMapper.MapperEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interfaces
{
    public interface IRolesServices
    {
        List<RolesDTO> getRoles();
    }
}
