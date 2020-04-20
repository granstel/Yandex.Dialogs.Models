using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Yandex.Dialogs.Models.Cards
{
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class ItemsListCard : ICard
    {
        public CardType Type => CardType.ItemsList;

        [JsonProperty]
        public Header Header { get; set; }

        [JsonProperty]
        public CardItem[] Items { get; set; }
    }
}
