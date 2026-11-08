using System.Text.Json.Serialization;
using Yandex.Dialogs.Models.Interfaces;

namespace Yandex.Dialogs.Models
{
    public class MetaModel
    {
        [JsonPropertyName("locale")]
        public string Locale { get; set; }

        [JsonPropertyName("timezone")]
        public string Timezone { get; set; }

        [JsonPropertyName("client_id")]
        public string ClientId { get; set; }

        [JsonPropertyName("interfaces")]
        public InterfacesModel Interfaces { get; set; }
    }
}
