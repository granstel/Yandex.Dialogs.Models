using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Yandex.Dialogs.Models
{
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class EntityValue
    {
        [JsonProperty]
        public string FirstName { get; set; }
        
        [JsonProperty]
        public string LastName { get; set; }
        
        [JsonProperty]
        public string PatronymicName { get; set; }
    }
}
