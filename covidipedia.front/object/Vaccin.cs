using System.ComponentModel.DataAnnotations;
namespace covidipedia.front
{
    public class Vaccin
    {
        [Key]
        public int id_vaccin_vaccin {get; set;}
        public string nom_vaccin_vaccin {get; set;}
        public string type_vaccin_vaccin {get; set;}
        public string fabricant_vaccin {get; set;}
    }
}