using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

namespace covidipedia.front.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly ILogger<LoginModel> _logger;

        public RegisterModel(ILogger<LoginModel> logger)
        {
            _logger = logger;
        }

        public void OnGet() { }
    }
}
