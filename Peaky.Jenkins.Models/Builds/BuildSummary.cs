using Newtonsoft.Json;

namespace Peaky.Jenkins.Models.Builds
{
    public class BuildSummary
    {
        [JsonProperty("number")] 
        public int Number { get; set; }

        [JsonProperty("url")] 
        public string Url { get; set; }
    }
}
