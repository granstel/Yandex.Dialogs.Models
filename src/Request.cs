﻿using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Yandex.Dialogs.Models
{
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class Request
    {
        [JsonProperty]
        public string OriginalUtterance {get; set;}
        
        [JsonProperty]
        public string Command { get; set;}

        [JsonProperty]
        public Nlu Nlu { get; set; }
    }
}
