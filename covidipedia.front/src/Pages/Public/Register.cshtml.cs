using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace covidipedia.front.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly ILogger<LoginModel> _logger;

        public RegisterModel(ILogger<LoginModel> logger) {
            _logger = logger;
        }

        public void OnGet() { }
    }
}
