using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace covidipedia.connectors
{
    public class Worker : BackgroundService {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger) {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken) {
            List<Connector> list = new List<Connector>();
            try { list = Connector.ReadJSON(@"E:\OneDrive\Cours\M2\BureauEtude\Covidipedia\connectors.json"); }
            catch(Exception e) {
                _logger.LogInformation(e.ToString());
                return;
            }
            await ConnectorsProcessing(list); //Timer ici ou Task Scheduler/cron?
        }

        private async Task ConnectorsProcessing(List<Connector> list) {
            foreach (Connector connector in list) {
                switch(connector.type) {
                    case "csv":
                        await Fetch.FetchCSV(connector);
                        break;
                    
                    case "db":
                        await Fetch.FetchDB(connector);
                        break;

                    default:
                        _logger.LogInformation("Type de connecteur non reconnu.");
                        break;
                }
            }
        }
    }
}
