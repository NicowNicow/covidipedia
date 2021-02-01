using System.Collections.Generic;
using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using covidipedia.front;

namespace covidipedia.front.Pages
{
    public class QueryModel : PageModel
    {
        private readonly ILogger<QueryModel> _logger;

        public QueryModel(ILogger<QueryModel> logger) {
            _logger = logger;
        }

        public void OnGet() { }


        //Activation du Bouton et fonction associée

        public class SampleModel {
            public string Name { get; set; }
        }

        [BindProperty]
        public SampleModel Input { get; set; }

        public IActionResult OnPostSubmit() {
            if (!ModelState.IsValid) return Page();
            List<Hopital> hopitals = new List<Hopital>();
            using (bddcovidipediaContext context = new bddcovidipediaContext()) {
                hopitals = GenericQuery.QueryHopital(Input.Name, context);
            }
            ViewData["ResultTable"] = "<table style='width: 100%'><tr><th>ID hopital</th><th>Nom hopital</th><th>Nombre de lits</th><th>Nombre de lits en réanimation</th></tr>";
            foreach(Hopital h in hopitals) {
                ViewData["ResultTable"] += $"<tr><th>{h.IdHopitalHopital}</th><th>{h.NomHopital}</th><th>{h.NombreLitsHopital}</th><th>{h.NombreLitsReanimationHopital}</th></tr>";
            }
            ViewData["ResultTable"] += "</table>";
            return Page();
        }

        
    }
}
