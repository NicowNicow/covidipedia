using System.Collections;
using System.IO;
using Newtonsoft.Json;

namespace covidipedia.front 
{

    public static class CSVWriter {

        private static string delimiter = ",";

        public static void TypeParser(ArrayList results, string type, string fileName) {
            switch(type) {
                case "Hopital":
                    HopitalToCSV(results, fileName);
                    break;

                case "Cas":
                    CasToCSV(results, fileName);
                    break;
                
                case "EffetsSecondaires":
                    EffetSecondaireToCSV(results, fileName);
                    break;

                case "Historique":
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
                
                case "Localisation":
                    LocalisationToCSV(results, fileName);
                    break;
                
                default:
                    break;
            }
        }

        public static void HopitalToCSV(ArrayList results, string fileName) {
            Hopital hopital;
            using (FileStream file = File.Create(fileName)) {
                using (StreamWriter writer = new StreamWriter(file)) {
                    writer.WriteLine("ID Hopital" + delimiter + "Nom Hopital" + delimiter + "Nombre de Lits" + delimiter + "Nombre de Lits en Reanimation");
                    foreach (var result in results) {
                        hopital = JsonConvert.DeserializeObject<Hopital>(result.ToString());
                        writer.WriteLine(hopital.IdHopitalHopital.ToString() + delimiter + hopital.NomHopital.Trim() + delimiter + hopital.NombreLitsHopital.ToString() + delimiter + hopital.NombreLitsReanimationHopital.ToString());
                    }
                }
            }
        }

        public static void EffetSecondaireToCSV(ArrayList results, string fileName) {
            EffetSecondaire effet;
            using (FileStream file = File.Create(fileName)) {
                using (StreamWriter writer = new StreamWriter(file)) {
                    writer.WriteLine("ID Effet Secondaire" + delimiter + "Nom Effet Secondaire" + delimiter + "Type Effet Secondaire");
                    foreach (var result in results) {
                        effet = JsonConvert.DeserializeObject<EffetSecondaire>(result.ToString());
                        writer.WriteLine(effet.IdEffetEffetSecondaire.ToString() + delimiter + effet.NomEffetEffetSecondaire.Trim() + delimiter + effet.NomEffetEffetSecondaire.Trim());
                    }
                }
            }
        }

        public static void CasToCSV(ArrayList results, string fileName) {
            Ca cas;
            using (FileStream file = File.Create(fileName)) {
                using (StreamWriter writer = new StreamWriter(file)) {
                    writer.WriteLine("ID Cas" + delimiter + "Etat Actuel");
                    foreach (var result in results) {
                        cas = JsonConvert.DeserializeObject<Ca>(result.ToString());
                        writer.WriteLine(cas.IdCasCas.ToString() + delimiter + cas.EtatActuelCas.Trim());
                    }
                }
            }
        }

        public static void HistoriqueCasToCSV(ArrayList results, string fileName) {
            HistoriqueCa historique;
            using (FileStream file = File.Create(fileName)) {
                using (StreamWriter writer = new StreamWriter(file)) {
                    writer.WriteLine("ID Historique" + delimiter + "Date Detection" + delimiter + "Date MaJ Historique" + delimiter + "Etat Cas" + delimiter + "Souche Virus");
                    foreach (var result in results) {
                        historique = JsonConvert.DeserializeObject<HistoriqueCa>(result.ToString());
                        writer.WriteLine(historique.IdHistoriqueHistoriqueCas.ToString() + delimiter + historique.DateDetectionHistoriqueCas.ToString() + delimiter + historique.DateMajHistoriqueCas.ToString() + delimiter + historique.EtatCasHistoriqueCas.Trim() + delimiter + historique.SoucheVirusHistoriqueCas.Trim());
                    }
                }
            }
        }

