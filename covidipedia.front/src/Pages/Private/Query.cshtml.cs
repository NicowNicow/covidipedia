using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace covidipedia.front.Pages
{
    public class QueryModel : PageModel
    {
        private readonly ILogger<QueryModel> _logger;
        public class Result {
            public DateTime date;
            public string place;
            public string info;
        }
        private static Random random = new Random();
        public static string RandomString(int length) {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public QueryModel(ILogger<QueryModel> logger) {
            _logger = logger;
        }

        public void OnGet() { }
    }
}
