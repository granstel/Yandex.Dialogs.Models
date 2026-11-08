using System.Text.Json.Serialization;

namespace Yandex.Dialogs.Models.Buttons
{
    public class CardButton : Button
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }
    }
}
