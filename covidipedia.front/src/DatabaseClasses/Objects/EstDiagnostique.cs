using System;
using System.Collections.Generic;

#nullable disable

namespace covidipedia.front
{
    public partial class EstDiagnostique
    {
        public int IdSymptomeSymptome { get; set; }
        public int IdCasCas { get; set; }

        public virtual Ca IdCasCasNavigation { get; set; }
        public virtual Symptome IdSymptomeSymptomeNavigation { get; set; }
    }
}
