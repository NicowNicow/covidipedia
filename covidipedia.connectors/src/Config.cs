using Newtonsoft.Json;
using System.IO;

namespace covidipedia.connectors
{
    public class Config {
        public string connector_list_path {get; set;}
        public string file_download_path {get; set;}

        public Config(string connector_list_path, string file_download_path) {
            this.connector_list_path = connector_list_path;
            this.file_download_path = file_download_path;
        }

        public static Config ReadJSON() {
            Config config;
            using (StreamReader file = File.OpenText("./config.json")) {
                JsonSerializer serializer = new JsonSerializer();
                config = (Config)serializer.Deserialize(file, typeof(Config));
            }
            return config;
        }
    }
}