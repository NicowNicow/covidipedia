using covidipedia.front.chart;
using System.Collections;
using System.IO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Linq;
using System.Data;

namespace covidipedia.front.Pages
{
    public class IndexModel : PageModel
    {
        //Model Variables
        private readonly ILogger<IndexModel> _logger;

        public ChartPrinter chartPrinter { get; set; } = new ChartPrinter();

        public DailyNumber DailyNumber { get; set; } = new DailyNumber();

        [BindProperty]
        public QueryFormInput input { get; set; }

        public Dictionary<string,string> genderList {get; set;} = new Dictionary<string,string> { ["none"] = "Non renseigné", ["true"] = "Homme", ["false"] = "Femme"};

        public Dictionary<int,string> departmentList {get; set;} = new Dictionary<int,string> {[00] = "Aucun", [01] = "Ain", [02] = "Aisne", [03] = "Allier", [04] = "Alpes-de-Haute-Provence", [05] = "Hautes-Alpes", [06] = "Alpes-Maritimes", [07] = "Ardèche", [08] = "Ardennes", [09] = "Ariège", [10] = "Aube", [11] = "Aude", [12] = "Aveyron", [13] = "Bouches-du-Rhône", [14] = "Calvados", [15] = "Cantal", [16] = "Charente", [17] = "Charente-Maritime", [18] = "Cher", [19] = "Corrèze", [20] = "Corse", [21] = "Côte-d'Or", [22] = "Côtes d'Armor", [23] = "Creuse", [24] = "Dordogne", [25] = "Doubs", [26] = "Drôme", [27] = "Eure", [28] = "Eure-et-Loir", [29] = "Finistère", [30] = "Gard", [31] = "Haute-Garonne", [32] = "Gers", [33] = "Gironde", [34] = "Hérault", [35] = "Ille-et-Vilaine", [36] = "Indre", [37] = "Indre-et-Loire", [38] = "Isère", [39] = "Jura", [40] = "Landes", [41] = "Loir-et-Cher", [42] = "Loire", [43] = "Haute-Loire", [44] = "Loire-Atlantique", [45] = "Loiret", [46] = "Lot", [47] = "Lot-et-Garonne", [48] = "Lozère", [49] = "Maine-et-Loire", [50] = "Manche", [51] = "Marne", [52] = "Haute-Marne", [53] = "Mayenne", [54] = "Meurthe-et-Moselle", [55] = "Meuse", [56] = "Morbihan", [57] = "Moselle", [58] = "Nièvre", [59] = "Nord", [60] = "Oise", [61] = "Orne", [62] = "Pas-de-Calais", [63] = "Puy-de-Dôme", [64] = "Pyrénées-Atlantiques", [65] = "Hautes-Pyrénées", [66] = "Pyrénées-Orientales", [67] = "Bas-Rhin", [68] = "Haut-Rhin", [69] = "Rhône", [70] = "Haute-Saône", [71] = "Saône-et-Loire", [72] = "Sarthe", [73] = "Savoie", [74] = "Haute-Savoie", [75] = "Paris", [76] = "Seine-Maritime", [77] = "Seine-et-Marne", [78] = "Yvelines", [79] = "Deux-Sèvres", [80] = "Somme", [81] = "Tarn", [82] = "Tarn-et-Garonne", [83] = "Var", [84] = "Vaucluse", [85] = "Vendée", [86] = "Vienne", [87] = "Haute-Vienne", [88] = "Vosges", [89] = "Yonne", [90] = "Territoire de Belfort", [91] = "Essonne", [92] = "Hauts-de-Seine", [93] = "Seine-St-Denis", [94] = "Val-de-Marne", [95] = "Val-D'Oise", [871] = "Guadeloupe", [972] = "Martinique", [973] = "Guyane", [974] = "La Réunion", [975] = "Mayotte"};


        //Model Constructor
        public IndexModel(ILogger<IndexModel> logger) {
            _logger = logger;
            DailyNumber = initDailyNumber();
        }


        //Model Methods
        public void OnGet() {
        }

        public IActionResult OnPostSubmit() {
            if (!ModelState.IsValid) return Page();
            ArrayList results = new ArrayList();
            using (bddcovidipediaContext context = new bddcovidipediaContext()) results = GenericQuery.QuerySelector(input, input.type, context);
            TempDataStorage(results); 
            ViewDataStorage(results, input.type);
            return Page();
        }

