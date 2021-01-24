using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Yandex.Dialogs.Models
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class Directives
    {
        public RequestGeolocation RequestGeolocation { get; set; }

        public void InitRequestGeolocation()
        {
            RequestGeolocation = new RequestGeolocation();
        }
    }
}
