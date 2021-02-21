using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System;

namespace covidipedia.front
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

        public static void RewriteConnectorsFile(List<Connector> connectorsList, string connectorPath) {
            File.WriteAllText(connectorPath, String.Empty);
            using (StreamWriter file = new StreamWriter(File.OpenWrite(connectorPath))) {
                file.Write(JsonPrettifyer(JsonConvert.SerializeObject(connectorsList)));
            }
        }

        private static string JsonPrettifyer(string toPrettify) {
            using (var stringReader = new StringReader(toPrettify))
            using (var stringWriter = new StringWriter())
            {
                var jsonReader = new JsonTextReader(stringReader);
                var jsonWriter = new JsonTextWriter(stringWriter) { Formatting = Formatting.Indented };
                jsonWriter.WriteToken(jsonReader);
                return stringWriter.ToString();
            }
        }
    }
}