using System;
using System.ComponentModel.DataAnnotations;
namespace covidipedia.front
{
    public class Personne
    {
        [Key]
        public int id_personne_personne {get; set;}
        public int age_personne {get; set;}
        public DateTime date_vaccin_patient {get; set;}
        public bool sexe_personne {get; set;}
        public int cas_id_cas_cas {get; set;}
        public int id_localisation_localisation {get; set;}
        public int vaccin_id_vaccin_vaccin {get; set;}
    }
}