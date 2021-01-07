using Newtonsoft.Json;
using System.IO;

namespace covidipedia.connectors
{
    public class Config {
        public string database_path {get; set;}
        public string connector_list_path {get; set;}
        public string file_download_path {get; set;}

        public Config(string database_path, string connector_list_path, string file_download_path) {
            this.database_path = database_path;
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