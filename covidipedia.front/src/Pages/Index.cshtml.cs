using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using covidipedia.front.chart;

namespace covidipedia.front.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public ChartPrinter _chartSalesCountries { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            _chartSalesCountries = new ChartPrinter();
            _chartSalesCountries.SalesCountriesTest();
        }

    }
}
