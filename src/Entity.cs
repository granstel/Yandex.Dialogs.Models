using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Yandex.Dialogs.Models
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class Entity
    {
        public Token Tokens { get; set; }

        public string Type { get; set; }

        public dynamic Value { get; set; }
    }
}
