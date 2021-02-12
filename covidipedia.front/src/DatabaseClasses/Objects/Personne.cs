using System;
using System.Collections.Generic;

#nullable disable

namespace covidipedia.front
{
    public partial class Personne
    {
        public Personne()
        {
            Cas = new HashSet<Ca>();
            RessentEffetSecondaires = new HashSet<RessentEffetSecondaire>();
        }

        public int IdPersonnePersonne { get; set; }
        public short? AgePersonne { get; set; }
        public bool? SexePersonne { get; set; }
        public string IdentifiantPersonne { get; set; }
        public DateTime? DateVaccin1Personne { get; set; }
        public DateTime? DateVaccin2Personne { get; set; }
        public string EthniePersonne { get; set; }
        public int IdLocalisationLocalisation { get; set; }
        public int? VaccinIdVaccinVaccin { get; set; }

        public virtual Localisation IdLocalisationLocalisationNavigation { get; set; }
        public virtual Vaccin VaccinIdVaccinVaccinNavigation { get; set; }
        public virtual ICollection<Ca> Cas { get; set; }
        public virtual ICollection<RessentEffetSecondaire> RessentEffetSecondaires { get; set; }
    }
}
