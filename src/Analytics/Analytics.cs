using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Yandex.Dialogs.Models.Analytics
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class Analytics
    {
        public Analytics()
        {
            Events = new List<Event>();
        }

        public ICollection<Event> Events { get; set; }

        public void AddEvent(string name, IDictionary<string, object> value)
        {
            var @event = new Event(name, value);

            Events.Add(@event);
        }
    }
}
