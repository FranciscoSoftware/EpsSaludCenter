using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class DiseasesList
    {
        public int Id { get; set; }
        public int? DiseaseId { get; set; }
        public int? PersonId { get; set; }
        public int? AppointmentId { get; set; }
        public bool? Recovered { get; set; }

        public virtual Appointments Appointment { get; set; }
        public virtual Diseases Disease { get; set; }
        public virtual Persons Person { get; set; }
    }
}
