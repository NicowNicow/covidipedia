using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace covidipedia.front.Pages
{
    public class LayoutModel : PageModel
    {
        private readonly ILogger<LayoutModel> _logger;
        private static Random random = new Random();

        public class Result {
            public DateTime date;
            public string place;
            public string info;
        }
        
        public static string RandomString(int length) {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public LayoutModel(ILogger<LayoutModel> logger) {
            _logger = logger;
        }

        public void OnGet() { }
    }
}