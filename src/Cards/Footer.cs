using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Yandex.Dialogs.Models.Buttons;

namespace Yandex.Dialogs.Models.Cards
{
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class Footer : Header
    {
        [JsonProperty]
        public CardButton Button { get; set; }
    }
}
