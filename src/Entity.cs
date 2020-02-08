using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Yandex.Dialogs.Models
{
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class Entity
    {
        [JsonProperty]
        public Token Tokens { get; set; }

        [JsonProperty]
        public string Type { get; set; }

        [JsonProperty]
        public EntityValue Value { get; set; }
    }
}
