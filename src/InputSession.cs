using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Yandex.Dialogs.Models
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class InputSession : Session
    {
        public bool New { get; set; }

        public string SkillId { get; set; }
    }
}
