using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Yandex.Dialogs.Models.Buttons;

namespace Yandex.Dialogs.Models
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class Response
    {
        public string Text { get; set; }

        public string Tts { get; set; }

        public Button[] Buttons { get; set; }

        public bool EndSession { get; set; }
    }
}
