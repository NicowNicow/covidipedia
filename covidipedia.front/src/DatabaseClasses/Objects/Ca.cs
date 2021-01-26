using System;
using System.Collections.Generic;

#nullable disable

namespace covidipedia.front
{
    public partial class Ca
    {
        public Ca()
        {
            AyantLesPathologies = new HashSet<AyantLesPathology>();
            EstDiagnostiques = new HashSet<EstDiagnostique>();
            HistoriqueCas = new HashSet<HistoriqueCa>();
            RecoitLeTraitements = new HashSet<RecoitLeTraitement>();
        }

        public int IdCasCas { get; set; }
        public string EtatActuelCas { get; set; }
        public int HopitalIdHopitalHopital { get; set; }
        public int PersonneIdPersonnePersonne { get; set; }

        public virtual Hopital HopitalIdHopitalHopitalNavigation { get; set; }
        public virtual Personne PersonneIdPersonnePersonneNavigation { get; set; }
        public virtual ICollection<AyantLesPathology> AyantLesPathologies { get; set; }
        public virtual ICollection<EstDiagnostique> EstDiagnostiques { get; set; }
        public virtual ICollection<HistoriqueCa> HistoriqueCas { get; set; }
        public virtual ICollection<RecoitLeTraitement> RecoitLeTraitements { get; set; }
    }
}
