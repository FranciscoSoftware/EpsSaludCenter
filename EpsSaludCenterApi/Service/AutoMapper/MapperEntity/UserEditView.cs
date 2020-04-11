using System;
using System.Collections.Generic;
using System.Text;

namespace Service.AutoMapper.MapperEntity
{
    public class UserEditView
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public int? RoleId { get; set; }

    }
}
