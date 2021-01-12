using System.ComponentModel.DataAnnotations;

namespace covidipedia.front
{
    public class A_pathologie
    {
        [Key]
        public int id_cas_cas {get; set;}
        public int id_pathologie_pathologie {get; set;}
    }
}