using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System;

namespace covidipedia.front {

    public static class GenericQuery {

        public static ArrayList QuerySelector(QueryFormInput input, string type, bddcovidipediaContext context) {
            switch(type) {
                case "Hopital":
                    return QueryHopital(input, context);

                case "Cas":
                    return QueryCas(input, context);
                
                case "EffetsSecondaires":
                    return QueryEffetSecondaire(input, context);

                case "Historique":
                    return QueryHistoriqueCas(input, context);

                case "Pathologie":
                    return QueryPathologie(input, context);
                
                case "Personne":
                    return QueryPersonne(input, context);
                
                case "Symptome":
                    return QuerySymptome(input, context);

                case "Traitement":
                    return QueryTraitement(input, context);
                
                case "Vaccin":
                    return QueryVaccin(input, context);
                
                case "Localisation":
                    return QueryLocalisation(input, context);

                default:
                    return null;
            }
        }

        public static ArrayList QueryHopital(QueryFormInput input, bddcovidipediaContext context) {
            IQueryable<Hopital> results = context.Hopitals;
            if (input.name != null) results = results.Where(item => item.NomHopital == input.name);
            results = results.Where(item => (item.NombreLitsHopital >= input.hopitalQuery.totalBeds[0]));
            results = results.Where(item => (item.NombreLitsHopital <= input.hopitalQuery.totalBeds[1])); //TODO: potentiel overflow
            results = results.Where(item => (item.NombreLitsReanimationHopital >= input.hopitalQuery.totalIntensiveBeds[0]));
            results = results.Where(item => (item.NombreLitsReanimationHopital <= input.hopitalQuery.totalIntensiveBeds[1])); //TODO: potentiel overflow
            //TODO: Queries composées Hopital une fois le contenu de la database généré proprement
            return new ArrayList(results.ToList());
        }

        public static ArrayList QueryCas(QueryFormInput input, bddcovidipediaContext context) {
            IQueryable<Ca> results = context.Cas;
            if (input.name != null) results = results.Where(item => item.EtatActuelCas == input.name);
            //TODO: Queries composées Cas une fois le contenu de la database généré proprement
            return new ArrayList(results.ToList());
        }

        public static ArrayList QueryEffetSecondaire(QueryFormInput input, bddcovidipediaContext context) {
            IQueryable<EffetSecondaire> results = context.EffetSecondaires;
            if (input.name != null) results = results.Where(item => item.NomEffetEffetSecondaire == input.name);
            if (input.effetQuery.effetType != null) results = results.Where(item => item.TypeEffetEffetSecondaire == input.effetQuery.effetType);
            //TODO: Queries composées Effet Secondaire une fois le contenu de la database généré proprement
            return new ArrayList(results.ToList());
        }

        public static ArrayList QueryHistoriqueCas(QueryFormInput input, bddcovidipediaContext context) {
            IQueryable<HistoriqueCa> results = context.HistoriqueCas;
            if (input.name != null) results = results.Where(item => item.EtatCasHistoriqueCas == input.name);
            if (input.historiqueQuery.virusStrain != null) results = results.Where(item => item.SoucheVirusHistoriqueCas == input.historiqueQuery.virusStrain);
            results = results.Where(item => ((item.DateDetectionHistoriqueCas >= input.historiqueQuery.detectionDate[0]) && (item.DateDetectionHistoriqueCas < input.historiqueQuery.detectionDate[1])));
            results = results.Where(item => ((item.DateMajHistoriqueCas >= input.historiqueQuery.majDate[0]) && (item.DateMajHistoriqueCas < input.historiqueQuery.majDate[1])));
            //TODO: Queries composées Historique une fois le contenu de la database généré proprement
            return new ArrayList(results.ToList());
        }

