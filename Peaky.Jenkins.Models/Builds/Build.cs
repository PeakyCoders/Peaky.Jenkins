using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Peaky.Jenkins.Models.Builds
{
    public class Build
    {
        [JsonProperty("actions")]
        public JArray Actions { get; set; }

        [JsonProperty("artifacts")]
        public List<Artifact> Artifacts{ get; set; }

        [JsonProperty("building")]
        public bool Building { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("duration")]
        public string Duration { get; set; }
        
        [JsonProperty("estimatedDuration")]
        public string EstimatedDuration { get; set; }
        
        [JsonProperty("executor")]
        public string Executor { get; set; }
        
        [JsonProperty("fullDisplayName")]
        public string FullDisplayName { get; set; }
        
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("keepLog")]
        public bool KeepLog { get; set; }
        
        [JsonProperty("number")]
        public int Number { get; set; }

        [JsonProperty("queueId")]
        public int QueueId { get; set; }

        [JsonProperty("result")]
        public string Result { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("changeSets")]
        public JArray ChangeSets { get; set; }

        [JsonProperty("culprits")]
        public List<Culprit> Culprits { get; set; }

        [JsonProperty("nextBuild")]
        public BuildSummary NextBuild { get; set; }

        [JsonProperty("previousBuild")]
        public BuildSummary PreviousBuild { get; set; }
    }
}
