using System.Collections.Generic;
using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace covidipedia.front.Pages
{
    public class QueryModel : PageModel
    {
        private readonly ILogger<QueryModel> _logger;

        public QueryModel(ILogger<QueryModel> logger) {
            _logger = logger;
        }

        public void OnGet() { }


        //Gestion du formulaire de requête

        public class FormInput {
            public string type { get; set; }
            public string name { get; set; }
        }

        [BindProperty]
        public FormInput input { get; set; }



        public IActionResult OnPostSubmit() {
            if (!ModelState.IsValid) return Page();
            _logger.LogInformation(input.type);
            List<Hopital> hopitals = new List<Hopital>();
            
            using (bddcovidipediaContext context = new bddcovidipediaContext()) {
                hopitals = GenericQuery.QueryHopital(input.name, context);
            }
            ViewData["ResultTableHead"] = "<tr><th>ID hopital</th><th>Nom hopital</th><th>Nombre de lits</th><th>Nombre de lits en réanimation</th></tr>";
            foreach(Hopital h in hopitals) {
                ViewData["ResultTable"] += $"<tr><th>{h.IdHopitalHopital}</th><th>{h.NomHopital}</th><th>{h.NombreLitsHopital}</th><th>{h.NombreLitsReanimationHopital}</th></tr>";
            }
            ViewData["ResultTable"] += "</table>";
            return Page();
        }
        
    }
}
