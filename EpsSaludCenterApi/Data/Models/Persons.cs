using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Persons
    {
        public Persons()
        {
            Appointments = new HashSet<Appointments>();
            DiseasesList = new HashSet<DiseasesList>();
            Doctors = new HashSet<Doctors>();
            Users = new HashSet<Users>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string HomeAddress { get; set; }
        public string Phone { get; set; }
        public string ImageUrl { get; set; }

        public virtual ICollection<Appointments> Appointments { get; set; }
        public virtual ICollection<DiseasesList> DiseasesList { get; set; }
        public virtual ICollection<Doctors> Doctors { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }
}
