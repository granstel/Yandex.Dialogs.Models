using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Yandex.Dialogs.Models
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class OutputModel
    {
        public Response Response { get; set; }

        public AccountLinking StartAccountLinking { get; set; }

        public Session Session { get; set; }

        public State SessionState { get; set; }
        
        public State UserStateUpdate { get; set; }

        public string Version { get; set; }
    }
}
