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

        public bool TryGetFromSessionState<T>(string key, out T result)
        {
            result = default;

            return State?.Session?.TryGetValue(key, out result) ?? false;
        }

        public bool TryGetFromUserState<T>(string key, out T result)
        {
            result = default;

            return State?.User?.TryGetValue(key, out result) ?? false;
        }

        public bool TryGetFromApplicationState<T>(string key, out T result)
        {
            result = default;

            return State?.Application?.TryGetValue(key, out result) ?? false;
        }
    }
}
