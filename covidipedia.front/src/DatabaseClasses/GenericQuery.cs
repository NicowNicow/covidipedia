using System.Collections.Generic;
using System.Linq;

namespace covidipedia.front
{

    public static class GenericQuery
    {

        public static List<Hopital> QueryHopital(string testName, bddcovidipediaContext context)
        {
            List<Hopital> results = new List<Hopital>();
            if (testName != null)
                results = context.Hopitals.Where(hopital => hopital.NomHopital.Contains(testName)).ToList();
            else results = context.Hopitals.ToList();
            return results;
        }
    }
}