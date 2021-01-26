using System;
using System.Collections.Generic;

#nullable disable

namespace covidipedia.front
{
    public partial class EffetSecondaire
    {
        public EffetSecondaire()
        {
            RessentEffetSecondaires = new HashSet<RessentEffetSecondaire>();
        }

        public int IdEffetEffetSecondaire { get; set; }
        public string NomEffetEffetSecondaire { get; set; }
        public string TypeEffetEffetSecondaire { get; set; }

        public virtual ICollection<RessentEffetSecondaire> RessentEffetSecondaires { get; set; }
    }
}
