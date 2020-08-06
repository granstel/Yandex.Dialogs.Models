using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Yandex.Dialogs.Models.Buttons;
using Yandex.Dialogs.Models.Cards;

namespace Yandex.Dialogs.Models
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class Response
    {
        public string Text { get; set; }

        public string Tts { get; set; }

        public ResponseButton[] Buttons { get; set; }

        public bool EndSession { get; set; }
        
        public ICard Card { get; set; }
    }
}
