using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Peaky.Jenkins.Models.Builds
{
    public class HealthReport
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("iconClassName")]
        public string IconClassName { get; set; }

        [JsonProperty("iconUrl")]
        public string IconUrl { get; set; }

        [JsonProperty("score")]
        public int Score { get; set; }
    }
}
