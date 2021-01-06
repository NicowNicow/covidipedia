using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace covidipedia.front.Pages {
    public class QueryModel : PageModel {
        private readonly ILogger<QueryModel> _logger;

        public QueryModel(ILogger<QueryModel> logger) {
            _logger = logger;
        }

        public void OnGet(){}
    }
}
