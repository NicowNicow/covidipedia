using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace covidipedia.connectors
{
    public class Fetch {

        public static async Task FetchCSV(Connector connector, Config config) {
            var client = new WebClient();
            if (connector.url != "") {
                System.Uri uri = new System.Uri(connector.url);
                try { await client.DownloadFileTaskAsync(uri, Path.Combine(config.file_download_path + connector.name)); }
                catch(Exception) {}
                //ProcessDataCSV Method
            }
        }

        // public static async Task FetchDB (Connector connector) {
        //     //TODO
        //     //ProcessDataDB Method
        // }
    }
}
