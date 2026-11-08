using System.Text.Json.Serialization;

namespace Yandex.Dialogs.Models.Input
{
    public class InputSession : Session
    {
        [JsonPropertyName("new")]
        public bool New { get; set; }

        [JsonPropertyName("skill_id")]
        public string SkillId { get; set; }

        [JsonPropertyName("location")]
        public Location Location { get; set; }
    }
}
