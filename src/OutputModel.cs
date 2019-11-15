using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Yandex.Dialogs.Models
{
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class OutputModel
    {
        [JsonProperty]
        public Response Response { get; set; }

        [JsonProperty]
        public AccountLinking StartAccountLinking { get; set; }

        [JsonProperty]
        public Session Session { get; set; }

        [JsonProperty]
        public string Version { get; set; }
    }
}
