using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Yandex.Dialogs.Models
{
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class MetaModel
    {
        [JsonProperty]
        public string Locale { get; set; }

        [JsonProperty]
        public string Timezone { get; set; }

        [JsonProperty]
        public string ClientId { get; set; }

        [JsonProperty]
        public Interfaces Interfaces { get; set; }
    }
}
