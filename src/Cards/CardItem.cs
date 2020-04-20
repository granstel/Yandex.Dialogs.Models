using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Yandex.Dialogs.Models.Buttons;

namespace Yandex.Dialogs.Models.Cards
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class CardItem
    {
        public string ImageId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public CardButton Button { get; set; }
    }
}
