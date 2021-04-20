using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Yandex.Dialogs.Models.Analytics
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class Event
    {
        public Event(string name, IDictionary<string, object> value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; set; }

        public IDictionary<string, object> Value { get; set; }
    }
}