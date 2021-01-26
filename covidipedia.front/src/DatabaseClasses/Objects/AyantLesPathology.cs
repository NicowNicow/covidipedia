using System;
using System.Collections.Generic;

#nullable disable

namespace covidipedia.front
{
    public partial class AyantLesPathology
    {
        public int IdPathologiePathologie { get; set; }
        public int IdCasCas { get; set; }

        public virtual Ca IdCasCasNavigation { get; set; }
        public virtual Pathologie IdPathologiePathologieNavigation { get; set; }
    }
}
