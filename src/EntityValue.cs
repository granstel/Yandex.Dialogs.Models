using System.Text.Json.Serialization;

namespace Yandex.Dialogs.Models
{
    public class EntityValue
    {
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }
        
        [JsonPropertyName("last_name")]
        public string LastName { get; set; }
        
        [JsonPropertyName("patronymic_name")]
        public string PatronymicName { get; set; }
    }
}
