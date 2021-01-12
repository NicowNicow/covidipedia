using System.ComponentModel.DataAnnotations;
namespace covidipedia.front
{
    public class Symptomes
    {
        [Key]
        public int id_symptome_symptomes {get; set;}
        public string nom_symptome_symptomes {get; set;}
    }
}