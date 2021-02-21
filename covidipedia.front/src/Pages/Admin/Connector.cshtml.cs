using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using System;

namespace covidipedia.front.src.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class ConnectorModel : PageModel {

        private IConfiguration configuration { get; set; }
        private string connectorPath { get; set; }
        public List<Connector> connectorsList { get; set; }
        [BindProperty]
        public string connectorDeleteName { get; set; }

        public ConnectorModel(IConfiguration iConfig) {
            configuration = iConfig;
            connectorPath = configuration.GetSection("ConnectorsPath").Value;
            connectorsList = Connector.ReadJSON(connectorPath);
        }

        public IActionResult OnPostDelete() {
            if (!ModelState.IsValid) return Page();
            connectorsList.RemoveAll(connector => connector.name == connectorDeleteName);
            Connector.RewriteConnectorsFile(connectorsList, connectorPath);
            return Page();
        }

    }
}