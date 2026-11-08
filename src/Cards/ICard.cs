using System.Text.Json.Serialization;

namespace Yandex.Dialogs.Models.Cards
{
    [JsonConverter(typeof(CardJsonConverter))]
    public interface ICard
    {
        [JsonPropertyName("type")]
        CardType Type { get; }
    }
}
