using System.Text.Json.Serialization;
using Yandex.Dialogs.Models.Serialization;

namespace Yandex.Dialogs.Models
{
    public class Entity
    {
        [JsonPropertyName("tokens")]
        public Token Tokens { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("value")]
        [JsonConverter(typeof(DynamicValueConverter))]
        public object Value { get; set; }
    }
}
