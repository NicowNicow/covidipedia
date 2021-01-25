using System;
using System.Collections.Generic;

#nullable disable

namespace covidipedia.front
{
    public partial class RecoitLeTraitement
    {
        public int IdTraitementTraitement { get; set; }
        public int IdCasCas { get; set; }

        public virtual Ca IdCasCasNavigation { get; set; }
        public virtual Traitement IdTraitementTraitementNavigation { get; set; }
    }
}
