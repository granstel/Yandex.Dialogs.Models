using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Yandex.Dialogs.Models.Buttons
{
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public abstract class Button
    {
        [JsonProperty]
        public object Payload { get; set; }

        [JsonProperty]
        public string Url { get; set; }
    }
}