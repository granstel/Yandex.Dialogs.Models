using System.Text.Json.Serialization;
using Yandex.Dialogs.Models.Serialization;

namespace Yandex.Dialogs.Models.Buttons
{
    [JsonDerivedType(typeof(CardButton))]
    [JsonDerivedType(typeof(ResponseButton))]
    public abstract class Button
    {
        [JsonPropertyName("payload")]
        [JsonConverter(typeof(DynamicValueConverter))]
        public object Payload { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
