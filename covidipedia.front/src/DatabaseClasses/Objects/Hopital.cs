using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace covidipedia.front
{
    [Index(nameof(NomHopital))]
    public partial class Hopital
    {
        public Hopital()
        {
            Cas = new HashSet<Ca>();
        }

        public int IdHopitalHopital { get; set; }
        public string NomHopital { get; set; }
        public short? NombreLitsHopital { get; set; }
        public short? NombreLitsReanimationHopital { get; set; }
        public int IdLocalisationLocalisation { get; set; }

        public virtual Localisation IdLocalisationLocalisationNavigation { get; set; }
        public virtual ICollection<Ca> Cas { get; set; }
    }
}