        public async Task<IActionResult> OnPostDownloadFile() { //TODO: CSV: Add criterias
            string fileName = Path.Combine("resultsquery-" + TempData.Peek("input.type").ToString() + "-" + DateTime.Now.ToString("yyyyMMdd") + ".csv"); //Format de fileName: ./resultsquery-[TABLENAME]-[DATE].csv
            _logger.LogInformation(fileName);
            try {
                CSVWriter.TypeParser(JsonConvert.DeserializeObject<ArrayList>(HttpContext.Session.GetString("queryResults")), TempData.Peek("input.type").ToString(), fileName);
            } catch {
                _logger.LogError("Session has expired: data is no longer retrievable");
            }
            return await FileDownloader(fileName);
        }


        //Model Inner Methods
        private void TempDataStorage(ArrayList queryResults) { 
            TempData["input.type"] = input.type;
            HttpContext.Session.SetString("queryResults", JsonConvert.SerializeObject(queryResults));
        }

        private void ViewDataStorage(ArrayList queryResult, string type) {
            ViewData["ResultTableHead"] = GenericQuery.TableHeadSelector(input.type);
            ViewData["ResultTable"] = GenericQuery.TableContentSelector(queryResult, input.type, departmentList);
        }

        private async Task<IActionResult> FileDownloader(string fileName) {
            MemoryStream memory = new MemoryStream();  
            try {
                using (FileStream stream = new FileStream(fileName, FileMode.Open))  await stream.CopyToAsync(memory);
                System.IO.File.Delete(fileName);
                memory.Position = 0;  
            } catch {
                _logger.LogError($"File {fileName} not found");
            }
            return File(memory, "text/csv", fileName);
        }

        private DailyNumber initDailyNumber()
        {
            using (var _context = new bddcovidipediaContext())
            {
                DailyNumber dailyNumber = new DailyNumber();
                dailyNumber.numberCas = _context.HistoriqueCas.Where(x => x.DateDetectionHistoriqueCas == DateTime.Now.Date).Count();
                int numberCasDayBefore = _context.HistoriqueCas.Where(x => x.DateDetectionHistoriqueCas == DateTime.Now.AddDays(-1).Date).Count();
                dailyNumber.numberDead = _context.HistoriqueCas.Where(x => (x.DateDetectionHistoriqueCas == DateTime.Now.Date || x.DateMajHistoriqueCas == DateTime.Now.Date) && x.EtatCasHistoriqueCas == "Decede").Count();
                int numberDeadDaysBefore = _context.HistoriqueCas.Where(x => (x.DateDetectionHistoriqueCas == DateTime.Now.AddDays(-1).Date || x.DateMajHistoriqueCas == DateTime.Now.AddDays(-1).Date) && x.EtatCasHistoriqueCas == "Decede").Count();
                dailyNumber.numberVaccinate = _context.Personnes.Where(x => x.DateVaccin1Personne == DateTime.Now.Date || x.DateVaccin2Personne == DateTime.Now.Date).Count();
                int numberVaccinateDaysBefore = _context.Personnes.Where(x => x.DateVaccin1Personne == DateTime.Now.AddDays(-1).Date || x.DateVaccin2Personne == DateTime.Now.AddDays(-1).Date).Count();
                int totalBeds = 0;
                foreach (var hopital in _context.Hopitals)
                {
                    totalBeds += Convert.ToInt32(hopital.NombreLitsHopital)+Convert.ToInt32(hopital.NombreLitsReanimationHopital);
                }
                dailyNumber.numberBed = totalBeds - _context.Cas.Where(x => x.EtatActuelCas == "Hospitalise" || x.EtatActuelCas == "En reanimation").Count();
                int numberTotalBedsDaysBefore = totalBeds - _context.Cas.Where(x => x.EtatActuelCas == "Hospitalise" || x.EtatActuelCas == "En reanimation").Count();

                dailyNumber.percentageCas = ((dailyNumber.numberCas - numberCasDayBefore) / numberCasDayBefore) * 100;
                dailyNumber.percentageDead = ((dailyNumber.numberDead - numberDeadDaysBefore) / numberDeadDaysBefore) * 100;
                dailyNumber.percentageVaccinate = ((dailyNumber.numberVaccinate - numberVaccinateDaysBefore) / numberVaccinateDaysBefore) * 100;
                dailyNumber.percentageBed = ((dailyNumber.numberBed - numberTotalBedsDaysBefore) / numberTotalBedsDaysBefore) * 100;
                return dailyNumber;
            }
        }

    }
}
