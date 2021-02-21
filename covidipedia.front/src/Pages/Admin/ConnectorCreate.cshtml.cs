using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;

namespace covidipedia.front.Pages {
    [Authorize(Roles = "Admin")]
    public class ConnectorCreateModel : PageModel {

            [BindProperty]
            public ConnectorInputModel input { get; set; }
            private IConfiguration configuration { get; set; }
            private string connectorPath { get; set; }
            public List<Connector> connectorsList { get; set; }

            public ConnectorCreateModel(IConfiguration iConfig) {
                configuration = iConfig;
                connectorPath = configuration.GetSection("ConnectorsPath").Value;
                connectorsList = Connector.ReadJSON(connectorPath);
            }

            public class ConnectorInputModel {
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

            public IActionResult OnPostCreate() {
                if (!ModelState.IsValid) return RedirectToPage("./Connector");
                connectorsList.Add(new Connector(input.type, input.name, input.url, input.additional));
                Connector.RewriteConnectorsFile(connectorsList, connectorPath);
                return RedirectToPage("./Connector");
            }
        }
    }

