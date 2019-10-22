using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Peaky.Jenkins.Models.Builds
{
    public class Artifact
    {
        [JsonProperty("displayPath")]
        public string DisplayPath { get; set; }
        
        [JsonProperty("fileName")]
        public string FileName { get; set; }
        
        [JsonProperty("relativePath")]
        public string RelativePath { get; set; }
    }
}
