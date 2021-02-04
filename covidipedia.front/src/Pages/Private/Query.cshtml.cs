using System.Collections.Generic;
using System.Collections;
using System.IO;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace covidipedia.front.Pages
{
    public class QueryModel : PageModel {
        //Inner Classes
        public class FormInput {
            public string type { get; set; }
            public string name { get; set; }
        }


        //Model Variables
        private readonly ILogger<QueryModel> _logger;

        [BindProperty]
        public FormInput input { get; set; }


        //Model Constructor
        public QueryModel(ILogger<QueryModel> logger) {
            _logger = logger;
        }


        //Model Methods
        public void OnGet() { }

        public IActionResult OnPostSubmit() {
            if (!ModelState.IsValid) return Page();
            List<Hopital> hopitals = new List<Hopital>(); //ArrayList plutôt que List pour la query, on va pas être strongly typed ici
            using (bddcovidipediaContext context = new bddcovidipediaContext()) hopitals = GenericQuery.QueryHopital(input.name, context);
            TempDataStorage(new ArrayList(hopitals));
            ViewDataStorage(new ArrayList(hopitals));
            return Page();
        }

        public async Task<IActionResult> OnPostDownloadFile() {
            string fileName = Path.Combine("./resultsquery-" + TempData.Peek("input.type").ToString() + "-" + DateTime.Now.ToString("yyyyMMdd") + ".csv"); //Format: ./resultsquery-[TABLENAME]-[DATE].csv
            CSVWriter.TypeParser(JsonConvert.DeserializeObject<ArrayList>(TempData.Peek("queryResults").ToString()), TempData.Peek("input.type").ToString(), fileName);
            MemoryStream memory = new MemoryStream();  
            //Check if file exist, otherwise popup d'erreur?
            using (FileStream stream = new FileStream(fileName, FileMode.Open))  await stream.CopyToAsync(memory);
            System.IO.File.Delete(fileName);
            memory.Position = 0;  
            return File(memory, "text/csv", fileName);
        }

        private void TempDataStorage(ArrayList queryResults) {
            TempData["input.type"] = input.type;
            string queryResultsJSON = JsonConvert.SerializeObject(queryResults);
            TempData["queryResults"] = queryResultsJSON;
        }

        private void ViewDataStorage(ArrayList queryResult) {
            ViewData["ResultTableHead"] = "<tr><th>ID hopital</th><th>Nom hopital</th><th>Nombre de lits</th><th>Nombre de lits en réanimation</th></tr>";
            foreach(Hopital hopital in queryResult) {
                ViewData["ResultTable"] += $"<tr><th>{hopital.IdHopitalHopital}</th><th>{hopital.NomHopital}</th><th>{hopital.NombreLitsHopital}</th><th>{hopital.NombreLitsReanimationHopital}</th></tr>";
            }
            ViewData["ResultTable"] += "</table>";
        }
    }
}
