using System.Text.Json.Serialization;
using Yandex.Dialogs.Models.Buttons;

namespace Yandex.Dialogs.Models.Cards
{
    [JsonDerivedType(typeof(BigImageCard))]
    public class CardItem
    {
        [JsonPropertyName("image_id")]
        public string ImageId { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("button")]
        public CardButton Button { get; set; }
    }
}
