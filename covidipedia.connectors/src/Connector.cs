using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System.IO;

namespace covidipedia.connectors
{
    public class Connector {
        public string type {get; set;}
        public string name {get; set;}
        public string url {get; set;}
        public string additional {get; set;}

        public Connector(string type, string name, string url, string additional) {
            this.type = type;
            this.name = name;
            this.url = url;
            this.additional = additional;
        }

        public static List<Connector> ReadJSON(string filePath) {
            List<Connector> list = new List<Connector>();
            using (StreamReader file = File.OpenText(filePath)) {
                JsonSerializer serializer = new JsonSerializer();
                list = (List<Connector>)serializer.Deserialize(file, typeof(List<Connector>));
            }
            return list;
        }
    }
}