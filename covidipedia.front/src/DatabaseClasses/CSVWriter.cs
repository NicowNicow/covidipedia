using System.Collections;

namespace covidipedia.front {

    public static class CSVWriter {

        public static void TypeParser(ArrayList results, string type, string fileName) {
            switch(type) {
                case "Hopital":
                    HopitalToCSV(results, fileName);
                    break;

                case "Ca":
                    CasToCSV(results, fileName);
                    break;
                
                case "EffetSecondaire":
                    EffetSecondaireToCSV(results, fileName);
                    break;

                case "HistoriqueCa":
                    HistoriqueCasToCSV(results, fileName);
                    break;

                case "Pathologie":
                    HopitalToCSV(results, fileName);
                    break;
                
                case "Personne":
                    PersonneToCSV(results, fileName);
                    break;
                
                case "Symptome":
                    SymptomeToCSV(results, fileName);
                    break;

                case "Traitement":
                    TraitementToCSV(results, fileName);
                    break;
                
                case "Vaccin":
                    VaccinToCSV(results, fileName);
                    break;
                
                default:
                    break;
            }
        }

        public static void HopitalToCSV(ArrayList results, string fileName) {}

        public static void EffetSecondaireToCSV(ArrayList results, string fileName) {}

        public static void CasToCSV(ArrayList results, string fileName) {}

        public static void HistoriqueCasToCSV(ArrayList results, string fileName) {}

        public static void PersonneToCSV(ArrayList results, string fileName) {}

        public static void PathologieToCSV(ArrayList results, string fileName) {}

        public static void SymptomeToCSV(ArrayList results, string fileName) {}

        public static void TraitementToCSV(ArrayList results, string fileName) {}

        public static void VaccinToCSV(ArrayList results, string fileName) {}
    }
}