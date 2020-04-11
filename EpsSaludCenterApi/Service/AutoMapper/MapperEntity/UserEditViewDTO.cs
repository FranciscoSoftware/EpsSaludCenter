using System;
using System.Collections.Generic;
using System.Text;

namespace Service.AutoMapper.MapperEntity
{
    public class UserEditViewDTO
    {
        public PersonEditView person { get; set; }
        public UserEditView user { get; set; }
        public int Id { get; set; }
    }
}
