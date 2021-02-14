using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System;

namespace covidipedia.front {

    public static class GenericQuery {

        public static ArrayList QuerySelector(QueryFormInput input, string type, bddcovidipediaContext context) {
            switch(type) {
                case "Hopital": return QueryHopital(input, context);

                case "Cas": return QueryCas(input, context);
                
                case "EffetsSecondaires": return QueryEffetSecondaire(input, context);

                case "Historique": return QueryHistoriqueCas(input, context);

                case "Pathologie": return QueryPathologie(input, context);
                
                case "Personne": return QueryPersonne(input, context);
                
                case "Symptome": return QuerySymptome(input, context);

                case "Traitement": return QueryTraitement(input, context);
                
                case "Vaccin": return QueryVaccin(input, context);
                
                case "Localisation": return QueryLocalisation(input, context);

                default: return null;
            }
        }

        public static string TableHeadSelector(string type) { 
            switch(type) {
                case "Hopital": return "<tr><th>ID Hopital</th><th>Nom Hopital</th><th>Nombre de Lits</th><th>Nombre de Lits en Réanimation</th></tr>";

                case "Cas": return "<tr><th>ID Cas</th><th>Etat Actuel</th></tr>";
                
                case "EffetsSecondaires": return "<tr><th>ID Effet Secondaire</th><th>Nom Effet Secondaire</th><th>Type Effet Secondaire</th></tr>";

                case "Historique": return "<tr><th>ID Historique</th><th>Date Detection</th><th>Date MaJ Historique</th><th>Etat Cas</th><th>Souche Virus</th></tr>";

                case "Pathologie": return "<tr><th>ID Pathologie</th><th>Nom Pathologie</th><th>Type Pathologie</th></tr>";
                
                case "Personne": return "<tr><th>ID Personne</th><th>Age Personne</th><th>Sexe Personne</th><th>Identifiant Anonymisé</th><th>Date Vaccin 1</th><th>Date Vaccin 2</th><th>Ethnie</th></tr>";
                
                case "Symptome": return "<tr><th>ID Symptome</th><th>Nom Symptome</th><th>Type Symptome</th></tr>";

                case "Traitement": return "<tr><th>ID Traitement</th><th>Nom Traitement</th><th>Type Traitement</th></tr>";
                
                case "Vaccin": return "<tr><th>ID Vaccin</th><th>Nom Vaccin</th><th>Type Vaccin</th><th>Nom Fabricant</th></tr>";
                
                case "Localisation": return "<tr><th>ID Localisation</th><th>Region</th><th>Departement</th><th>Ville</th></tr>";

                default: return null;
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

        private static ArrayList QueryHopital(QueryFormInput input, bddcovidipediaContext context) {
            IQueryable<Hopital> results = context.Hopitals;
            if (input.name != null) results = results.Where(item => item.NomHopital == input.name);
            results = results.Where(item => (item.NombreLitsHopital >= input.hopitalQuery.totalBeds[0]));
            results = results.Where(item => (item.NombreLitsHopital <= input.hopitalQuery.totalBeds[1]));
            results = results.Where(item => (item.NombreLitsReanimationHopital >= input.hopitalQuery.totalIntensiveBeds[0]));
            results = results.Where(item => (item.NombreLitsReanimationHopital <= input.hopitalQuery.totalIntensiveBeds[1]));
            results = JoinQueriesHopital(results, input, context);
            return new ArrayList(results.ToList());
        }

        private static ArrayList QueryCas(QueryFormInput input, bddcovidipediaContext context) {
            IQueryable<Ca> results = context.Cas;
            if (input.name != null) results = results.Where(item => item.EtatActuelCas == input.name);
            results = JoinQueriesCas(results, input, context);
            return new ArrayList(results.ToList());
        }

        private static ArrayList QueryEffetSecondaire(QueryFormInput input, bddcovidipediaContext context) {
            IQueryable<EffetSecondaire> results = context.EffetSecondaires;
            if (input.name != null) results = results.Where(item => item.NomEffetEffetSecondaire == input.name);
            if (input.effetQuery.effetType != null) results = results.Where(item => item.TypeEffetEffetSecondaire == input.effetQuery.effetType);
            results = JoinQueryEffet(results, input, context);
            return new ArrayList(results.ToList());
        }

        private static ArrayList QueryHistoriqueCas(QueryFormInput input, bddcovidipediaContext context) {
            IQueryable<HistoriqueCa> results = context.HistoriqueCas;
            if (input.name != null) results = results.Where(item => item.EtatCasHistoriqueCas == input.name);
            if (input.historiqueQuery.virusStrain != null) results = results.Where(item => item.SoucheVirusHistoriqueCas == input.historiqueQuery.virusStrain);
            results = results.Where(item => ((item.DateDetectionHistoriqueCas >= input.historiqueQuery.detectionDate[0]) && (item.DateDetectionHistoriqueCas < input.historiqueQuery.detectionDate[1])));
            results = results.Where(item => ((item.DateMajHistoriqueCas >= input.historiqueQuery.majDate[0]) && (item.DateMajHistoriqueCas < input.historiqueQuery.majDate[1])));
            results = JoinQueryHistorique(results, input, context);
            return new ArrayList(results.ToList());
        }

        private static ArrayList QueryPathologie(QueryFormInput input, bddcovidipediaContext context) {
            IQueryable<Pathologie> results = context.Pathologies;
            if (input.name != null) results = results.Where(item => item.NomPathologiePathologie == input.name);
            if (input.pathologieQuery.pathologieType != null) results = results.Where(item => item.TypePathologiePathologie == input.pathologieQuery.pathologieType);
            results = JoinQueryPathologie(results, input, context);
            return new ArrayList(results.ToList());
        }

        private static ArrayList QueryPersonne(QueryFormInput input, bddcovidipediaContext context) {
            IQueryable<Personne> results = context.Personnes;
            if (input.name != null) results = results.Where(item => item.IdentifiantPersonne == input.name);
            if (input.casPersonneQuery.ethnicOrigin != null) results = results.Where(item => item.EthniePersonne == input.casPersonneQuery.ethnicOrigin);
            results = results.Where(item => ((item.AgePersonne >= input.casPersonneQuery.age[0]) && (item.AgePersonne <= input.casPersonneQuery.age[1])));
            results = results.Where(item => ((item.DateVaccin1Personne >= input.casPersonneQuery.vaccinDate1[0]) && (item.DateVaccin1Personne < input.casPersonneQuery.vaccinDate1[1])));
            results = results.Where(item => ((item.DateVaccin2Personne >= input.casPersonneQuery.vaccinDate2[0]) && (item.DateVaccin1Personne < input.casPersonneQuery.vaccinDate2[1])));
            if (input.casPersonneQuery.personGender != "none") results = results.Where(item => (item.SexePersonne.ToString().ToLower() == input.casPersonneQuery.personGender));
            results = JoinQueryPersonne(results, input, context);
            return new ArrayList(results.ToList());
        }

        private static ArrayList QuerySymptome(QueryFormInput input, bddcovidipediaContext context) {
            IQueryable<Symptome> results = context.Symptomes;
            if (input.name != null) results = results.Where(item => item.NomSymptomeSymptome == input.name);
            if (input.symptomeQuery.symptomeType != null) results = results.Where(item => item.TypeSymptomeSymptome == input.symptomeQuery.symptomeType);
            results = JoinQuerySymptome(results, input, context);
            return new ArrayList(results.ToList());
        }

        private static ArrayList QueryTraitement(QueryFormInput input, bddcovidipediaContext context) {
            IQueryable<Traitement> results = context.Traitements;
            if (input.name != null) results = results.Where(item => item.NomTraitementTraitement == input.name);
            if (input.traitementQuery.traitementType != null) results = results.Where(item => item.TypeTraitementTraitement == input.traitementQuery.traitementType);
            results = JoinQueryTraitement(results, input, context);
            return new ArrayList(results.ToList());
        }

        private static ArrayList QueryVaccin(QueryFormInput input, bddcovidipediaContext context) {
            IQueryable<Vaccin> results = context.Vaccins;
            if (input.name != null) results = results.Where(item => item.NomVaccinVaccin == input.name);
            if (input.vaccinQuery.vaccinTypeManufacturer[0] != null) results = results.Where(item => item.TypeVaccinVaccin == input.vaccinQuery.vaccinTypeManufacturer[0]);
            if (input.vaccinQuery.vaccinTypeManufacturer[1] != null) results = results.Where(item => item.FabricantVaccin == input.vaccinQuery.vaccinTypeManufacturer[1]);
            results = JoinQueryVaccin(results, input, context);
            return new ArrayList(results.ToList());
        }

        private static ArrayList QueryLocalisation(QueryFormInput input, bddcovidipediaContext context) {
            IQueryable<Localisation> results = context.Localisations;
            if (input.name != null) results = results.Where(item => item.RegionLocalisation == input.name);
            if (input.localisationQuery.department != 0) results = results.Where(item => item.DepartementLocalisation == input.localisationQuery.department);
            if (input.localisationQuery.city != null) results = results.Where(item => item.VilleLocalisation == input.localisationQuery.city);
            results = JoinQueryLocalisation(results, input, context);
            return new ArrayList(results.ToList());
        }
        
        private static IQueryable<Hopital> JoinQueriesHopital(IQueryable<Hopital> results, QueryFormInput input, bddcovidipediaContext context) {
            //Region
            if (input.hopitalQuery.region != null) results = results.Join(context.Localisations, 
                                                                          hopital => hopital.IdLocalisationLocalisation,
                                                                          localisation => localisation.IdLocalisationLocalisation,
                                                                          (hopital, localisation) => new {hopital, localisation})
                                                                    .Where(item => item.localisation.RegionLocalisation == input.hopitalQuery.region)
                                                                    .Select(item => item.hopital);
            //Departement
            if (input.hopitalQuery.department != 0) results = results.Join(context.Localisations, 
                                                                          hopital => hopital.IdLocalisationLocalisation,
                                                                          localisation => localisation.IdLocalisationLocalisation,
                                                                          (hopital, localisation) => new {hopital, localisation})
                                                                    .Where(item => item.localisation.DepartementLocalisation == input.hopitalQuery.department)
                                                                    .Select(item => item.hopital);
            //Ville
            if (input.hopitalQuery.city != null) results = results.Join(context.Localisations, 
                                                                          hopital => hopital.IdLocalisationLocalisation,
                                                                          localisation => localisation.IdLocalisationLocalisation,
                                                                          (hopital, localisation) => new {hopital, localisation})
                                                                    .Where(item => item.localisation.VilleLocalisation == input.hopitalQuery.city)
                                                                    .Select(item => item.hopital);
            //TODO: Hopital Counts Cas, Lits Dispo, Lits Dispo en réanimation
            return results;
        }

        private static IQueryable<Ca> JoinQueriesCas(IQueryable<Ca> results, QueryFormInput input, bddcovidipediaContext context) {
            //Region
            if (input.casPersonneQuery.region != null) results = results.Join(context.Hopitals, 
                                                                          cas => cas.HopitalIdHopitalHopital,
                                                                          hopital => hopital.IdHopitalHopital,
                                                                          (cas, hopital) => new {cas, hopital})
                                                                        .Join(context.Localisations,
                                                                            firstJoin => firstJoin.hopital.IdLocalisationLocalisation,
                                                                            localisation => localisation.IdLocalisationLocalisation,
                                                                            (firstJoin, localisation) => new {firstJoin, localisation})
                                                                        .Where(item => item.localisation.RegionLocalisation == input.casPersonneQuery.region)
                                                                        .Select(item => item.firstJoin.cas);
            //Departement
            if (input.casPersonneQuery.department != 0) results = results.Join(context.Hopitals, 
                                                                          cas => cas.HopitalIdHopitalHopital,
                                                                          hopital => hopital.IdHopitalHopital,
                                                                          (cas, hopital) => new {cas, hopital})
                                                                        .Join(context.Localisations,
                                                                            firstJoin => firstJoin.hopital.IdLocalisationLocalisation,
                                                                            localisation => localisation.IdLocalisationLocalisation,
                                                                            (firstJoin, localisation) => new {firstJoin, localisation})
                                                                        .Where(item => item.localisation.DepartementLocalisation == input.casPersonneQuery.department)
                                                                        .Select(item => item.firstJoin.cas);
            //Ville
            if (input.casPersonneQuery.city != null) results = results.Join(context.Hopitals, 
                                                                          cas => cas.HopitalIdHopitalHopital,
                                                                          hopital => hopital.IdHopitalHopital,
                                                                          (cas, hopital) => new {cas, hopital})
                                                                        .Join(context.Localisations,
                                                                            firstJoin => firstJoin.hopital.IdLocalisationLocalisation,
                                                                            localisation => localisation.IdLocalisationLocalisation,
                                                                            (firstJoin, localisation) => new {firstJoin, localisation})
                                                                    .Where(item => item.localisation.VilleLocalisation == input.casPersonneQuery.city)
                                                                    .Select(item => item.firstJoin.cas);
            //Hopital
            if (input.casPersonneQuery.city != null) results = results.Join(context.Hopitals, 
                                                                          cas => cas.HopitalIdHopitalHopital,
                                                                          hopital => hopital.IdHopitalHopital,
                                                                          (cas, hopital) => new {cas, hopital})
                                                                    .Where(item => item.hopital.NomHopital == input.casPersonneQuery.hopitalName)
                                                                    .Select(item => item.cas);
            //Souche
            if (input.casPersonneQuery.virusStrain != null) results = results.Join(context.HistoriqueCas, 
                                                                          cas => cas.IdCasCas,
                                                                          historique => historique.IdCasCas,
                                                                          (cas, historique) => new {cas, historique})
                                                                    .Where(item => item.historique.SoucheVirusHistoriqueCas == input.casPersonneQuery.virusStrain)
                                                                    .Select(item => item.cas);
            //Ethnie
            if (input.casPersonneQuery.ethnicOrigin != null) results = results.Join(context.Personnes, 
                                                                          cas => cas.PersonneIdPersonnePersonne,
                                                                          personne => personne.IdPersonnePersonne,
                                                                          (cas, personne) => new {cas, personne})
                                                                    .Where(item => item.personne.EthniePersonne == input.casPersonneQuery.ethnicOrigin)
                                                                    .Select(item => item.cas);
            //Gender
            if (input.casPersonneQuery.personGender != "none") results = results.Join(context.Personnes, 
                                                                          cas => cas.PersonneIdPersonnePersonne,
                                                                          personne => personne.IdPersonnePersonne,
                                                                          (cas, personne) => new {cas, personne})
                                                                    .Where(item => item.personne.SexePersonne.ToString().ToLower() == input.casPersonneQuery.personGender)
                                                                    .Select(item => item.cas);
            //Nom de Pathologie
            if (input.casPersonneQuery.pathologieNameType[0] != null) results = results.Join(context.AyantLesPathologies,
                                                                                            cas => cas.IdCasCas,
                                                                                            pathologieLinker => pathologieLinker.IdCasCas,
                                                                                            (cas, pathologieLinker) => new {cas, pathologieLinker})
                                                                                        .Join(context.Pathologies,
                                                                                            firstJoin => firstJoin.pathologieLinker.IdPathologiePathologie,
                                                                                            pathologie => pathologie.IdPathologiePathologie,
                                                                                            (firstJoin, pathologie) => new {firstJoin, pathologie})
                                                                                        .Where(item => item.pathologie.NomPathologiePathologie == input.casPersonneQuery.pathologieNameType[0])
                                                                                        .Select(item => item.firstJoin.cas);
            //Type de Pathologie
            if (input.casPersonneQuery.pathologieNameType[1] != null) results = results.Join(context.AyantLesPathologies,
                                                                                            cas => cas.IdCasCas,
                                                                                            pathologieLinker => pathologieLinker.IdCasCas,
                                                                                            (cas, pathologieLinker) => new {cas, pathologieLinker})
                                                                                        .Join(context.Pathologies,
                                                                                            firstJoin => firstJoin.pathologieLinker.IdPathologiePathologie,
                                                                                            pathologie => pathologie.IdPathologiePathologie,
                                                                                            (firstJoin, pathologie) => new {firstJoin, pathologie})
                                                                                        .Where(item => item.pathologie.TypePathologiePathologie == input.casPersonneQuery.pathologieNameType[1])
                                                                                        .Select(item => item.firstJoin.cas);
            //Nom de Symptome
            if (input.casPersonneQuery.symptomeNameType[0] != null) results = results.Join(context.EstDiagnostiques,
                                                                                            cas => cas.IdCasCas,
                                                                                            symptomeLinker => symptomeLinker.IdCasCas,
                                                                                            (cas, symptomeLinker) => new {cas, symptomeLinker})
                                                                                        .Join(context.Symptomes,
                                                                                            firstJoin => firstJoin.symptomeLinker.IdSymptomeSymptome,
                                                                                            symptome => symptome.IdSymptomeSymptome,
                                                                                            (firstJoin, symptome) => new {firstJoin, symptome})
                                                                                        .Where(item => item.symptome.NomSymptomeSymptome == input.casPersonneQuery.symptomeNameType[0])
                                                                                        .Select(item => item.firstJoin.cas);
            //Type de Symptome
            if (input.casPersonneQuery.symptomeNameType[1] != null) results = results.Join(context.EstDiagnostiques,
                                                                                            cas => cas.IdCasCas,
                                                                                            symptomeLinker => symptomeLinker.IdCasCas,
                                                                                            (cas, symptomeLinker) => new {cas, symptomeLinker})
                                                                                        .Join(context.Symptomes,
                                                                                            firstJoin => firstJoin.symptomeLinker.IdSymptomeSymptome,
                                                                                            symptome => symptome.IdSymptomeSymptome,
                                                                                            (firstJoin, symptome) => new {firstJoin, symptome})
                                                                                        .Where(item => item.symptome.TypeSymptomeSymptome == input.casPersonneQuery.symptomeNameType[1])
                                                                                        .Select(item => item.firstJoin.cas);
            //Nom de Traitement
            if (input.casPersonneQuery.traitementNameType[0] != null) results = results.Join(context.RecoitLeTraitements,
                                                                                            cas => cas.IdCasCas,
                                                                                            traitementLinker => traitementLinker.IdCasCas,
                                                                                            (cas, traitementLinker) => new {cas, traitementLinker})
                                                                                        .Join(context.Traitements,
                                                                                            firstJoin => firstJoin.traitementLinker.IdTraitementTraitement,
                                                                                            traitement => traitement.IdTraitementTraitement,
                                                                                            (firstJoin, traitement) => new {firstJoin, traitement})
                                                                                        .Where(item => item.traitement.NomTraitementTraitement == input.casPersonneQuery.traitementNameType[0])
                                                                                        .Select(item => item.firstJoin.cas);
            //Type de Traitement
            if (input.casPersonneQuery.traitementNameType[1] != null) results = results.Join(context.RecoitLeTraitements,
                                                                                            cas => cas.IdCasCas,
                                                                                            traitementLinker => traitementLinker.IdCasCas,
                                                                                            (cas, traitementLinker) => new {cas, traitementLinker})
                                                                                        .Join(context.Traitements,
                                                                                            firstJoin => firstJoin.traitementLinker.IdTraitementTraitement,
                                                                                            traitement => traitement.IdTraitementTraitement,
                                                                                            (firstJoin, traitement) => new {firstJoin, traitement})
                                                                                        .Where(item => item.traitement.TypeTraitementTraitement == input.casPersonneQuery.traitementNameType[1])
                                                                                        .Select(item => item.firstJoin.cas);
            //Nom de Vaccin
            if (input.casPersonneQuery.vaccinNameTypeManufacturer[0] != null) results = results.Join(context.Personnes,
                                                                                                    cas => cas.PersonneIdPersonnePersonne,
                                                                                                    personne => personne.IdPersonnePersonne,
                                                                                                    (cas, personne) => new {cas, personne})
                                                                                                .Join(context.Vaccins,
                                                                                                    firstJoin => firstJoin.personne.VaccinIdVaccinVaccin,
                                                                                                    vaccin => vaccin.IdVaccinVaccin,
                                                                                                    (firstJoin, vaccin) => new {firstJoin, vaccin})
                                                                                                .Where (item => item.vaccin.NomVaccinVaccin == input.casPersonneQuery.vaccinNameTypeManufacturer[0])
                                                                                                .Select(item => item.firstJoin.cas);
            //Type de Vaccin
            if (input.casPersonneQuery.vaccinNameTypeManufacturer[1] != null) results = results.Join(context.Personnes,
                                                                                                    cas => cas.PersonneIdPersonnePersonne,
                                                                                                    personne => personne.IdPersonnePersonne,
                                                                                                    (cas, personne) => new {cas, personne})
                                                                                                .Join(context.Vaccins,
                                                                                                    firstJoin => firstJoin.personne.VaccinIdVaccinVaccin,
                                                                                                    vaccin => vaccin.IdVaccinVaccin,
                                                                                                    (firstJoin, vaccin) => new {firstJoin, vaccin})
                                                                                                .Where (item => item.vaccin.TypeVaccinVaccin == input.casPersonneQuery.vaccinNameTypeManufacturer[1])
                                                                                                .Select(item => item.firstJoin.cas);
            //Fabricant de Vaccin
            if (input.casPersonneQuery.vaccinNameTypeManufacturer[2] != null) results = results.Join(context.Personnes,
                                                                                                    cas => cas.PersonneIdPersonnePersonne,
                                                                                                    personne => personne.IdPersonnePersonne,
                                                                                                    (cas, personne) => new {cas, personne})
                                                                                                .Join(context.Vaccins,
                                                                                                    firstJoin => firstJoin.personne.VaccinIdVaccinVaccin,
                                                                                                    vaccin => vaccin.IdVaccinVaccin,
                                                                                                    (firstJoin, vaccin) => new {firstJoin, vaccin})
                                                                                                .Where (item => item.vaccin.FabricantVaccin == input.casPersonneQuery.vaccinNameTypeManufacturer[2])
                                                                                                .Select(item => item.firstJoin.cas);
            //Nom d'Effet Secondaire
            if (input.casPersonneQuery.effetNameType[0] != null) results = results.Join(context.Personnes,
                                                                                            cas => cas.PersonneIdPersonnePersonne,
                                                                                            personne => personne.IdPersonnePersonne,
                                                                                            (cas, personne) => new {cas, personne})
                                                                                    .Join(context.RessentEffetSecondaires,
                                                                                            firstJoin => firstJoin.personne.IdPersonnePersonne,
                                                                                            effetLinker => effetLinker.IdPersonnePersonne,
                                                                                            (firstJoin, effetLinker) => new {firstJoin, effetLinker})
                                                                                    .Join(context.EffetSecondaires,
                                                                                            secondJoin => secondJoin.effetLinker.IdEffetEffetSecondaire,
                                                                                            effet => effet.IdEffetEffetSecondaire,
                                                                                            (secondJoin, effet) => new {secondJoin, effet})
                                                                                    .Where (item => item.effet.NomEffetEffetSecondaire == input.casPersonneQuery.effetNameType[0])
                                                                                    .Select(item => item.secondJoin.firstJoin.cas);
            //Type d'Effet Secondaire
            if (input.casPersonneQuery.effetNameType[1] != null) results = results.Join(context.Personnes,
                                                                                            cas => cas.PersonneIdPersonnePersonne,
                                                                                            personne => personne.IdPersonnePersonne,
                                                                                            (cas, personne) => new {cas, personne})
                                                                                    .Join(context.RessentEffetSecondaires,
                                                                                            firstJoin => firstJoin.personne.IdPersonnePersonne,
                                                                                            effetLinker => effetLinker.IdPersonnePersonne,
                                                                                            (firstJoin, effetLinker) => new {firstJoin, effetLinker})
                                                                                    .Join(context.EffetSecondaires,
                                                                                            secondJoin => secondJoin.effetLinker.IdEffetEffetSecondaire,
                                                                                            effet => effet.IdEffetEffetSecondaire,
                                                                                            (secondJoin, effet) => new {secondJoin, effet})
                                                                                    .Where (item => item.effet.TypeEffetEffetSecondaire == input.casPersonneQuery.effetNameType[1])
                                                                                    .Select(item => item.secondJoin.firstJoin.cas);
            //Age
            results = results.Join(context.Personnes,
                                cas => cas.PersonneIdPersonnePersonne,
                                personne => personne.IdPersonnePersonne,
                                (cas, personne) => new {cas, personne})
                            .Where(item => ((item.personne.AgePersonne >= input.casPersonneQuery.age[0])&&(item.personne.AgePersonne <= input.casPersonneQuery.age[1])))
                            .Select(item => item.cas);
            //Date Vaccin 1
            results = results.Join(context.Personnes,
                                cas => cas.PersonneIdPersonnePersonne,
                                personne => personne.IdPersonnePersonne,
                                (cas, personne) => new {cas, personne})
                            .Where(item => ((item.personne.DateVaccin1Personne >= input.casPersonneQuery.vaccinDate1[0])&&(item.personne.DateVaccin1Personne <= input.casPersonneQuery.vaccinDate1[1])))
                            .Select(item => item.cas);
            //Date Vaccin 2
            results = results.Join(context.Personnes,
                                cas => cas.PersonneIdPersonnePersonne,
                                personne => personne.IdPersonnePersonne,
                                (cas, personne) => new {cas, personne})
                            .Where(item => ((item.personne.DateVaccin2Personne >= input.casPersonneQuery.vaccinDate2[0])&&(item.personne.DateVaccin2Personne <= input.casPersonneQuery.vaccinDate2[1])))
                            .Select(item => item.cas);
            return results;
        }

        private static IQueryable<EffetSecondaire> JoinQueryEffet(IQueryable<EffetSecondaire> results, QueryFormInput input, bddcovidipediaContext context) {
            //Gender
            if (input.effetQuery.personneGender != "none") results = results.Join(context.RessentEffetSecondaires, 
                                                                          effet => effet.IdEffetEffetSecondaire,
                                                                          effetLinker => effetLinker.IdEffetEffetSecondaire,
                                                                          (effet, effetLinker) => new {effet, effetLinker})
                                                                          .Join(context.Personnes, 
                                                                          firstJoin => firstJoin.effetLinker.IdPersonnePersonne,
                                                                          personne => personne.IdPersonnePersonne,
                                                                          (firstJoin, personne) => new {firstJoin, personne})
                                                                        .Where(item => item.personne.SexePersonne.ToString().ToLower() == input.effetQuery.personneGender)
                                                                        .Select(item => item.firstJoin.effet); //TODO: A régler, requete incorrecte
            //Nom de Vaccin
            if (input.effetQuery.vaccinNameTypeManufacturer[0] != null) results = results.Join(context.RessentEffetSecondaires, 
                                                                                                    effet => effet.IdEffetEffetSecondaire,
                                                                                                    effetLinker => effetLinker.IdEffetEffetSecondaire,
                                                                                                    (effet, effetLinker) => new {effet, effetLinker})
                                                                                                .Join(context.Personnes, 
                                                                                                    firstJoin => firstJoin.effetLinker.IdPersonnePersonne,
                                                                                                    personne => personne.IdPersonnePersonne,
                                                                                                    (firstJoin, personne) => new {firstJoin, personne})
                                                                                                .Join(context.Vaccins,
                                                                                                    secondJoin => secondJoin.personne.VaccinIdVaccinVaccin,
                                                                                                    vaccin => vaccin.IdVaccinVaccin,
                                                                                                    (secondJoin, vaccin) => new {secondJoin, vaccin})
                                                                                                .Where (item => item.vaccin.NomVaccinVaccin == input.effetQuery.vaccinNameTypeManufacturer[0])
                                                                                                .Select(item => item.secondJoin.firstJoin.effet);
            //Type de Vaccin
            if (input.effetQuery.vaccinNameTypeManufacturer[1] != null) results = results.Join(context.RessentEffetSecondaires, 
                                                                                                    effet => effet.IdEffetEffetSecondaire,
                                                                                                    effetLinker => effetLinker.IdEffetEffetSecondaire,
                                                                                                    (effet, effetLinker) => new {effet, effetLinker})
                                                                                                .Join(context.Personnes, 
                                                                                                    firstJoin => firstJoin.effetLinker.IdPersonnePersonne,
                                                                                                    personne => personne.IdPersonnePersonne,
                                                                                                    (firstJoin, personne) => new {firstJoin, personne})
                                                                                                .Join(context.Vaccins,
                                                                                                    secondJoin => secondJoin.personne.VaccinIdVaccinVaccin,
                                                                                                    vaccin => vaccin.IdVaccinVaccin,
                                                                                                    (secondJoin, vaccin) => new {secondJoin, vaccin})
                                                                                                .Where (item => item.vaccin.TypeVaccinVaccin == input.effetQuery.vaccinNameTypeManufacturer[1])
                                                                                                .Select(item => item.secondJoin.firstJoin.effet);
            //Fabricant de Vaccin
            if (input.effetQuery.vaccinNameTypeManufacturer[2] != null) results = results.Join(context.RessentEffetSecondaires, 
                                                                                                    effet => effet.IdEffetEffetSecondaire,
                                                                                                    effetLinker => effetLinker.IdEffetEffetSecondaire,
                                                                                                    (effet, effetLinker) => new {effet, effetLinker})
                                                                                                .Join(context.Personnes, 
                                                                                                    firstJoin => firstJoin.effetLinker.IdPersonnePersonne,
                                                                                                    personne => personne.IdPersonnePersonne,
                                                                                                    (firstJoin, personne) => new {firstJoin, personne})
                                                                                                .Join(context.Vaccins,
                                                                                                    secondJoin => secondJoin.personne.VaccinIdVaccinVaccin,
                                                                                                    vaccin => vaccin.IdVaccinVaccin,
                                                                                                    (secondJoin, vaccin) => new {secondJoin, vaccin})
                                                                                                .Where (item => item.vaccin.FabricantVaccin == input.effetQuery.vaccinNameTypeManufacturer[2])
                                                                                                .Select(item => item.secondJoin.firstJoin.effet);
            //Nom de Traitement
            if (input.effetQuery.traitementNameType[0] != null) results = results.Join(context.RessentEffetSecondaires, 
                                                                                                    effet => effet.IdEffetEffetSecondaire,
                                                                                                    effetLinker => effetLinker.IdEffetEffetSecondaire,
                                                                                                    (effet, effetLinker) => new {effet, effetLinker})
                                                                                                .Join(context.Cas, 
                                                                                                    firstJoin => firstJoin.effetLinker.IdPersonnePersonne,
                                                                                                    cas => cas.PersonneIdPersonnePersonne,
                                                                                                    (firstJoin, cas) => new {firstJoin, cas})
                                                                                                .Join(context.RecoitLeTraitements,
                                                                                                    secondJoin => secondJoin.cas.IdCasCas,
                                                                                                    traitementLinker => traitementLinker.IdCasCas,
                                                                                                    (secondJoin, traitementLinker) => new {secondJoin, traitementLinker})
                                                                                                .Join(context.Traitements,
                                                                                                    thirdJoin => thirdJoin.traitementLinker.IdTraitementTraitement,
                                                                                                    traitement => traitement.IdTraitementTraitement,
                                                                                                    (thirdJoin, traitement) => new {thirdJoin, traitement})
                                                                                                .Where(item => item.traitement.NomTraitementTraitement == input.effetQuery.traitementNameType[0])
                                                                                                .Select(item => item.thirdJoin.secondJoin.firstJoin.effet);
            //Type de Traitement
            if (input.effetQuery.traitementNameType[1] != null) results = results.Join(context.RessentEffetSecondaires, 
                                                                                                    effet => effet.IdEffetEffetSecondaire,
                                                                                                    effetLinker => effetLinker.IdEffetEffetSecondaire,
                                                                                                    (effet, effetLinker) => new {effet, effetLinker})
                                                                                                .Join(context.Cas, 
                                                                                                    firstJoin => firstJoin.effetLinker.IdPersonnePersonne,
                                                                                                    cas => cas.PersonneIdPersonnePersonne,
                                                                                                    (firstJoin, cas) => new {firstJoin, cas})
                                                                                                .Join(context.RecoitLeTraitements,
                                                                                                    secondJoin => secondJoin.cas.IdCasCas,
                                                                                                    traitementLinker => traitementLinker.IdCasCas,
                                                                                                    (secondJoin, traitementLinker) => new {secondJoin, traitementLinker})
                                                                                                .Join(context.Traitements,
                                                                                                    thirdJoin => thirdJoin.traitementLinker.IdTraitementTraitement,
                                                                                                    traitement => traitement.IdTraitementTraitement,
                                                                                                    (thirdJoin, traitement) => new {thirdJoin, traitement})
                                                                                                .Where(item => item.traitement.TypeTraitementTraitement == input.effetQuery.traitementNameType[1])
                                                                                                .Select(item => item.thirdJoin.secondJoin.firstJoin.effet);
            //Age
            results = results.Join(context.RessentEffetSecondaires, 
                                effet => effet.IdEffetEffetSecondaire,
                                effetLinker => effetLinker.IdEffetEffetSecondaire,
                                (effet, effetLinker) => new {effet, effetLinker})
                            .Join(context.Personnes, 
                                firstJoin => firstJoin.effetLinker.IdPersonnePersonne,
                                personne => personne.IdPersonnePersonne,
                                (firstJoin, personne) => new {firstJoin, personne})
                            .Where(item => ((item.personne.AgePersonne >= input.effetQuery.personneAge[0])&&(item.personne.AgePersonne <= input.effetQuery.personneAge[1])))
                            .Select(item => item.firstJoin.effet);
            //TODO: Effets Counts Cas
            return results;
        }
    
        private static IQueryable<HistoriqueCa> JoinQueryHistorique(IQueryable<HistoriqueCa> results, QueryFormInput input, bddcovidipediaContext context) {
            //Nom de Pathologie
            if (input.historiqueQuery.pathologieNameType[0] != null) results = results.Join(context.AyantLesPathologies,
                                                                                                historique => historique.IdCasCas,
                                                                                                pathologieLinker => pathologieLinker.IdCasCas,
                                                                                                (historique, pathologieLinker) => new {historique, pathologieLinker})
                                                                                        .Join(context.Pathologies,
                                                                                                firstJoin => firstJoin.pathologieLinker.IdPathologiePathologie,
                                                                                                pathologie => pathologie.IdPathologiePathologie,
                                                                                                (firstJoin, pathologie) => new {firstJoin, pathologie})
                                                                                        .Where(item => item.pathologie.NomPathologiePathologie == input.historiqueQuery.pathologieNameType[0])
                                                                                        .Select(item => item.firstJoin.historique);
            //Type de Pathologie
            if (input.historiqueQuery.pathologieNameType[1] != null) results = results.Join(context.AyantLesPathologies,
                                                                                                historique => historique.IdCasCas,
                                                                                                pathologieLinker => pathologieLinker.IdCasCas,
                                                                                                (historique, pathologieLinker) => new {historique, pathologieLinker})
                                                                                        .Join(context.Pathologies,
                                                                                                firstJoin => firstJoin.pathologieLinker.IdPathologiePathologie,
                                                                                                pathologie => pathologie.IdPathologiePathologie,
                                                                                                (firstJoin, pathologie) => new {firstJoin, pathologie})
                                                                                        .Where(item => item.pathologie.TypePathologiePathologie == input.historiqueQuery.pathologieNameType[1])
                                                                                        .Select(item => item.firstJoin.historique);
            //Nom de Symptome
            if (input.historiqueQuery.symptomeNameType[0] != null) results = results.Join(context.EstDiagnostiques,
                                                                                                historique => historique.IdCasCas,
                                                                                                symptomeLinker => symptomeLinker.IdCasCas,
                                                                                                (historique, symptomeLinker) => new {historique, symptomeLinker})
                                                                                        .Join(context.Symptomes,
                                                                                                firstJoin => firstJoin.symptomeLinker.IdSymptomeSymptome,
                                                                                                symptome => symptome.IdSymptomeSymptome,
                                                                                                (firstJoin, symptome) => new {firstJoin, symptome})
                                                                                        .Where(item => item.symptome.NomSymptomeSymptome == input.historiqueQuery.symptomeNameType[0])
                                                                                        .Select(item => item.firstJoin.historique);
            //Type de Symptome
            if (input.historiqueQuery.symptomeNameType[1] != null) results = results.Join(context.EstDiagnostiques,
                                                                                                historique => historique.IdCasCas,
                                                                                                symptomeLinker => symptomeLinker.IdCasCas,
                                                                                                (historique, symptomeLinker) => new {historique, symptomeLinker})
                                                                                        .Join(context.Symptomes,
                                                                                                firstJoin => firstJoin.symptomeLinker.IdSymptomeSymptome,
                                                                                                symptome => symptome.IdSymptomeSymptome,
                                                                                                (firstJoin, symptome) => new {firstJoin, symptome})
                                                                                        .Where(item => item.symptome.TypeSymptomeSymptome == input.historiqueQuery.symptomeNameType[1])
                                                                                        .Select(item => item.firstJoin.historique);
            //Nom de Traitement
            if (input.historiqueQuery.traitementNameType[0] != null) results = results.Join(context.RecoitLeTraitements,
                                                                                                historique => historique.IdCasCas,
                                                                                                traitementLinker => traitementLinker.IdCasCas,
                                                                                                (historique, traitementLinker) => new {historique, traitementLinker})
                                                                                        .Join(context.Traitements,
                                                                                                firstJoin => firstJoin.traitementLinker.IdTraitementTraitement,
                                                                                                traitement => traitement.IdTraitementTraitement,
                                                                                                (firstJoin, traitement) => new {firstJoin, traitement})
                                                                                        .Where(item => item.traitement.NomTraitementTraitement == input.historiqueQuery.traitementNameType[0])
                                                                                        .Select(item => item.firstJoin.historique);
            //Type de Traitement
            if (input.historiqueQuery.traitementNameType[1] != null) results = results.Join(context.RecoitLeTraitements,
                                                                                                historique => historique.IdCasCas,
                                                                                                traitementLinker => traitementLinker.IdCasCas,
                                                                                                (historique, traitementLinker) => new {historique, traitementLinker})
                                                                                        .Join(context.Traitements,
                                                                                                firstJoin => firstJoin.traitementLinker.IdTraitementTraitement,
                                                                                                traitement => traitement.IdTraitementTraitement,
                                                                                                (firstJoin, traitement) => new {firstJoin, traitement})
                                                                                        .Where(item => item.traitement.TypeTraitementTraitement == input.historiqueQuery.traitementNameType[1])
                                                                                        .Select(item => item.firstJoin.historique);
            return results;
        }

        private static IQueryable<Pathologie> JoinQueryPathologie(IQueryable<Pathologie> results, QueryFormInput input, bddcovidipediaContext context) {
            //TODO: Pathologie Counts Cas
            return results;
        }
    
        private static IQueryable<Personne> JoinQueryPersonne(IQueryable<Personne> results, QueryFormInput input, bddcovidipediaContext context) {
            //Region
            if (input.casPersonneQuery.region != null) results = results.Join(context.Localisations,
                                                                                personne => personne.IdLocalisationLocalisation,
                                                                                localisation => localisation.IdLocalisationLocalisation,
                                                                                (personne, localisation) => new {personne, localisation})
                                                                        .Where(item => item.localisation.RegionLocalisation == input.casPersonneQuery.region)
                                                                        .Select(item => item.personne);
            //Departement
            if (input.casPersonneQuery.department != 0) results = results.Join(context.Localisations,
                                                                                personne => personne.IdLocalisationLocalisation,
                                                                                localisation => localisation.IdLocalisationLocalisation,
                                                                                (personne, localisation) => new {personne, localisation})
                                                                        .Where(item => item.localisation.DepartementLocalisation == input.casPersonneQuery.department)
                                                                        .Select(item => item.personne);
            //Ville
            if (input.casPersonneQuery.city != null) results = results.Join(context.Localisations,
                                                                                personne => personne.IdLocalisationLocalisation,
                                                                                localisation => localisation.IdLocalisationLocalisation,
                                                                                (personne, localisation) => new {personne, localisation})
                                                                    .Where(item => item.localisation.VilleLocalisation == input.casPersonneQuery.city)
                                                                    .Select(item => item.personne);
            //Hopital
            if (input.casPersonneQuery.hopitalName != null) results = results.Join(context.Cas, 
                                                                                    personne => personne.IdPersonnePersonne,
                                                                                    cas => cas.PersonneIdPersonnePersonne,
                                                                                    (personne, cas) => new {personne, cas})
                                                                    .Join(context.Hopitals, 
                                                                            firstJoin => firstJoin.cas.HopitalIdHopitalHopital,
                                                                            hopital => hopital.IdHopitalHopital,
                                                                            (firstJoin, hopital) => new {firstJoin, hopital})
                                                                    .Where(item => item.hopital.NomHopital == input.casPersonneQuery.hopitalName)
                                                                    .Select(item => item.firstJoin.personne);
            //Etat de la personne
            if (input.casPersonneQuery.currentState != null) results = results.Join(context.Cas, 
                                                                                        personne => personne.IdPersonnePersonne,
                                                                                        cas => cas.PersonneIdPersonnePersonne,
                                                                                        (personne, cas) => new {personne, cas})
                                                                        .Where(item => item.cas.EtatActuelCas == input.casPersonneQuery.currentState)
                                                                        .Select(item => item.personne);
            //Souche du virus
            if (input.casPersonneQuery.virusStrain != null) results = results.Join(context.Cas, 
                                                                                    personne => personne.IdPersonnePersonne,
                                                                                    cas => cas.PersonneIdPersonnePersonne,
                                                                                    (personne, cas) => new {personne, cas})
                                                                        .Join(context.HistoriqueCas, 
                                                                                firstJoin => firstJoin.cas.IdCasCas,
                                                                                historique => historique.IdCasCas,
                                                                                (firstJoin, historique) => new {firstJoin, historique})
                                                                        .Where(item => item.historique.SoucheVirusHistoriqueCas == input.casPersonneQuery.virusStrain)
                                                                        .Select(item => item.firstJoin.personne);
            //Nom du vaccin
            if (input.casPersonneQuery.vaccinNameTypeManufacturer[0] != null) results = results.Join(context.Vaccins,
                                                                                                        personne => personne.VaccinIdVaccinVaccin,
                                                                                                        vaccin => vaccin.IdVaccinVaccin,
                                                                                                        (personne, vaccin) => new {personne, vaccin})
                                                                                                .Where(item => item.vaccin.NomVaccinVaccin == input.vaccinQuery.vaccinTypeManufacturer[0])
                                                                                                .Select(item => item.personne);
            //Type du vaccin
            if (input.casPersonneQuery.vaccinNameTypeManufacturer[1] != null) results = results.Join(context.Vaccins,
                                                                                                        personne => personne.VaccinIdVaccinVaccin,
                                                                                                        vaccin => vaccin.IdVaccinVaccin,
                                                                                                        (personne, vaccin) => new {personne, vaccin})
                                                                                                .Where(item => item.vaccin.TypeVaccinVaccin == input.vaccinQuery.vaccinTypeManufacturer[1])
                                                                                                .Select(item => item.personne);
            //Fabricant du vaccin
            if (input.casPersonneQuery.vaccinNameTypeManufacturer[2] != null) results = results.Join(context.Vaccins,
                                                                                                        personne => personne.VaccinIdVaccinVaccin,
                                                                                                        vaccin => vaccin.IdVaccinVaccin,
                                                                                                        (personne, vaccin) => new {personne, vaccin})
                                                                                                .Where(item => item.vaccin.FabricantVaccin == input.vaccinQuery.vaccinTypeManufacturer[2])
                                                                                                .Select(item => item.personne);
            //Nom d'effet secondaire
            if (input.casPersonneQuery.effetNameType[0] != null) results = results.Join(context.RessentEffetSecondaires,
                                                                                        personne => personne.IdPersonnePersonne,
                                                                                        effetLinker => effetLinker.IdPersonnePersonne,
                                                                                        (personne, effetLinker) => new {personne, effetLinker})
                                                                                .Join(context.EffetSecondaires,
                                                                                        firstJoin => firstJoin.effetLinker.IdEffetEffetSecondaire,
                                                                                        effet => effet.IdEffetEffetSecondaire,
                                                                                        (firstJoin, effet) => new {firstJoin, effet})
                                                                                .Where(item => item.effet.NomEffetEffetSecondaire == input.casPersonneQuery.effetNameType[0])
                                                                                .Select(item => item.firstJoin.personne);
            //Type d'effet secondaire
            if (input.casPersonneQuery.effetNameType[1] != null) results = results.Join(context.RessentEffetSecondaires,
                                                                                        personne => personne.IdPersonnePersonne,
                                                                                        effetLinker => effetLinker.IdPersonnePersonne,
                                                                                        (personne, effetLinker) => new {personne, effetLinker})
                                                                                .Join(context.EffetSecondaires,
                                                                                        firstJoin => firstJoin.effetLinker.IdEffetEffetSecondaire,
                                                                                        effet => effet.IdEffetEffetSecondaire,
                                                                                        (firstJoin, effet) => new {firstJoin, effet})
                                                                                .Where(item => item.effet.TypeEffetEffetSecondaire == input.casPersonneQuery.effetNameType[1])
                                                                                .Select(item => item.firstJoin.personne);
            //Nom de Pathologie
            if (input.casPersonneQuery.pathologieNameType[0] != null) results = results.Join(context.Cas, 
                                                                                                personne => personne.IdPersonnePersonne,
                                                                                                cas => cas.PersonneIdPersonnePersonne,
                                                                                                (personne, cas) => new {personne, cas})
                                                                                        .Join(context.AyantLesPathologies,
                                                                                                firstJoin => firstJoin.cas.IdCasCas,
                                                                                                pathologieLinker => pathologieLinker.IdCasCas,
                                                                                                (firstJoin, pathologieLinker) => new {firstJoin, pathologieLinker})
                                                                                        .Join(context.Pathologies,
                                                                                                secondJoin => secondJoin.pathologieLinker.IdPathologiePathologie,
                                                                                                pathologie => pathologie.IdPathologiePathologie,
                                                                                                (secondJoin, pathologie) => new {secondJoin, pathologie})
                                                                                        .Where(item => item.pathologie.NomPathologiePathologie == input.casPersonneQuery.pathologieNameType[0])
                                                                                        .Select(item => item.secondJoin.firstJoin.personne);
            //Type de Pathologie
            if (input.casPersonneQuery.pathologieNameType[1] != null) results = results.Join(context.Cas, 
                                                                                                personne => personne.IdPersonnePersonne,
                                                                                                cas => cas.PersonneIdPersonnePersonne,
                                                                                                (personne, cas) => new {personne, cas})
                                                                                        .Join(context.AyantLesPathologies,
                                                                                                firstJoin => firstJoin.cas.IdCasCas,
                                                                                                pathologieLinker => pathologieLinker.IdCasCas,
                                                                                                (firstJoin, pathologieLinker) => new {firstJoin, pathologieLinker})
                                                                                        .Join(context.Pathologies,
                                                                                                secondJoin => secondJoin.pathologieLinker.IdPathologiePathologie,
                                                                                                pathologie => pathologie.IdPathologiePathologie,
                                                                                                (secondJoin, pathologie) => new {secondJoin, pathologie})
                                                                                        .Where(item => item.pathologie.TypePathologiePathologie == input.casPersonneQuery.pathologieNameType[1])
                                                                                        .Select(item => item.secondJoin.firstJoin.personne);
            //Nom de Symptome
            if (input.casPersonneQuery.symptomeNameType[0] != null) results = results.Join(context.Cas, 
                                                                                                personne => personne.IdPersonnePersonne,
                                                                                                cas => cas.PersonneIdPersonnePersonne,
                                                                                                (personne, cas) => new {personne, cas})
                                                                                        .Join(context.EstDiagnostiques,
                                                                                                firstJoin => firstJoin.cas.IdCasCas,
                                                                                                symptomeLinker => symptomeLinker.IdCasCas,
                                                                                                (firstJoin, symptomeLinker) => new {firstJoin, symptomeLinker})
                                                                                        .Join(context.Symptomes,
                                                                                                secondJoin => secondJoin.symptomeLinker.IdSymptomeSymptome,
                                                                                                symptome => symptome.IdSymptomeSymptome,
                                                                                                (secondJoin, symptome) => new {secondJoin, symptome})
                                                                                        .Where(item => item.symptome.NomSymptomeSymptome == input.casPersonneQuery.symptomeNameType[0])
                                                                                        .Select(item => item.secondJoin.firstJoin.personne);
            //Type de Symptome
            if (input.casPersonneQuery.symptomeNameType[1] != null) results = results.Join(context.Cas, 
                                                                                                personne => personne.IdPersonnePersonne,
                                                                                                cas => cas.PersonneIdPersonnePersonne,
                                                                                                (personne, cas) => new {personne, cas})
                                                                                        .Join(context.EstDiagnostiques,
                                                                                                firstJoin => firstJoin.cas.IdCasCas,
                                                                                                symptomeLinker => symptomeLinker.IdCasCas,
                                                                                                (firstJoin, symptomeLinker) => new {firstJoin, symptomeLinker})
                                                                                        .Join(context.Symptomes,
                                                                                                secondJoin => secondJoin.symptomeLinker.IdSymptomeSymptome,
                                                                                                symptome => symptome.IdSymptomeSymptome,
                                                                                                (secondJoin, symptome) => new {secondJoin, symptome})
                                                                                        .Where(item => item.symptome.TypeSymptomeSymptome == input.casPersonneQuery.symptomeNameType[1])
                                                                                        .Select(item => item.secondJoin.firstJoin.personne);
            //Nom de Traitement
            if (input.casPersonneQuery.traitementNameType[0] != null) results = results.Join(context.Cas, 
                                                                                                personne => personne.IdPersonnePersonne,
                                                                                                cas => cas.PersonneIdPersonnePersonne,
                                                                                                (personne, cas) => new {personne, cas})
                                                                                        .Join(context.RecoitLeTraitements,
                                                                                                firstJoin => firstJoin.cas.IdCasCas,
                                                                                                traitementLinker => traitementLinker.IdCasCas,
                                                                                                (firstJoin, traitementLinker) => new {firstJoin, traitementLinker})
                                                                                        .Join(context.Traitements,
                                                                                                secondJoin => secondJoin.traitementLinker.IdTraitementTraitement,
                                                                                                traitement => traitement.IdTraitementTraitement,
                                                                                                (secondJoin, traitement) => new {secondJoin, traitement})
                                                                                        .Where(item => item.traitement.NomTraitementTraitement == input.casPersonneQuery.traitementNameType[0])
                                                                                        .Select(item => item.secondJoin.firstJoin.personne);
            //Type de Traitement
            if (input.casPersonneQuery.traitementNameType[1] != null) results = results.Join(context.Cas, 
                                                                                                personne => personne.IdPersonnePersonne,
                                                                                                cas => cas.PersonneIdPersonnePersonne,
                                                                                                (personne, cas) => new {personne, cas})
                                                                                        .Join(context.RecoitLeTraitements,
                                                                                                firstJoin => firstJoin.cas.IdCasCas,
                                                                                                traitementLinker => traitementLinker.IdCasCas,
                                                                                                (firstJoin, traitementLinker) => new {firstJoin, traitementLinker})
                                                                                        .Join(context.Traitements,
                                                                                                secondJoin => secondJoin.traitementLinker.IdTraitementTraitement,
                                                                                                traitement => traitement.IdTraitementTraitement,
                                                                                                (secondJoin, traitement) => new {secondJoin, traitement})
                                                                                        .Where(item => item.traitement.TypeTraitementTraitement == input.casPersonneQuery.traitementNameType[1])
                                                                                        .Select(item => item.secondJoin.firstJoin.personne);
            return results;
        }

        private static IQueryable<Symptome> JoinQuerySymptome(IQueryable<Symptome> results, QueryFormInput input, bddcovidipediaContext context) {
            //TODO: Symptome Counts Cas
            return results;
        }
    
        private static IQueryable<Traitement> JoinQueryTraitement(IQueryable<Traitement> results, QueryFormInput input, bddcovidipediaContext context) {
            //TODO: Traitement Counts Cas
            return results;
        }

        private static IQueryable<Vaccin> JoinQueryVaccin(IQueryable<Vaccin> results, QueryFormInput input, bddcovidipediaContext context) {
            //Nom d'Effet Secondaire
            if (input.vaccinQuery.effetNameType[0] != null) results =results.Join(context.Personnes,
                                                                                    vaccin => vaccin.IdVaccinVaccin,
                                                                                    personne => personne.VaccinIdVaccinVaccin,
                                                                                    (vaccin, personne) => new {vaccin, personne})
                                                                            .Join(context.RessentEffetSecondaires,
                                                                                    firstJoin => firstJoin.personne.IdPersonnePersonne,
                                                                                    effetLinker => effetLinker.IdPersonnePersonne,
                                                                                    (firstJoin, effetLinker) => new {firstJoin, effetLinker})
                                                                            .Join(context.EffetSecondaires,
                                                                                    secondJoin => secondJoin.effetLinker.IdEffetEffetSecondaire,
                                                                                    effet => effet.IdEffetEffetSecondaire,
                                                                                    (secondJoin, effet) => new {secondJoin, effet})
                                                                            .Where(item => item.effet.NomEffetEffetSecondaire == input.vaccinQuery.effetNameType[0])
                                                                            .Select(item => item.secondJoin.firstJoin.vaccin);
            //Type d'Effet Secondaire
            if (input.vaccinQuery.effetNameType[1] != null) results =results.Join(context.Personnes,
                                                                                    vaccin => vaccin.IdVaccinVaccin,
                                                                                    personne => personne.VaccinIdVaccinVaccin,
                                                                                    (vaccin, personne) => new {vaccin, personne})
                                                                            .Join(context.RessentEffetSecondaires,
                                                                                    firstJoin => firstJoin.personne.IdPersonnePersonne,
                                                                                    effetLinker => effetLinker.IdPersonnePersonne,
                                                                                    (firstJoin, effetLinker) => new {firstJoin, effetLinker})
                                                                            .Join(context.EffetSecondaires,
                                                                                    secondJoin => secondJoin.effetLinker.IdEffetEffetSecondaire,
                                                                                    effet => effet.IdEffetEffetSecondaire,
                                                                                    (secondJoin, effet) => new {secondJoin, effet})
                                                                            .Where(item => item.effet.TypeEffetEffetSecondaire == input.vaccinQuery.effetNameType[1])
                                                                            .Select(item => item.secondJoin.firstJoin.vaccin);
            //TODO: Vaccin Counts Cas
            return results;
        }
    
        private static IQueryable<Localisation> JoinQueryLocalisation(IQueryable<Localisation> results, QueryFormInput input, bddcovidipediaContext context) {
            //TODO: Localisation Counts Cas
            return results;
        }
    }
}