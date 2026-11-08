using System.Text.Json.Serialization;

namespace Yandex.Dialogs.Models.Cards
{
    public class BigImageCard : CardItem, ICard
    {
        [JsonPropertyName("type")]
        public CardType Type => CardType.BigImage;
    }
}
