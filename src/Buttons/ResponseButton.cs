using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Yandex.Dialogs.Models
{
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class ResponseButton : Button
    {
        [JsonProperty]
        public string Title { get; set; }

        [JsonProperty]
        public bool Hide { get; set; }
    }
}
