using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Specializations
    {
        public Specializations()
        {
            Doctors = new HashSet<Doctors>();
        }

        public int Id { get; set; }
        public string SpecializationName { get; set; }

        public virtual ICollection<Doctors> Doctors { get; set; }
    }
}
