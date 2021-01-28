using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace covidipedia.front.Pages {
    [Authorize(Roles = "Admin")]
    public class AdminModel : PageModel {
        private readonly ILogger<AdminModel> _logger;

        public AdminModel(ILogger<AdminModel> logger) {
            _logger = logger;
        }

        public void OnGet(){}
    }
}