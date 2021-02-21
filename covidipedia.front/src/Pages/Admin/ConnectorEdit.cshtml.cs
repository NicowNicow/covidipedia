using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace covidipedia.front.Pages {
    [Authorize(Roles = "Admin")]
    public class ConnectorEditModel : PageModel {

            [BindProperty]
            public ConnectorEditInputModel input { get; set; }
            private IConfiguration configuration { get; set; }
            private string connectorPath { get; set; }
            public List<Connector> connectorsList { get; set; }

            public ConnectorEditModel(IConfiguration iConfig) {
                configuration = iConfig;
                connectorPath = configuration.GetSection("ConnectorsPath").Value;
                connectorsList = Connector.ReadJSON(connectorPath);
            }

            public class ConnectorEditInputModel {
                public int id { get; set; }

                [Required(ErrorMessage = "Veuillez renseigner le type du connecteur!")]
                [Display(Name = "Type")]
                public string type { get; set; }

                [Required(ErrorMessage = "Veuillez renseigner le nom du connecteur!")]
                [Display(Name = "Nom")]
                public string name { get; set; }

                [Required(ErrorMessage = "Veuillez renseigner l'URL du connecteur!")]
                [Display(Name = "URL")]
                public string url { get; set; }

                [Display(Name = "Informations Supplémentaires")]
                public string additional { get; set; }
            }

            public IActionResult OnGet(int id) {
                if (id == 0) return NotFound();
                Connector connector = connectorsList.FirstOrDefault(toFind => toFind.id == id);
                if (connector == null) return NotFound();
                input = new ConnectorEditInputModel {
                    id = connector.id,
                    type = connector.type,
                    name = connector.name,
                    url = connector.url,
                    additional = connector.additional
                };
                return Page();
            }

            public IActionResult OnPostCreate() {
                if (!ModelState.IsValid) return RedirectToPage("./Connector");
                foreach(Connector connector in connectorsList.Where(toFind => toFind.id == input.id)) {
                    connector.type = input.type;
                    connector.name = input.name;
                    connector.url = input.url;
                    connector.additional = input.additional;
                }
                Connector.RewriteConnectorsFile(connectorsList, connectorPath);
                return RedirectToPage("./Connector");
            }
        }
    }

