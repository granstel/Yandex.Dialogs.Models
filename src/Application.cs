using System.Text.Json.Serialization;

namespace Yandex.Dialogs.Models
{
    public class Application
    {
        [JsonPropertyName("application_id")]
        public string ApplicationId { get; set; }
    }
}
