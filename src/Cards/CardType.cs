using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Yandex.Dialogs.Models.Cards
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CardType
    {
        BigImage,

        ItemsList
    }
}
