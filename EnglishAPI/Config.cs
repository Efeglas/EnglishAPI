using System.Text.Json;

namespace EnglishAPI
{
    public static class Config
    {
        public static string ConnectionString { get; set; }
        static Config() {
            try
            {
                /* config.json
                    {
                        "connectionString": "[mysql connection string]"
                    }
                 */
                string jsonString = File.ReadAllText("./config.json");
                JsonElement jsonObject = JsonSerializer.Deserialize<JsonElement>(jsonString);
                ConnectionString = jsonObject.GetProperty("connectionString").GetString();
                Console.WriteLine($"Connection String read: {ConnectionString}");
            }
            catch (Exception)
            {
                Console.WriteLine("Malformed config.json file or file not exists!");
            }
        }
    }
}
