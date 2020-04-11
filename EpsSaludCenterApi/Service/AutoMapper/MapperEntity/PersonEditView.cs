using System;
using System.Collections.Generic;
using System.Text;

namespace Service.AutoMapper.MapperEntity
{
    public class PersonEditView
    {
        public int Id { get; set; }        
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string HomeAddress { get; set; }
        public string Phone { get; set; }
        public string ImageUrl { get; set; }
    }
}
