using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Yandex.Dialogs.Models.Analytics
{
    public class Analytics
    {
        public Analytics()
        {
            Events = new List<Event>();
        }

        [JsonPropertyName("events")]
        public ICollection<Event> Events { get; set; }

        public void AddEvent(string name, IDictionary<string, object> value)
        {
            var @event = new Event(name, value);

            Events.Add(@event);
        }
    }
}
