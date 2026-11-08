using System.Text.Json.Serialization;
using Yandex.Dialogs.Models.Buttons;

namespace Yandex.Dialogs.Models.Cards
{
    public class Footer : Header
    {
        [JsonPropertyName("button")]
        public CardButton Button { get; set; }
    }
}
