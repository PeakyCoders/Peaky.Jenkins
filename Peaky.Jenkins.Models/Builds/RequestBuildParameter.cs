using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Peaky.Jenkins.Models.Builds
{
    public class RequestBuildParameter
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
