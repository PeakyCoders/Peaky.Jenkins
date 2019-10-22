using Newtonsoft.Json;

namespace Peaky.Jenkins.Models.Jobs
{
    public class JobSummary
    {
        [JsonProperty("name")] 
        public string Name { get; set; }

        [JsonProperty("url")] 
        public string Url { get; set; }

        [JsonProperty("color")] 
        public string Color { get; set; }
    }
}
