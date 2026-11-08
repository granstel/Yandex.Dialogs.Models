using System.Text.Json.Serialization;

namespace Yandex.Dialogs.Models
{
    public class Request
    {
        [JsonPropertyName("original_utterance")]
        public string OriginalUtterance {get; set;}
        
        [JsonPropertyName("command")]
        public string Command { get; set;}

        [JsonPropertyName("nlu")]
        public Nlu Nlu { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
