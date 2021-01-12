using System.Collections.Generic;
using System;
namespace covidipedia.front
{
    public class Connect
    {
        public List<Cas> recupCas()
        {
            List<Cas> cas = new List<Cas>();
            using (var context = new AppDatabase())
            {
                foreach (var x in context.Cas)
                {
                    cas.Add(x);
                }
            }
            return cas;
        }
        public List<A_pathologie> recupAPathologie()
        {
            List<A_pathologie> a_Pathologies = new List<A_pathologie>();
            using (var context = new AppDatabase())
            {
                foreach (var x in context.A_pathologie)
                {
                    a_Pathologies.Add(x);
                }
            }
            return a_Pathologies;
        }

        public List<Effets_secondaires> recupEffet()
        {
            List<Effets_secondaires> effets = new List<Effets_secondaires>();
            using (var context = new AppDatabase())
            {
                foreach (var x in context.Effets_Secondaires)
                {
                    effets.Add(x);
                }
            }
            return effets;
        }

        public List<Est_diagnostique> recupDiag()
        {
            List<Est_diagnostique> estDiag = new List<Est_diagnostique>();
            using (var context = new AppDatabase())
            {
                foreach (var x in context.Est_diagnostique)
                {
                    estDiag.Add(x);
                }
            }
            return estDiag;
        }
         public List<Hopital> recupHopital()
        {
            List<Hopital> hopitals = new List<Hopital>();
            using (var context = new AppDatabase())
            {
                foreach (var x in context.Hopital)
                {
                    hopitals.Add(x);
                }
            }
            return hopitals;
        }
        public List<Localisation> recupLocalisation()
        {
            List<Localisation> localisations = new List<Localisation>();
            using (var context = new AppDatabase())
            {
                foreach (var x in context.Localisation)
                {
                    localisations.Add(x);
                }
            }
            return localisations;
        }

        public List<Pathologie> recupPathologie()
        {
            List<Pathologie> pathologies = new List<Pathologie>();
            using (var context = new AppDatabase())
            {
                foreach (var x in context.Pathologie)
                {
                    pathologies.Add(x);
                }
            }
            return pathologies;
        }
        public List<Personne> recupPersonne()
        {
            List<Personne> personnes = new List<Personne>();
            using (var context = new AppDatabase())
            {
                foreach (var x in context.Personne)
                {
                    personnes.Add(x);
                }
            }
            return personnes;
        }

        public List<Ressent_effets_secondaires> recupRessentEffets()
        {
            List<Ressent_effets_secondaires> ressent_Effets = new List<Ressent_effets_secondaires>();
            using (var context = new AppDatabase())
            {
                foreach (var x in context.Ressent_effets_secondaires)
                {
                    ressent_Effets.Add(x);
                }
            }
            return ressent_Effets;
        }

        public List<Symptomes> recupSymptomes()
        {
            List<Symptomes> symptomes = new List<Symptomes>();
            using (var context = new AppDatabase())
            {
                foreach (var x in context.Symptomes)
                {
                    symptomes.Add(x);
                }
            }
            return symptomes;
        }

        public List<Vaccin> recupVaccin()
        {
            List<Vaccin> vaccins = new List<Vaccin>();
            using (var context = new AppDatabase())
            {
                foreach (var x in context.Vaccin)
                {
                    vaccins.Add(x);
                }
            }
            return vaccins;
        }

    }
}
