using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace covidipedia.front.Pages {
    [Authorize]
    public class LoginModel : PageModel {
        private readonly ILogger<LoginModel> _logger;

        public LoginModel(ILogger<LoginModel> logger) {
            _logger = logger;
        }

        public void OnGet(){}
    }
}
