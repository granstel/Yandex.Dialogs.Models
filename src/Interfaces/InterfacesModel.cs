using System.Text.Json.Serialization;

namespace Yandex.Dialogs.Models.Interfaces
{
    public class InterfacesModel
    {
        [JsonPropertyName("account_linking")]
        public AccountLinking AccountLinking { get; set; }

        [JsonPropertyName("screen")]
        public Screen Screen { get; set; }

        [JsonPropertyName("payments")]
        public Payments Payments { get; set; }

        [JsonPropertyName("geolocation_sharing")]
        public GeolocationSharing GeolocationSharing { get; set; }

        public bool HasScreen()
        {
            return Screen != null;
        }

        public bool HasGeolocationSharing()
        {
            return GeolocationSharing != null;
        }
    }
}
