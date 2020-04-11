using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Domain
{
    public class UserEditDomainView
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }        
        public int? RoleId { get; set; }        
    }
}
