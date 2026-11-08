using System.Text.Json.Serialization;

namespace Yandex.Dialogs.Models
{
    public class Directives
    {
        [JsonPropertyName("request_geolocation")]
        public RequestGeolocation RequestGeolocation { get; set; }

        public void InitRequestGeolocation()
        {
            RequestGeolocation = new RequestGeolocation();
        }
    }
}
