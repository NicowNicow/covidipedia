using System.IO;
using System;
using Newtonsoft.Json;
using System.Linq;
using System.Collections;
using System.Data;
using System.Collections.Generic;

namespace covidipedia.front.chart
{
    public class ChartPrinter
    {

        public ChartJs Chart { get; set; }
        public string ChartJson { get; set; }

        public string ChartJson2 { get; set; }

        public ChartPrinter() { 
            //TODO: Besoin d'un moyen de recharger les données tout les jours, là c'est instancié une unique fois au lancement du serveur
            //TODO: Chart avec requetes correctes
            //TODO: meilleur affichage des charts
            int offsetDays= -10;
            DateTime dateTime = DateTime.Now;
            this.CountNumberPersonDateVaccin1(offsetDays, dateTime);
            //this.CountNumberProgressPersonDateVaccin2();
            this.CountNumberCas(offsetDays,dateTime);
        }

        public void CountNumberPersonDateVaccin1(int offsetDays, DateTime dateTime)
        {
            using (var _context = new bddcovidipediaContext())
            {
                Chart = new ChartJs();
                Chart.data = new Data();
                List<Personne> personnes = new List<Personne>();
                var test = _context.Personnes.Where(date => date.DateVaccin1Personne <= dateTime && date.DateVaccin1Personne >= dateTime.AddDays(offsetDays)).GroupBy(x => x.DateVaccin1Personne.Value.Date).OrderBy(z => z.Key).Select(y => new { name = y.Key, count = y.Count() }).ToArray();
                var date = test.Select(x => x.name).ToArray();
                var count = test.Select(x => x.count).ToArray();
                List<string> DateString = new List<string>();
                foreach (var datee in date)
                {
                    DateString.Add(datee.ToString());
                }
                var dateString = DateString.ToArray();
                Chart = ChartJsCreatorBar(count, dateString, "Vaccination sur les 10 derniers jours", "bar", "rgba(0,0,0,1)", "rgba(0,0,0,1)");
                ChartJson = JsonConvert.SerializeObject(Chart, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            }
        }

        public void CountNumberCas(int offsetDays, DateTime dateTime)
        {
            using(var _context = new bddcovidipediaContext())
            {
                Chart = new ChartJs();
                Chart.data = new Data();
                List<HistoriqueCa> cas = new List<HistoriqueCa>();
                var cass = _context.HistoriqueCas.Where(y => y.DateDetectionHistoriqueCas <= dateTime && y.DateDetectionHistoriqueCas >= dateTime.AddDays(offsetDays)).GroupBy(x => x.DateDetectionHistoriqueCas).OrderBy( z=> z.Key).Select(y => new { name = y.Key, count = y.Count() }).ToArray();
                var date = cass.Select(x => x.name).ToArray();
                var count = cass.Select(x => x.count).ToArray();
                List<string> DateString = new List<string>();
                foreach (var datee in date)
                {
                    DateString.Add(datee.ToString());
                }
                var dateString = DateString.ToArray();
                Chart = ChartJsCreatorBar(count, dateString, "Nouveaux Cas sur les 10 derniers jours", "line", "rgba(0,0,0,1)", "rgba(0,0,0,1)");
                ChartJson2 = JsonConvert.SerializeObject(Chart, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            }
        }

        public void CountNumberProgressPersonDateVaccin2()
        {
            using (var _context = new bddcovidipediaContext())
            {
                Chart = new ChartJs();
                Chart.data = new Data();
                List<Personne> personnes = new List<Personne>();
                DateTime dateTime = new DateTime(2019, 08, 01);
                var test = _context.Personnes.Where(date => date.DateVaccin2Personne < dateTime).GroupBy(x => x.DateVaccin2Personne.Value.Date).OrderBy(z => z.Key).Select(y => new { name = y.Key, count = y.Count() }).ToArray();
                var date = test.Select(x => x.name).ToArray();
                var count = test.Select(x => x.count).ToArray();
                for (int i = 1; i < count.Count(); i++)
                {
                    count[i] = count[i - 1] + count[i];
                }
                List<string> DateString = new List<string>();
                foreach (var datee in date)
                {
                    DateString.Add(datee.ToString());
                }
                var dateString = DateString.ToArray();
                Chart = ChartJsCreatorBar(count, dateString, "Vacccccccccccination 2", "line", "rgba(0,0,0,0)", "rgba(0,0,0,1)");
                ChartJson2 = JsonConvert.SerializeObject(Chart, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            }
        }

        public ChartJs ChartJsCreatorBar(int[] data, string[] label, string labelName, string type , string backgroundColor, string borderColor)
        {
            ChartJs chart = new ChartJs();
            chart.data = new Data();
            var numberElement = label.Count();
            var backgroundColorTab = new string[numberElement];
            for (int i = 0; i < numberElement; i++)
            {
                backgroundColorTab[i] = backgroundColor;
            }
            var backgroundColorTab2 = new string[numberElement];
            for (int i = 0; i < numberElement; i++)
            {
                backgroundColorTab2[i] = borderColor;
            }
            chart.data.labels = new string[numberElement];
            chart.data.labels = label;
            List<Dataset> CountInt = new List<Dataset>();
            Dataset dataSetCreate = new Dataset()
            {
                label = labelName,
                data = data,
                backgroundColor = backgroundColorTab,
                borderColor = backgroundColorTab2,
                borderWidth = 1
            };
            CountInt.Add(dataSetCreate);
            List<yAxes> yAxes = new List<yAxes>();
            Ticks ticksunique = new Ticks();
            ticksunique.beginAtZero = true;
            yAxes yaxesUnique = new yAxes()
            {
                ticks = ticksunique
            };
            yAxes.Add(yaxesUnique);
            chart.data.datasets = CountInt.ToArray();
            chart.options = new Options();
            chart.options.scales = new Scales();
            chart.options.scales.yAxes = yAxes.ToArray();
            chart.responsive = true;
            chart.type = type;
            return chart;
        }
    }
}