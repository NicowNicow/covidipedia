using System;
using System.Collections.Generic;

#nullable disable

namespace covidipedia.front
{
    public partial class Traitement
    {
        public Traitement()
        {
            RecoitLeTraitements = new HashSet<RecoitLeTraitement>();
        }

        public int IdTraitementTraitement { get; set; }
        public string NomTraitementTraitement { get; set; }
        public string TypeTraitementTraitement { get; set; }

        public virtual ICollection<RecoitLeTraitement> RecoitLeTraitements { get; set; }
    }
}
