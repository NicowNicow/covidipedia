using System;
using System.Collections.Generic;

#nullable disable

namespace covidipedia.front
{
    public partial class Symptome
    {
        public Symptome()
        {
            EstDiagnostiques = new HashSet<EstDiagnostique>();
        }

        public int IdSymptomeSymptome { get; set; }
        public string NomSymptomeSymptome { get; set; }
        public string TypeSymptomeSymptome { get; set; }

        public virtual ICollection<EstDiagnostique> EstDiagnostiques { get; set; }
    }
}
