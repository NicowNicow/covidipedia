using System;
using System.Collections.Generic;

#nullable disable

namespace covidipedia.front
{
    public partial class Localisation
    {
        public Localisation()
        {
            Hopitals = new HashSet<Hopital>();
            Personnes = new HashSet<Personne>();
        }

        public int IdLocalisationLocalisation { get; set; }
        public string RegionLocalisation { get; set; }
        public short? DepartementLocalisation { get; set; }
        public string VilleLocalisation { get; set; }

        public virtual ICollection<Hopital> Hopitals { get; set; }
        public virtual ICollection<Personne> Personnes { get; set; }
    }
}
