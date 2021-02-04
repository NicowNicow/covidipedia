using System.Collections.Generic;
using System.Linq;

namespace covidipedia.front {

    public static class GenericQuery {

        public static List<Hopital> QueryHopital(string testName, bddcovidipediaContext context) {
            List<Hopital> results = new List<Hopital>();
            if (testName != null) {
                results = context.Hopitals
                            .Where(hopital => hopital.NomHopital == testName)
                            .ToList();
            }
            else foreach (Hopital hopital in context.Hopitals) results.Add(hopital);
            return results;
        }
    }
}