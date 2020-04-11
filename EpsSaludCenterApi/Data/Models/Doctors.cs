using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Doctors
    {
        public Doctors()
        {
            Appointments = new HashSet<Appointments>();
        }

        public int Id { get; set; }
        public int? PersonId { get; set; }
        public int? SpecializationId { get; set; }

        public virtual Persons Person { get; set; }
        public virtual Specializations Specialization { get; set; }
        public virtual ICollection<Appointments> Appointments { get; set; }
    }
}
