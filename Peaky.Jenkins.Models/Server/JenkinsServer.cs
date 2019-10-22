using System.Collections.Generic;
using Newtonsoft.Json;
using Peaky.Jenkins.Models.Jobs;

namespace Peaky.Jenkins.Models.Server
{
    public class JenkinsServer
    {
        [JsonProperty("assignedLabels")]
        public List<Label> AssignedLabels { get; set; }

        [JsonProperty("mode")]
        public string Mode { get; set; }

        [JsonProperty("nodeDescription")]
        public string NodeDescription { get; set; }

        [JsonProperty("nodeName")]
        public string NodeName { get; set; }

        [JsonProperty("numExecutors")]
        public int NumExecutors { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("jobs")]
        public List<JobSummary> Jobs { get; set; }

        [JsonProperty("primaryView")]
        public View PrimaryView { get; set; }

        [JsonProperty("quietingDown")]
        public string QuietingDown { get; set; }

        [JsonProperty("slaveAgentPort")]
        public int SlaveAgentPort { get; set; }

        [JsonProperty("useCrumbs")]
        public string UseCrumbs { get; set; }

        [JsonProperty("useSecurity")]
        public string UseSecurity { get; set; }

        [JsonProperty("views")]
        public List<View> Views { get; set; }
    }
}
