using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Yandex.Dialogs.Models
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class Request
    {
        public string OriginalUtterance {get; set;}
        
        public string Command { get; set;}

        public Nlu Nlu { get; set; }
    }
}
