using System;
using System.Collections.Generic;
using System.Text;

namespace Service.AutoMapper.MapperEntity
{
    public class UserEditDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }

        public int idPerson { get; set; }
        public int? RoleId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string HomeAddress { get; set; }
        public string Phone { get; set; }
        public string ImageUrl { get; set; }
    }
}
