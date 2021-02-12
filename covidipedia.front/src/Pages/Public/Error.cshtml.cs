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
                    return "Error Page Reached";

                case 400:
                    return "Bad Request";

                case 401:
                    return "Authorization Required";

                case 403:
                    return "Forbidden";

                case 404:
                    return "Page Not Found";

                case 408:
                    return "Request Time-Out";

                case 410:
                    return "Gone";
                
                case 500:
                    return "Internal Server Error";

                case 502:
                    return "Bad Gateway";

                case 503:
                    return "Service Temporarily Unavailable";

                case 504:
                    return "Gateway Time-Out";

                default:
                    return "Error";
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
