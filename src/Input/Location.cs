using System.Text.Json.Serialization;

namespace Yandex.Dialogs.Models.Input
{
    public class Location
    {
        [JsonPropertyName("lat")]
        public float Lat { get; set; }

        [JsonPropertyName("lon")]
        public float Lon { get; set; }

        [JsonPropertyName("accuracy")]
        public float Accuracy { get; set; }
    }
}
