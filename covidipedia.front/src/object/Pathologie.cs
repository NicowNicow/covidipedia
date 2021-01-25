using System;
using System.Collections.Generic;

#nullable disable

namespace covidipedia.front
{
    public partial class Pathologie
    {
        public Pathologie()
        {
            AyantLesPathologies = new HashSet<AyantLesPathology>();
        }

        public int IdPathologiePathologie { get; set; }
        public string NomPathologiePathologie { get; set; }
        public string TypePathologiePathologie { get; set; }

        public virtual ICollection<AyantLesPathology> AyantLesPathologies { get; set; }
    }
}
