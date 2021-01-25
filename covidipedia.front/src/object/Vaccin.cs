using System;
using System.Collections.Generic;

#nullable disable

namespace covidipedia.front
{
    public partial class Vaccin
    {
        public Vaccin()
        {
            Personnes = new HashSet<Personne>();
        }

        public int IdVaccinVaccin { get; set; }
        public string NomVaccinVaccin { get; set; }
        public string TypeVaccinVaccin { get; set; }
        public string FabricantVaccin { get; set; }

        public virtual ICollection<Personne> Personnes { get; set; }
    }
}
