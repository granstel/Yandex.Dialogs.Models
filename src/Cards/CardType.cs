using System.Text.Json.Serialization;

namespace Yandex.Dialogs.Models.Cards
{
    [JsonConverter(typeof(JsonStringEnumConverter<CardType>))]
    public enum CardType
    {
        BigImage,

        ItemsList
    }
}
