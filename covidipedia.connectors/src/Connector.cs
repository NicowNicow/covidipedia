using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

namespace covidipedia.connectors
{
    public class Connector {
        public int id {get; set;}
        public string type {get; set;}
        public string name {get; set;}
        public string url {get; set;}
        public string additional {get; set;}

        public Connector(int id, string type, string name, string url, string additional) {
            this.id = id;
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