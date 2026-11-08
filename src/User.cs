using System.Text.Json.Serialization;

namespace Yandex.Dialogs.Models
{
    public class User
    {
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }
    }
}