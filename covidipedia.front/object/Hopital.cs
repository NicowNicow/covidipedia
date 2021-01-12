using System.ComponentModel.DataAnnotations;

namespace covidipedia.front
{
    public class Hopital
    {
        [Key]
        public int id_hopital_hopital {get; set;}
        public string nom_hopital {get; set;}
        public int nombre_lits_hopital {get; set;}
        public int nombre_lits_reanimation_hopital {get; set;}
        public int id_localisation_localisation {get; set;}
    }
}