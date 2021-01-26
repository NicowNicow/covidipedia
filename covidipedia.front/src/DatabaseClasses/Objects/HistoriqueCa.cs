using System;
using System.Collections.Generic;

#nullable disable

namespace covidipedia.front
{
    public partial class HistoriqueCa
    {
        public int IdHistoriqueHistoriqueCas { get; set; }
        public DateTime? DateDetectionHistoriqueCas { get; set; }
        public DateTime? DateMajHistoriqueCas { get; set; }
        public string EtatCasHistoriqueCas { get; set; }
        public string SoucheVirusHistoriqueCas { get; set; }
        public int IdCasCas { get; set; }

        public virtual Ca IdCasCasNavigation { get; set; }
    }
}