        public static ArrayList QueryPathologie(QueryFormInput input, bddcovidipediaContext context) {
            IQueryable<Pathologie> results = context.Pathologies;
            if (input.name != null) results = results.Where(item => item.NomPathologiePathologie == input.name);
            if (input.pathologieQuery.pathologieType != null) results = results.Where(item => item.TypePathologiePathologie == input.pathologieQuery.pathologieType);
            //TODO: Queries composées Pathologie une fois le contenu de la database généré proprement
            return new ArrayList(results.ToList());
        }

        public static ArrayList QueryPersonne(QueryFormInput input, bddcovidipediaContext context) {
            IQueryable<Personne> results = context.Personnes;
            if (input.name != null) results = results.Where(item => item.IdentifiantPersonne == input.name);
            if (input.casPersonneQuery.ethnicOrigin != null) results = results.Where(item => item.EthniePersonne == input.casPersonneQuery.ethnicOrigin);
            results = results.Where(item => ((item.AgePersonne >= input.casPersonneQuery.age[0]) && (item.AgePersonne <= input.casPersonneQuery.age[1])));
            results = results.Where(item => ((item.DateVaccin1Personne >= input.casPersonneQuery.vaccinDate1[0]) && (item.DateVaccin1Personne < input.casPersonneQuery.vaccinDate1[1])));
            results = results.Where(item => ((item.DateVaccin2Personne >= input.casPersonneQuery.vaccinDate2[0]) && (item.DateVaccin1Personne < input.casPersonneQuery.vaccinDate2[1])));
            if (input.casPersonneQuery.personGender != "none") results = results.Where(item => (item.SexePersonne.ToString().ToLower() == input.casPersonneQuery.personGender));
            //TODO: Queries composées Personne une fois le contenu de la database généré proprement
            return new ArrayList(results.ToList());
        }

        public static ArrayList QuerySymptome(QueryFormInput input, bddcovidipediaContext context) {
            IQueryable<Symptome> results = context.Symptomes;
            if (input.name != null) results = results.Where(item => item.NomSymptomeSymptome == input.name);
            if (input.symptomeQuery.symptomeType != null) results = results.Where(item => item.TypeSymptomeSymptome == input.symptomeQuery.symptomeType);
            //TODO: Queries composées Symptome une fois le contenu de la database généré proprement
            return new ArrayList(results.ToList());
        }

        public static ArrayList QueryTraitement(QueryFormInput input, bddcovidipediaContext context) {
            IQueryable<Traitement> results = context.Traitements;
            if (input.name != null) results = results.Where(item => item.NomTraitementTraitement == input.name);
            if (input.traitementQuery.traitementType != null) results = results.Where(item => item.TypeTraitementTraitement == input.traitementQuery.traitementType);
            //TODO: Queries composées Traitement une fois le contenu de la database généré proprement
            return new ArrayList(results.ToList());
        }

        public static ArrayList QueryVaccin(QueryFormInput input, bddcovidipediaContext context) {
            IQueryable<Vaccin> results = context.Vaccins;
            if (input.name != null) results = results.Where(item => item.NomVaccinVaccin == input.name);
            if (input.vaccinQuery.vaccinTypeManufacturer[0] != null) results = results.Where(item => item.TypeVaccinVaccin == input.vaccinQuery.vaccinTypeManufacturer[0]);
            if (input.vaccinQuery.vaccinTypeManufacturer[1] != null) results = results.Where(item => item.FabricantVaccin == input.vaccinQuery.vaccinTypeManufacturer[1]);
            //TODO: Queries composées Vaccin une fois le contenu de la database généré proprement
            return new ArrayList(results.ToList());
        }

        public static ArrayList QueryLocalisation(QueryFormInput input, bddcovidipediaContext context) {
            IQueryable<Localisation> results = context.Localisations;
            if (input.name != null) results = results.Where(item => item.RegionLocalisation == input.name);
            if (input.localisationQuery.department != 0) results = results.Where(item => item.DepartementLocalisation == input.localisationQuery.department);
            if (input.localisationQuery.city != null) results = results.Where(item => item.VilleLocalisation == input.localisationQuery.city);
            //TODO: Queries composées Localisation une fois le contenu de la database généré proprement
            return new ArrayList(results.ToList());
        }

