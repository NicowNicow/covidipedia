using System;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace covidipedia.front
{
    public class QueryFormInput {
            [Required(ErrorMessage = "Veuillez choisir un critère principal!")]
            public string type { get; set; }
            public string name { get; set; }
            public CasPersonneQuery casPersonneQuery {get; set;}
            public EffetSecondaireQuery effetQuery {get; set;}
            public HistoriqueQuery historiqueQuery {get; set;}
            public HopitalQuery hopitalQuery {get; set;}
            public LocalisationQuery localisationQuery {get; set;}
            public PathologieQuery pathologieQuery {get; set;}
            public SymptomeQuery symptomeQuery {get; set;}
            public TraitementQuery traitementQuery {get; set;}
            public VaccinQuery vaccinQuery {get; set;}
        }

    public class EffetSecondaireQuery {
        public string effetType {get; set;}
        public bool personneGender {get; set;}
        public int[] personneAge {get; set;} = new int[2];
        public int[] caseNumber {get; set;} = new int[2];
        public string[] traitementNameType {get; set;} = new string[2];
        public string[] vaccinNameTypeManufacturer {get; set;} = new string[3];
    }

    public class HistoriqueQuery {
        public DateTime[] detectionDate {get; set;} = new DateTime[2];
        public DateTime[] majDate {get; set;} = new DateTime[2];
        public string currentState {get; set;}
        public string virusStrain {get; set;}
        public string[] pathologieNameType {get; set;} = new string[2];
        public string[] symptomeNameType {get; set;} = new string[2];
        public string[] traitementNameType {get; set;} = new string[2];
    }

    public class HopitalQuery {
        public int[] totalBeds {get; set;} = new int[2];
        public int[] freeBeds {get; set;} = new int[2];
        public int[] totalIntensiveBeds {get; set;} = new int[2];
        public int[] freeIntensiveBeds {get; set;} = new int[2];
        public string region {get; set;}
        public int department {get; set;}
        public string city {get; set;}
        public int[] caseNumber {get; set;} = new int[2];
    }

    public class LocalisationQuery {
        public int department {get; set;}
        public string city {get; set;}
        public int[] caseNumber {get; set;} = new int[2];
    }

    public class PathologieQuery {
        public string pathologieType {get; set;}
        public int[] caseNumber {get; set;} = new int[2];
    }

    public class CasPersonneQuery {
        public int[] age {get; set;} = new int[2];
        public bool personGender {get; set;}
        public string ethnicOrigin {get; set;}
        public DateTime[] vaccinDate1 {get; set;} = new DateTime[2];
        public DateTime[] vaccinDate2 {get; set;} = new DateTime[2];
        public string[] vaccinNameTypeManufacturer {get; set;} = new string[3];
        public string[] effetNameType {get; set;} = new string[2];
        public string region {get; set;}
        public int department {get; set;}
        public string city {get; set;}
        public string currentState {get; set;}
        public string hopitalName {get; set;}
        public string virusStrain {get; set;}
        public string[] symptomeNameType {get; set;} = new string[2];
        public string[] pathologieNameType {get; set;} = new string[2];
        public string[] traitementNameType {get; set;} = new string[2];
    }

    public class SymptomeQuery {
        public string symptomeType {get; set;}
        public int[] caseNumber {get; set;} = new int[2];
    }

    public class TraitementQuery {
        public string traitementType {get; set;}
        public int[] caseNumber {get; set;} = new int[2];
    }

    public class VaccinQuery {
        public string[] vaccinTypeManufacturer {get; set;} = new string[2];
        public string[] effetNameType {get; set;} = new string[2];
        public int[] vaccinatedNumber {get; set;} = new int[2];
    }
}