        public static void PersonneToCSV(ArrayList results, string fileName) {
            Personne personne;
            using (FileStream file = File.Create(fileName)) {
                using (StreamWriter writer = new StreamWriter(file)) {
                    writer.WriteLine("ID Personne" + delimiter + "Age Personne" + delimiter + "Sexe Personne" + delimiter + "Identifiant Anonyme" + delimiter + "Date Vaccin 1" + delimiter + "Date Vaccin 2" + delimiter + "Ethnie");
                    foreach (var result in results) {
                        personne = JsonConvert.DeserializeObject<Personne>(result.ToString());
                        writer.WriteLine(personne.IdPersonnePersonne.ToString() + delimiter + personne.AgePersonne.ToString() + delimiter + personne.SexePersonne.Value + delimiter + personne.IdentifiantPersonne + delimiter + personne.DateVaccin1Personne + delimiter + personne.DateVaccin2Personne + delimiter + personne.EthniePersonne);
                    }
                }
            }
        }

        public static void PathologieToCSV(ArrayList results, string fileName) {
            Pathologie pathologie;
            using (FileStream file = File.Create(fileName)) {
                using (StreamWriter writer = new StreamWriter(file)) {
                    writer.WriteLine("ID Pathologie" + delimiter + "Nom Pathologie" + delimiter + "Type Pathologie");
                    foreach (var result in results) {
                        pathologie = JsonConvert.DeserializeObject<Pathologie>(result.ToString());
                        writer.WriteLine(pathologie.IdPathologiePathologie.ToString() + delimiter + pathologie.NomPathologiePathologie.Trim() + delimiter + pathologie.TypePathologiePathologie.Trim());
                    }
                }
            }
        }

        public static void SymptomeToCSV(ArrayList results, string fileName) {
            Symptome symptome;
            using (FileStream file = File.Create(fileName)) {
                using (StreamWriter writer = new StreamWriter(file)) {
                    writer.WriteLine("ID Symptome" + delimiter + "Nom Symptome" + delimiter + "Type Symptome");
                    foreach (var result in results) {
                        symptome = JsonConvert.DeserializeObject<Symptome>(result.ToString());
                        writer.WriteLine(symptome.IdSymptomeSymptome.ToString() + delimiter + symptome.NomSymptomeSymptome.Trim() + delimiter + symptome.TypeSymptomeSymptome.Trim());
                    }
                }
            }
        }

        public static void TraitementToCSV(ArrayList results, string fileName) {
            Traitement traitement;
            using (FileStream file = File.Create(fileName)) {
                using (StreamWriter writer = new StreamWriter(file)) {
                    writer.WriteLine("ID Traitement" + delimiter + "Nom Traitement" + delimiter + "Type Traitement");
                    foreach (var result in results) {
                        traitement = JsonConvert.DeserializeObject<Traitement>(result.ToString());
                        writer.WriteLine(traitement.IdTraitementTraitement.ToString() + delimiter + traitement.NomTraitementTraitement.Trim() + delimiter + traitement.TypeTraitementTraitement.Trim());
                    }
                }
            }
        }

        public static void VaccinToCSV(ArrayList results, string fileName) {
            Vaccin vaccin;
            using (FileStream file = File.Create(fileName)) {
                using (StreamWriter writer = new StreamWriter(file)) {
                    writer.WriteLine("ID Vaccin" + delimiter + "Nom Vaccin" + delimiter + "Type Vaccin" + delimiter + "Nom Fabricant");
                    foreach (var result in results) {
                        vaccin = JsonConvert.DeserializeObject<Vaccin>(result.ToString());
                        writer.WriteLine(vaccin.IdVaccinVaccin.ToString() + delimiter + vaccin.NomVaccinVaccin.Trim() + delimiter + vaccin.TypeVaccinVaccin.Trim() + delimiter + vaccin.FabricantVaccin.Trim());
                    }
                }
            }
        }

        public static void LocalisationToCSV(ArrayList results, string fileName) {
            Localisation localisation;
            using (FileStream file = File.Create(fileName)) {
                using (StreamWriter writer = new StreamWriter(file)) {
                    writer.WriteLine("ID Localisation" + delimiter + "Region" + delimiter + "Departement" + delimiter + "Ville");
                    foreach (var result in results) {
                        localisation = JsonConvert.DeserializeObject<Localisation>(result.ToString());
                        writer.WriteLine(localisation.IdLocalisationLocalisation.ToString() + delimiter + localisation.RegionLocalisation.Trim() + delimiter + localisation.DepartementLocalisation.ToString() + delimiter + localisation.VilleLocalisation.Trim());
                    }
                }
            }
        }
    }
}