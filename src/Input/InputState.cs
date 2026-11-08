using System.Text.Json.Serialization;

namespace Yandex.Dialogs.Models.Input
{
    public class InputState
    {
        [JsonPropertyName("session")]
        public State Session { get; set; }

        [JsonPropertyName("user")]
        public State User { get; set; }
        
        [JsonPropertyName("application")]
        public State Application { get; set; }
    }
}
