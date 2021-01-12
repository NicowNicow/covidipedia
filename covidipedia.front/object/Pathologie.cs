using System.ComponentModel.DataAnnotations;
namespace covidipedia.front
{
    public class Pathologie
    {
        [Key]
        public int id_pathologie_pathologie {get; set;}
        public string nom_pathologie_pathologie {get; set;}
    }
}