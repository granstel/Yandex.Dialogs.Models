using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Yandex.Dialogs.Models
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]

    public class Token
    {
        public int Start { get; set; }

        public int End { get; set; }
    }
}
