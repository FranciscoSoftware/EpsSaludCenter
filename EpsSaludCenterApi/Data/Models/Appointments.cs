using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Appointments
    {
        public Appointments()
        {
            DiseasesList = new HashSet<DiseasesList>();
        }

        public int Id { get; set; }
        public int? PersonId { get; set; }
        public int? DoctorId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double Weigth { get; set; }
        public double Heigth { get; set; }
        public string PatientDescription { get; set; }
        public string Observations { get; set; }

        public virtual Doctors Doctor { get; set; }
        public virtual Persons Person { get; set; }
        public virtual ICollection<DiseasesList> DiseasesList { get; set; }
    }
}
