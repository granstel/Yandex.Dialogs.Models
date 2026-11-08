using System.Text.Json.Serialization;
using Yandex.Dialogs.Models.Input;

namespace Yandex.Dialogs.Models
{
    [JsonDerivedType(typeof(InputSession))]
    public class Session
    {
        [JsonPropertyName("session_id")]
        public string SessionId { get; set; }

        [JsonPropertyName("message_id")]
        public int MessageId { get; set; }

        [JsonPropertyName("user_id")]
        public string UserId { get; set; }
        
        [JsonPropertyName("user")]
        public User User { get; set; }

        [JsonPropertyName("application")]
        public Application Application { get; set; }
    }
}
