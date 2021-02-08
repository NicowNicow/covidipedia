using System.Collections;
using System.IO;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace covidipedia.front.Pages
{

    public class QueryModel : PageModel {

        //Model Variables
        private readonly ILogger<QueryModel> _logger;

        [BindProperty]
        public QueryFormInput input { get; set; }


        //Model Constructor
        public QueryModel(ILogger<QueryModel> logger) {
            _logger = logger;
        }


        //View-Model Methods
        public void OnGet() { }

        public IActionResult OnPostSubmit() {
            if (!ModelState.IsValid) return Page();
            _logger.LogInformation(input.historiqueQuery.detectionDate[0].ToString());
            ArrayList results = new ArrayList();
            using (bddcovidipediaContext context = new bddcovidipediaContext()) results = GenericQuery.QuerySelector(input.name, input.type, context);
            TempDataStorage(results); 
            ViewDataStorage(results, input.type);
            return Page();
        }

        public async Task<IActionResult> OnPostDownloadFile() {
            string fileName = Path.Combine("resultsquery-" + TempData.Peek("input.type").ToString() + "-" + DateTime.Now.ToString("yyyyMMdd") + ".csv"); //Format de fileName: ./resultsquery-[TABLENAME]-[DATE].csv
            try {
                CSVWriter.TypeParser(JsonConvert.DeserializeObject<ArrayList>(HttpContext.Session.GetString("queryResults")), TempData.Peek("input.type").ToString(), fileName);
            } catch {
                //Popup ou prompt ici
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
            ViewData["ResultTable"] = GenericQuery.TableContentSelector(queryResult, input.type);
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
    }

}
