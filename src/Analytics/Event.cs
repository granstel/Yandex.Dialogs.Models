using System.Collections.Generic;
using System.Text.Json.Serialization;
using Yandex.Dialogs.Models.Serialization;

namespace Yandex.Dialogs.Models.Analytics
{
    public class Event
    {
        public Event(string name, IDictionary<string, object> value)
        {
            Name = name;
            Value = value;
        }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("value")]
        [JsonConverter(typeof(AnalyticsValueConverter))]
        public IDictionary<string, object> Value { get; set; }
    }
}
