using System.ComponentModel.DataAnnotations;

namespace covidipedia.front
{
    public class Effets_secondaires
    {
        [Key]
        public int id_effet_effets_secondaires {get; set;}
        public string nom_effet_effets_secondaires {get; set;}
    }
}