        public static string TableHeadSelector(string type) { 
            switch(type) {
                case "Hopital":
                    return "<tr><th>ID Hopital</th><th>Nom Hopital</th><th>Nombre de Lits</th><th>Nombre de Lits en Réanimation</th></tr>";

                case "Cas":
                    return "<tr><th>ID Cas</th><th>Etat Actuel</th></tr>";
                
                case "EffetsSecondaires":
                    return "<tr><th>ID Effet Secondaire</th><th>Nom Effet Secondaire</th><th>Type Effet Secondaire</th></tr>";

                case "Historique":
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

        public static string TableContentSelector(ArrayList queryResult, string type, Dictionary<int,string> departmentList) { 
            string pageContent = "";
            string department;
            string gender;
            switch(type) {
                case "Hopital":
                    foreach(Hopital hopital in queryResult) {
                        pageContent += $"<tr><th>{hopital.IdHopitalHopital}</th><th>{hopital.NomHopital.Trim()}</th><th>{hopital.NombreLitsHopital}</th><th>{hopital.NombreLitsReanimationHopital}</th></tr>";
                    }
                    break;

                case "Cas":
                    foreach(Ca cas in queryResult) {
                        pageContent += $"<tr><th>{cas.IdCasCas}</th><th>{cas.EtatActuelCas.Trim()}</th></tr>";
                    }
                    break;
                
                case "EffetsSecondaires":
                    foreach(EffetSecondaire effet in queryResult) {
                        pageContent += $"<tr><th>{effet.IdEffetEffetSecondaire}</th><th>{effet.NomEffetEffetSecondaire.Trim()}</th><th>{effet.TypeEffetEffetSecondaire.Trim()}</th></tr>";
                    }
                    break;

                case "Historique":
                    foreach(HistoriqueCa historique in queryResult) {
                        pageContent += $"<tr><th>{historique.IdHistoriqueHistoriqueCas}</th><th>{historique.DateDetectionHistoriqueCas}</th><th>{historique.DateMajHistoriqueCas}</th><th>{historique.EtatCasHistoriqueCas.Trim()}</th><th>{historique.SoucheVirusHistoriqueCas.Trim()}</th></tr>";
                    }
                    break;

                case "Pathologie":
                    foreach(Pathologie pathologie in queryResult) {
                        pageContent += $"<tr><th>{pathologie.IdPathologiePathologie}</th><th>{pathologie.NomPathologiePathologie.Trim()}</th><th>{pathologie.TypePathologiePathologie.Trim()}</th></tr>";
                    }
                    break;
                
                case "Personne":
                    foreach(Personne personne in queryResult) {
                        switch(personne.SexePersonne) {
                            case true:
                                gender = "Homme";
                                break;
                            
                            case false:
                                gender = "Femme";
                                break;
                            
                            default:
                                gender = "Inconnu";
                                break;
                        }
                        pageContent += $"<tr><th>{personne.IdPersonnePersonne}</th><th>{personne.AgePersonne}</th><th>{gender}</th><th>{personne.IdentifiantPersonne.Trim()}</th><th>{personne.DateVaccin1Personne}</th><th>{personne.DateVaccin2Personne}</th><th>{personne.EthniePersonne.Trim()}</th></tr>";
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
                        department = departmentList[(int)localisation.DepartementLocalisation];
                        pageContent += $"<tr><th>{localisation.IdLocalisationLocalisation}</th><th>{localisation.RegionLocalisation.Trim()}</th><th>{department}</th><th>{localisation.VilleLocalisation.Trim()}</th></tr>";
                    }
                    break;

                default:
                    break;
            }
            return pageContent;
        }
    }
}