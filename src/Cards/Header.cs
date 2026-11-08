using System.Text.Json.Serialization;

namespace Yandex.Dialogs.Models.Cards
{
    [JsonDerivedType(typeof(Footer))]
    public class Header
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }
    }
}
