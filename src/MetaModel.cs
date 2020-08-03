using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Yandex.Dialogs.Models.Interfaces;

namespace Yandex.Dialogs.Models
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class MetaModel
    {
        public string Locale { get; set; }

        public string Timezone { get; set; }

        public string ClientId { get; set; }

        public InterfacesModel Interfaces { get; set; }
    }
}
