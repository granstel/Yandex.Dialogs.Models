using System.Text.Json.Serialization;

namespace Yandex.Dialogs.Models.Cards
{
    public class ItemsListCard : ICard
    {
        [JsonPropertyName("type")]
        public CardType Type => CardType.ItemsList;

        [JsonPropertyName("header")]
        public Header Header { get; set; }

        [JsonPropertyName("items")]
        public CardItem[] Items { get; set; }
    }
}
