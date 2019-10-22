using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Peaky.Jenkins.Models.Builds
{
    public class Crumb
    {
        [JsonProperty("crumb")]
        public string CrumbValue { get; set; }

        [JsonProperty("crumbRequestField")]
        public string CrumbRequestField { get; set; }
    }
}
