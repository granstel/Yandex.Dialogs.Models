using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Yandex.Dialogs.Models
{
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]

    public class Token
    {
        [JsonProperty]
        public int Start { get; set; }

        [JsonProperty]
        public int End { get; set; }
    }
}
