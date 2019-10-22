using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Peaky.Jenkins.Models.Server
{
    public class View
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
