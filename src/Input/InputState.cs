using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Yandex.Dialogs.Models.Input
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class InputState
    {
        public State Session { get; set; }

        public State User { get; set; }
        
        public State Applocation { get; set; }
    }
}
