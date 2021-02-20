using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace covidipedia.front.Pages
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class ErrorModel : PageModel
    {
        public string RequestId { get; set; }
        public int Code { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        private readonly ILogger<ErrorModel> _logger;

        public ErrorModel(ILogger<ErrorModel> logger) {
            _logger = logger;
        }

        public string showError() {
            switch(Code) {
                case 0:
                    return "Page d'Erreur atteinte";

                case 400:
                    return "La requête est invalide";

                case 401:
                    return "Une authorisation est requise";

                case 403:
                    return "Action interdite";

                case 404:
                    return "Page introuvable";

                case 408:
                    return "Le délai d'attente pour la requête a expiré";

                case 410:
                    return "Disparu";
                
                case 500:
                    return "Erreur interne au Serveur";

                case 502:
                    return "Passerelle Invalide";

                case 503:
                    return "Le Service est temporairement indisponible";

                case 504:
                    return "Le délai d'attente pour la passerelle a expiré";

                default:
                    return "Erreur";
            }
        }

        public IActionResult OnPost(int id) {
            return Page();
        }

        public void OnGet(int? code) {
            Code = code ?? 0;
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
        }
    }
}
