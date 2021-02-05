using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace covidipedia.front {

    public static class GenericQuery {

        public static ArrayList QuerySelector(string mainCriteriaName, string type, bddcovidipediaContext context) {
            switch(type) {
                case "Hopital":
                    return QueryHopital(mainCriteriaName, context);

                case "Ca":
                    return QueryCas(mainCriteriaName, context);
                
                case "EffetSecondaire":
                    return QueryEffetSecondaire(mainCriteriaName, context);

                case "HistoriqueCa":
                    return QueryHistoriqueCas(mainCriteriaName, context);

                case "Pathologie":
                    return QueryPathologie(mainCriteriaName, context);
                
                case "Personne":
                    return QueryPersonne(mainCriteriaName, context);
                
                case "Symptome":
                    return QuerySymptome(mainCriteriaName, context);

                case "Traitement":
                    return QueryTraitement(mainCriteriaName, context);
                
                case "Vaccin":
                    return QueryVaccin(mainCriteriaName, context);
                
                case "Localisation":
                    return QueryLocalisation(mainCriteriaName, context);

                default:
                    return null;
            }
        }

        public static ArrayList QueryHopital(string mainCriteriaName, bddcovidipediaContext context) {
            List<Hopital> results = new List<Hopital>();
            if (mainCriteriaName != null) {
                results = context.Hopitals
                            .Where(hopital => hopital.NomHopital == mainCriteriaName)
                            .ToList();
            }
            else foreach (Hopital hopital in context.Hopitals) results.Add(hopital);
            return new ArrayList(results);
        }

        public static ArrayList QueryCas(string mainCriteriaName, bddcovidipediaContext context) {
            List<Ca> results = new List<Ca>();
            if (mainCriteriaName != null) {
                results = context.Cas
                            .Where(cas => cas.EtatActuelCas == mainCriteriaName)
                            .ToList();
            }
            else foreach (Ca cas in context.Cas) results.Add(cas);
            return new ArrayList(results);
        }

        public static ArrayList QueryEffetSecondaire(string mainCriteriaName, bddcovidipediaContext context) {
            List<EffetSecondaire> results = new List<EffetSecondaire>();
            if (mainCriteriaName != null) {
                results = context.EffetSecondaires
                            .Where(effet => effet.NomEffetEffetSecondaire == mainCriteriaName)
                            .ToList();
            }
            else foreach (EffetSecondaire effet in context.EffetSecondaires) results.Add(effet);
            return new ArrayList(results);
        }

        public static ArrayList QueryHistoriqueCas(string mainCriteriaName, bddcovidipediaContext context) {
            List<HistoriqueCa> results = new List<HistoriqueCa>();
            if (mainCriteriaName != null) {
                results = context.HistoriqueCas
                            .Where(historique => historique.EtatCasHistoriqueCas == mainCriteriaName)
                            .ToList();
            }
            else foreach (HistoriqueCa historique in context.HistoriqueCas) results.Add(historique);
            return new ArrayList(results);
        }

        public static ArrayList QueryPathologie(string mainCriteriaName, bddcovidipediaContext context) {
            List<Pathologie> results = new List<Pathologie>();
            if (mainCriteriaName != null) {
                results = context.Pathologies
                            .Where(pathologie => pathologie.NomPathologiePathologie == mainCriteriaName)
                            .ToList();
            }
            else foreach (Pathologie pathologie in context.Pathologies) results.Add(pathologie);
            return new ArrayList(results);
        }

        public static ArrayList QueryPersonne(string mainCriteriaName, bddcovidipediaContext context) {
            List<Personne> results = new List<Personne>();
            if (mainCriteriaName != null) {
                results = context.Personnes
                            .Where(personne => personne.IdentifiantPersonne == mainCriteriaName)
                            .ToList();
            }
            else foreach (Personne personne in context.Personnes) results.Add(personne);
            return new ArrayList(results);
        }

        public static ArrayList QuerySymptome(string mainCriteriaName, bddcovidipediaContext context) {
            List<Symptome> results = new List<Symptome>();
            if (mainCriteriaName != null) {
                results = context.Symptomes
                            .Where(symptome => symptome.NomSymptomeSymptome == mainCriteriaName)
                            .ToList();
            }
            else foreach (Symptome symptome in context.Symptomes) results.Add(symptome);
            return new ArrayList(results);
        }

        public static ArrayList QueryTraitement(string mainCriteriaName, bddcovidipediaContext context) {
            List<Traitement> results = new List<Traitement>();
            if (mainCriteriaName != null) {
                results = context.Traitements
                            .Where(traitement => traitement.NomTraitementTraitement == mainCriteriaName)
                            .ToList();
            }
            else foreach (Traitement traitement in context.Traitements) results.Add(traitement);
            return new ArrayList(results);
        }

        public static ArrayList QueryVaccin(string mainCriteriaName, bddcovidipediaContext context) {
            List<Vaccin> results = new List<Vaccin>();
            if (mainCriteriaName != null) {
                results = context.Vaccins
                            .Where(vaccin => vaccin.NomVaccinVaccin == mainCriteriaName)
                            .ToList();
            }
            else foreach (Vaccin vaccin in context.Vaccins) results.Add(vaccin);
            return new ArrayList(results);
        }

        public static ArrayList QueryLocalisation(string mainCriteriaName, bddcovidipediaContext context) {
            List<Localisation> results = new List<Localisation>();
            if (mainCriteriaName != null) {
                results = context.Localisations
                            .Where(localisation => localisation.VilleLocalisation == mainCriteriaName)
                            .ToList();
            }
            else foreach (Localisation localisation in context.Localisations) results.Add(localisation);
            return new ArrayList(results);
        }

        public static string TableHeadSelector(string type) { //C'est pas hyper joli mais on manque de temps pour faire plus propre
            switch(type) {
                case "Hopital":
                    return "<tr><th>ID Hopital</th><th>Nom Hopital</th><th>Nombre de Lits</th><th>Nombre de Lits en Réanimation</th></tr>";

                case "Ca":
                    return "<tr><th>ID Cas</th><th>Etat Actuel</th></tr>";
                
                case "EffetSecondaire":
                    return "<tr><th>ID Effet Secondaire</th><th>Nom Effet Secondaire</th><th>Type Effet Secondaire</th></tr>";

                case "HistoriqueCa":
                    return "<tr><th>ID Historique</th><th>Date Detection</th><th>Date MaJ Historique</th><th>Etat Cas</th><th>Souche Virus</th></tr>";

                case "Pathologie":
                    return "<tr><th>ID Pathologie</th><th>Nom Pathologie</th><th>Type Pathologie</th></tr>";
                
                case "Personne":
                    return "<tr><th>ID Personne</th><th>Age Personne</th><th>Sexe Personne</th><th>Identifiant Anonymisé</th><th>Date Vaccin 1</th><th>Date Vaccin 2</th><th>Ethnie</th></tr>";
                
                case "Symptome":
                    return "<tr><th>ID Symptome</th><th>Nom Symptome</th><th>Type Symptome</th></tr>";

                case "Traitement":
                    return "<tr><th>ID Traitement</th><th>Nom Traitement</th><th>Type Traitement</th></tr>";
                
                case "Vaccin":
                    return "<tr><th>ID Vaccin</th><th>Nom Vaccin</th><th>Type Vaccin</th><th>Nom Fabricant</th></tr>";
                
                case "Localisation":
                    return "<tr><th>ID Localisation</th><th>Region</th><th>Departement</th><th>Ville</th></tr>";

                default:
                    return null;
            }
        }

        public static string TableContentSelector(ArrayList queryResult, string type) { //C'est pas hyper joli mais on manque de temps pour faire plus propre, 2ème édition
            string pageContent = "";
            switch(type) {
                case "Hopital":
                    foreach(Hopital hopital in queryResult) {
                        pageContent += $"<tr><th>{hopital.IdHopitalHopital}</th><th>{hopital.NomHopital.Trim()}</th><th>{hopital.NombreLitsHopital}</th><th>{hopital.NombreLitsReanimationHopital}</th></tr>";
                    }
                    break;

                case "Ca":
                    foreach(Ca cas in queryResult) {
                        pageContent += $"<tr><th>{cas.IdCasCas}</th><th>{cas.EtatActuelCas.Trim()}</th></tr>";
                    }
                    break;
                
                case "EffetSecondaire":
                    foreach(EffetSecondaire effet in queryResult) {
                        pageContent += $"<tr><th>{effet.IdEffetEffetSecondaire}</th><th>{effet.NomEffetEffetSecondaire.Trim()}</th><th>{effet.TypeEffetEffetSecondaire.Trim()}</th></tr>";
                    }
                    break;

                case "HistoriqueCa":
                    foreach(HistoriqueCa historique in queryResult) {
                        pageContent += $"<tr><th>{historique.IdHistoriqueHistoriqueCas}</th><th>{historique.DateDetectionHistoriqueCas}</th><th>{historique.DateMajHistoriqueCas}</th><th>{historique.DateMajHistoriqueCas}</th><th>{historique.EtatCasHistoriqueCas.Trim()}</th><th>{historique.SoucheVirusHistoriqueCas.Trim()}</th></tr>";
                    }
                    break;

                case "Pathologie":
                    foreach(Pathologie pathologie in queryResult) {
                        pageContent += $"<tr><th>{pathologie.IdPathologiePathologie}</th><th>{pathologie.NomPathologiePathologie.Trim()}</th><th>{pathologie.TypePathologiePathologie.Trim()}</th></tr>";
                    }
                    break;
                
                case "Personne":
                    foreach(Personne personne in queryResult) {
                        pageContent += $"<tr><th>{personne.IdPersonnePersonne}</th><th>{personne.AgePersonne}</th><th>{personne.SexePersonne}</th><th>{personne.IdentifiantPersonne.Trim()}</th><th>{personne.DateVaccin1Personne}</th><th>{personne.DateVaccin2Personne}</th><th>{personne.EthniePersonne.Trim()}</th></tr>";
                    }
                    break;
                
                case "Symptome":
                    foreach(Symptome symptome in queryResult) {
                        pageContent += $"<tr><th>{symptome.IdSymptomeSymptome}</th><th>{symptome.NomSymptomeSymptome.Trim()}</th><th>{symptome.TypeSymptomeSymptome.Trim()}</th></tr>";
                    }
                    break;

                case "Traitement":
                    foreach(Traitement traitement in queryResult) {
                        pageContent += $"<tr><th>{traitement.IdTraitementTraitement}</th><th>{traitement.NomTraitementTraitement.Trim()}</th><th>{traitement.TypeTraitementTraitement.Trim()}</th></tr>";
                    }
                    break;
                
                case "Vaccin":
                    foreach(Vaccin vaccin in queryResult) {
                        pageContent += $"<tr><th>{vaccin.IdVaccinVaccin}</th><th>{vaccin.NomVaccinVaccin.Trim()}</th><th>{vaccin.TypeVaccinVaccin.Trim()}</th><th>{vaccin.FabricantVaccin.Trim()}</th></tr>";
                    }
                    break;
                
                case "Localisation":
                    foreach(Localisation localisation in queryResult) {
                        pageContent += $"<tr><th>{localisation.IdLocalisationLocalisation}</th><th>{localisation.RegionLocalisation.Trim()}</th><th>{localisation.DepartementLocalisation}</th><th>{localisation.VilleLocalisation.Trim()}</th></tr>";
                    }
                    break;

                default:
                    break;
            }
            return pageContent;
        }
    }
}