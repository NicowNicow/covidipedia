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
            Config config;
            List<Connector> list = new List<Connector>();
            try { config = Config.ReadJSON(); }
            catch(Exception) {
                _logger.LogInformation("Please put the config.json file in the same folder as the service executable!");
                return;
            }
            try { list = Connector.ReadJSON(config.connector_list_path); }
            catch(Exception) {
                _logger.LogInformation("JSON file not found, please check the path in the config.json file");
                return;
            }
            await ConnectorsProcessing(list); //Timer ici ou Task Scheduler/cron?
            System.Environment.Exit(0);
        }

        private async Task ConnectorsProcessing(List<Connector> list) {
            foreach (Connector connector in list) {
                switch(connector.type) {
                    case "csv":
                        await Fetch.FetchCSV(connector);
                        break;
                    
                    // case "db":
                    //     await Fetch.FetchDB(connector);
                    //     break;

                    default:
                        _logger.LogInformation("Connector type unrecognized.");
                        break;
                }
            }
        }
    }
}
