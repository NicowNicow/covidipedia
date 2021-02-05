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


        //View-Model Methods
        public void OnGet() { }

        public IActionResult OnPostSubmit() {
            if (!ModelState.IsValid) return Page();
            ArrayList results = new ArrayList();
            using (bddcovidipediaContext context = new bddcovidipediaContext()) results = GenericQuery.QuerySelector(input.name, input.type, context);
            //TempDataStorage(results); A régler + TODO: Selection Multicritères
            ViewDataStorage(results, input.type);
            return Page();
        }

        public async Task<IActionResult> OnPostDownloadFile() {
            string fileName = Path.Combine("resultsquery-" + TempData.Peek("input.type").ToString() + "-" + DateTime.Now.ToString("yyyyMMdd") + ".csv"); //Format de fileName: ./resultsquery-[TABLENAME]-[DATE].csv
            CSVWriter.TypeParser(JsonConvert.DeserializeObject<ArrayList>(TempData.Peek("queryResults").ToString()), TempData.Peek("input.type").ToString(), fileName);
            return await FileDownloader(fileName);
        }


        //Model Inner Methods
        private void TempDataStorage(ArrayList queryResults) { //La conversion JSON force l'arrêt du localhost, problème à régler débrouille toi au réveil enculé -Nico
            TempData["input.type"] = input.type;
            string queryResultsJSON = JsonConvert.SerializeObject(queryResults);
            TempData["queryResults"] = queryResultsJSON;
        }

        private void ViewDataStorage(ArrayList queryResult, string type) {
            ViewData["ResultTableHead"] = GenericQuery.TableHeadSelector(input.type);
            ViewData["ResultTable"] = GenericQuery.TableContentSelector(queryResult, input.type);
        }

        private async Task<IActionResult> FileDownloader(string fileName) {
            MemoryStream memory = new MemoryStream();  
            try {
                using (FileStream stream = new FileStream(fileName, FileMode.Open))  await stream.CopyToAsync(memory);
                System.IO.File.Delete(fileName);
                memory.Position = 0;  
            }
            catch {
                _logger.LogError("File "+ fileName + " not found");
            }
            return File(memory, "text/csv", fileName);
        }
    }
}
