﻿using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Yandex.Dialogs.Models
{
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class Session
    {
        [JsonProperty]
        public string SessionId { get; set; }

        [JsonProperty]
        public int MessageId { get; set; }

        [JsonProperty]
        public string UserId { get; set; }
    }
}
