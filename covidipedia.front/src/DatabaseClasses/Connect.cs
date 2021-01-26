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
                foreach (var x in context.AyantLesPathologies)
                    ayantLesPathologies.Add(x);
            }
            return ayantLesPathologies;
        }

        public List<Ca> recupCa()
        {
            List<Ca> cas = new List<Ca>();
            using (var context = new bddcovidipediaContext())
            {
                foreach (var x in context.Cas)
                    cas.Add(x);
            }
            return cas;
        }

        public List<EffetSecondaire> recupEffetSecondaire()
        {
            List<EffetSecondaire> effetSecondaires = new List<EffetSecondaire>();
            using (var context = new bddcovidipediaContext())
            {
                foreach (var x in context.EffetSecondaires)
                    effetSecondaires.Add(x);
            }
            return effetSecondaires;
        }

        public List<EstDiagnostique> recupEstDiag()
        {
            List<EstDiagnostique> estDiagnostiques = new List<EstDiagnostique>();
            using (var context = new bddcovidipediaContext())
            {
                foreach (var x in context.EstDiagnostiques)
                    estDiagnostiques.Add(x);
            }
            return estDiagnostiques;
        }

        public List<HistoriqueCa> recupHistoriqueCas()
        {
            List<HistoriqueCa> historiqueCas = new List<HistoriqueCa>();
            using (var context = new bddcovidipediaContext())
            {
                foreach (var x in context.HistoriqueCas)
                    historiqueCas.Add(x);
            }
            return historiqueCas;
        }

        public List<Hopital> recupHopital()
        {
            List<Hopital> hopitals = new List<Hopital>();
            using (var context = new bddcovidipediaContext())
            {
                foreach (var x in context.Hopitals)
                    hopitals.Add(x);
            }
            return hopitals;
        }
        public List<Localisation> recupLocalisation()
        {
            List<Localisation> localisations = new List<Localisation>();
            using (var context = new bddcovidipediaContext())
            {
                foreach (var x in context.Localisations)
                    localisations.Add(x);
            }
            return localisations;
        }
        public List<Pathologie> recupPathologie()
        {
            List<Pathologie> Pathologie = new List<Pathologie>();
            using (var context = new bddcovidipediaContext())
            {
                foreach (var x in context.Pathologies)
                    Pathologie.Add(x);
            }
            return Pathologie;
        }
        public List<Personne> recupPersonne()
        {
            List<Personne> Personne = new List<Personne>();
            using (var context = new bddcovidipediaContext())
            {
                foreach (var x in context.Personnes)
                    Personne.Add(x);
            }
            return Personne;
        }
        public List<RecoitLeTraitement> recupRecoitLeTraitement()
        {
            List<RecoitLeTraitement> RecoitLeTraitement = new List<RecoitLeTraitement>();
            using (var context = new bddcovidipediaContext())
            {
                foreach (var x in context.RecoitLeTraitements)
                    RecoitLeTraitement.Add(x);
            }
            return RecoitLeTraitement;
        }
        public List<RessentEffetSecondaire> recupRessentEffetSecondaire()
        {
            List<RessentEffetSecondaire> RessentEffetSecondaire = new List<RessentEffetSecondaire>();
            using (var context = new bddcovidipediaContext())
            {
                foreach (var x in context.RessentEffetSecondaires)
                    RessentEffetSecondaire.Add(x);
            }
            return RessentEffetSecondaire;
        }
        public List<Symptome> recupSymptome()
        {
            List<Symptome> Symptome = new List<Symptome>();
            using (var context = new bddcovidipediaContext())
            {
                foreach (var x in context.Symptomes)
                    Symptome.Add(x);
            }
            return Symptome;
        }

        public List<Traitement> recupTraitement()
        {
            List<Traitement> Traitement = new List<Traitement>();
            using (var context = new bddcovidipediaContext())
            {
                foreach (var x in context.Traitements)
                    Traitement.Add(x);
            }
            return Traitement;
        }
        public List<Vaccin> recupVaccin()
        {
            List<Vaccin> Vaccin = new List<Vaccin>();
            using (var context = new bddcovidipediaContext())
            {
                foreach (var x in context.Vaccins)
                    Vaccin.Add(x);
            }
            return Vaccin;
        }
    }
}