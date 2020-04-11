using System;
using System.Collections.Generic;
using System.Text;

namespace Service.AutoMapper.MapperEntity
{
    public class UserListDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }                
        public int? RoleId { get; set; }
        public string RoleName { get; set; }
        public bool IsActive { get; set; }
    }
}
