using System.Collections.Generic;
using System.Linq;
namespace covidipedia.front
{
    public class Connect
    {
        public Connect()
        {

        }
        public List<AyantLesPathology> recupAyantPatho()
        {
            List<AyantLesPathology> ayantLesPathologies = new List<AyantLesPathology>();
            using (var context = new bddcovidipediaContext())
            {
                ayantLesPathologies= context.AyantLesPathologies.ToList();
            }
            return ayantLesPathologies;
        }

        public List<Ca> recupCa()
        {
            List<Ca> cas = new List<Ca>();
            using (var context = new bddcovidipediaContext())
            {
                cas=context.Cas.ToList();
            }
            return cas;
        }

        public List<EffetSecondaire> recupEffetSecondaire()
        {
            List<EffetSecondaire> effetSecondaires = new List<EffetSecondaire>();
            using (var context = new bddcovidipediaContext())
            {
                effetSecondaires=context.EffetSecondaires.ToList();
            }
            return effetSecondaires;
        }

        public List<EstDiagnostique> recupEstDiag()
        {
            List<EstDiagnostique> estDiagnostiques = new List<EstDiagnostique>();
            using (var context = new bddcovidipediaContext())
            {
                estDiagnostiques=context.EstDiagnostiques.ToList();
            }
            return estDiagnostiques;
        }

        public List<HistoriqueCa> recupHistoriqueCas()
        {
            List<HistoriqueCa> historiqueCas = new List<HistoriqueCa>();
            using (var context = new bddcovidipediaContext())
            {
                historiqueCas=context.HistoriqueCas.ToList();
            }
            return historiqueCas;
        }

        public List<Hopital> recupHopital()
        {
            List<Hopital> hopitals = new List<Hopital>();
            using (var context = new bddcovidipediaContext())
            {
                hopitals=context.Hopitals.ToList();
            }
            return hopitals;
        }
        public List<Localisation> recupLocalisation()
        {
            List<Localisation> localisations = new List<Localisation>();
            using (var context = new bddcovidipediaContext())
            {
                localisations=context.Localisations.ToList();
            }
            return localisations;
        }
        public List<Pathologie> recupPathologie()
        {
            List<Pathologie> pathologies = new List<Pathologie>();
            using (var context = new bddcovidipediaContext())
            {
                pathologies=context.Pathologies.ToList();
            }
            return pathologies;
        }
        public List<Personne> recupPersonne()
        {
            List<Personne> personnes = new List<Personne>();
            using (var context = new bddcovidipediaContext())
            {
                personnes=context.Personnes.ToList();
            }
            return personnes;
        }
        public List<RecoitLeTraitement> recupRecoitLeTraitement()
        {
            List<RecoitLeTraitement> recoitLeTraitements = new List<RecoitLeTraitement>();
            using (var context = new bddcovidipediaContext())
            {
                recoitLeTraitements=context.RecoitLeTraitements.ToList();
            }
            return recoitLeTraitements;
        }
        public List<RessentEffetSecondaire> recupRessentEffetSecondaire()
        {
            List<RessentEffetSecondaire> ressentEffetSecondaires = new List<RessentEffetSecondaire>();
            using (var context = new bddcovidipediaContext())
            {
                ressentEffetSecondaires=context.RessentEffetSecondaires.ToList();
            }
            return ressentEffetSecondaires;
        }
        public List<Symptome> recupSymptome()
        {
            List<Symptome> symptomes = new List<Symptome>();
            using (var context = new bddcovidipediaContext())
            {
                symptomes=context.Symptomes.ToList();
            }
            return symptomes;
        }

        public List<Traitement> recupTraitement()
        {
            List<Traitement> traitements = new List<Traitement>();
            using (var context = new bddcovidipediaContext())
            {
                traitements=context.Traitements.ToList();
            }
            return traitements;
        }
        public List<Vaccin> recupVaccin()
        {
            List<Vaccin> vaccins = new List<Vaccin>();
            using (var context = new bddcovidipediaContext())
            {
                vaccins=context.Vaccins.ToList();
            }
            return vaccins;
        }
    }
}