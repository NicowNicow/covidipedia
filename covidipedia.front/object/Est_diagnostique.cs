using System.ComponentModel.DataAnnotations;

namespace covidipedia.front
{
    public class Est_diagnostique
    {
        [Key]
        public int id_cas_cas {get; set;}
        public int id_symptome_symptomes {get; set;}
    }
}