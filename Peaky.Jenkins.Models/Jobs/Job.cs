using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Peaky.Jenkins.Models.Builds;

namespace Peaky.Jenkins.Models.Jobs
{
    public class Job
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("displayNameOrNull")]
        public string DisplayNameOrNull { get; set; }

        [JsonProperty("fullDisplayName")]
        public string FullDisplayName { get; set; }

        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("buildable")]
        public bool Buildable { get; set; }

        [JsonProperty("builds")]
        public List<BuildSummary> Builds { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("firstBuild")]
        public BuildSummary FirstBuild { get; set; }

        [JsonProperty("healthReport")]
        public List<HealthReport> HealthReport { get; set; }

        [JsonProperty("inQueue")]
        public bool InQueue { get; set; }

        [JsonProperty("keepDependencies")]
        public bool KeepDependencies { get; set; }

        [JsonProperty("lastBuild")]
        public BuildSummary LastBuild { get; set; }

        [JsonProperty("lastCompletedBuild")]
        public BuildSummary LastCompletedBuild { get; set; }

        [JsonProperty("lastFailedBuild")]
        public BuildSummary LastFailedBuild { get; set; }

        [JsonProperty("lastStableBuild")]
        public BuildSummary LastStableBuild { get; set; }

        [JsonProperty("lastSuccessfulBuild")]
        public BuildSummary LastSuccessfulBuild { get; set; }

        [JsonProperty("lastUnstableBuild")]
        public BuildSummary LastUnstableBuild { get; set; }

        [JsonProperty("lastUnsuccessfulBuild")]
        public BuildSummary LastUnsuccessfulBuild { get; set; }

        [JsonProperty("nextBuildNumber")]
        public int NextBuildNumber { get; set; }

        [JsonProperty("queueItem")]
        public string QueueItem { get; set; }

        [JsonProperty("concurrentBuild")]
        public bool ConcurrentBuild { get; set; }

        [JsonProperty("resumeBlocked")]
        public bool ResumeBlocked { get; set; }

        [JsonProperty("property")]
        public JArray Property { get; set; }
    }
}
