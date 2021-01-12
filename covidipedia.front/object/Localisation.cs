using System.ComponentModel.DataAnnotations;

namespace covidipedia.front
{
    public class Localisation
    {
        [Key]
        public int id_localisation_localisation {get; set;}
        public string region_localisation {get; set;}
        public string ville_localisation {get; set;}
        public int departement_localisation {get; set;}
    }
}