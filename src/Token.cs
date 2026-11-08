using System.Text.Json.Serialization;

namespace Yandex.Dialogs.Models
{
    public class Token
    {
        [JsonPropertyName("start")]
        public int Start { get; set; }

        [JsonPropertyName("end")]
        public int End { get; set; }
    }
}
