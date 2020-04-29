using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Yandex.Dialogs.Models.Input
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class InputModel
    {
        public MetaModel Meta { get; set; }

        public Request Request { get; set; }

        public InputSession Session { get; set; }

        public InputState State { get; set; }

        public string Version { get; set; }
    }
}
