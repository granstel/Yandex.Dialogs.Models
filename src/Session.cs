using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Yandex.Dialogs.Models
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class Session
    {
        public string SessionId { get; set; }

        public int MessageId { get; set; }

        public string UserId { get; set; }
        
        public User User { get; set; }

        public Application Application { get; set; }
    }
}
