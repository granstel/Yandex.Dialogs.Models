using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Yandex.Dialogs.Models.Buttons;

namespace Yandex.Dialogs.Models.Cards
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class Footer : Header
    {
        public CardButton Button { get; set; }
    }
}
