using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Yandex.Dialogs.Models.Cards
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public interface ICard
    {
        CardType Type { get; }
    }
}
