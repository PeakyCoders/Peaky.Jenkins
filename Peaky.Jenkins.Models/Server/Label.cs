using Newtonsoft.Json;

namespace Peaky.Jenkins.Models.Server
{
    public class Label
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
