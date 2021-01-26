using System;
using System.Collections.Generic;

#nullable disable

namespace covidipedia.front
{
    public partial class RessentEffetSecondaire
    {
        public int IdEffetEffetSecondaire { get; set; }
        public int IdPersonnePersonne { get; set; }

        public virtual EffetSecondaire IdEffetEffetSecondaireNavigation { get; set; }
        public virtual Personne IdPersonnePersonneNavigation { get; set; }
    }
}
