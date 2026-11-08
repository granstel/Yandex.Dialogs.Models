using System.Text.Json.Serialization;

namespace Yandex.Dialogs.Models.Input
{
    public class InputModel
    {
        [JsonPropertyName("meta")]
        public MetaModel Meta { get; set; }

        [JsonPropertyName("request")]
        public Request Request { get; set; }

        [JsonPropertyName("session")]
        public InputSession Session { get; set; }

        [JsonPropertyName("state")]
        public InputState State { get; set; }

        [JsonPropertyName("version")]
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
