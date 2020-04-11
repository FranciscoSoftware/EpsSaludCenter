using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Diseases
    {
        public Diseases()
        {
            DiseasesList = new HashSet<DiseasesList>();
        }

        public int Id { get; set; }
        public string DiseasesName { get; set; }

        public virtual ICollection<DiseasesList> DiseasesList { get; set; }
    }
}
