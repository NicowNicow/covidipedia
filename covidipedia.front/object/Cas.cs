using System;
using System.ComponentModel.DataAnnotations;
namespace covidipedia.front
{
    public class Cas
    {
        [Key]
        public int id_cas_cas {get; set;}
        public DateTime date_detection_patient {get; set;}
        public DateTime date_admission_patient {get; set;}
        public string etat_patient_patient {get; set;}
        public string identifiant_patient {get; set;}
        public int hopital_id_hopital_hopital {get; set;}
        public int personne_id_personne_personne {get; set;}
    }
}