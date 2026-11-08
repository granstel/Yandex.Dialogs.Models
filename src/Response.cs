using System.Text.Json.Serialization;
using Yandex.Dialogs.Models.Buttons;
using Yandex.Dialogs.Models.Cards;

namespace Yandex.Dialogs.Models
{
    public class Response
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("tts")]
        public string Tts { get; set; }

        [JsonPropertyName("buttons")]
        public ResponseButton[] Buttons { get; set; }

        [JsonPropertyName("end_session")]
        public bool EndSession { get; set; }
        
        [JsonPropertyName("card")]
        public ICard Card { get; set; }

        [JsonPropertyName("directives")]
        public Directives Directives { get; set; }

        public void InitRequestGeolocation()
        {
            if (Directives == null)
            {
                Directives = new Directives();
            }

            Directives.InitRequestGeolocation();
        }
    }
}
