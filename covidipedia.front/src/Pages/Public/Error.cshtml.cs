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

        public ErrorModel(ILogger<ErrorModel> logger)
        {
            _logger = logger;
        }

        /*public IActionResult OnGet(int id)
        {
            return Page();
        }*/

        public string showError()
        {
            if (Code == 0)
                return "Error Page Reached";
            else if (Code == 400)
                return "Bad Request";
            else if (Code == 401)
                return "Authorization Required";
            else if (Code == 403)
                return "Forbidden";
            else if (Code == 404)
                return "Page Not Found";
            else if (Code == 408)
                return "Request Time-Out";
            else if (Code == 410)
                return "Gone";
            else if (Code == 500)
                return "Internal Server Error";
            else if (Code == 502)
                return "Bad Gateway";
            else if (Code == 503)
                return "Service Temporarily Unavailable";
            else if (Code == 504)
                return "Gateway Time-Out";
            else return "Error";
        }

        public IActionResult OnPost(int id)
        {
            return Page();
        }
        public void OnGet(int? code)
        {
            Code = code ?? 0;
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
        }
    }
}
