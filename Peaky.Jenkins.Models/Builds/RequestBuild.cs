using System.Collections.Generic;
using Newtonsoft.Json;

namespace Peaky.Jenkins.Models.Builds
{
    public class RequestBuild
    {
        [JsonProperty("parameter")]
        public List<RequestBuildParameter> Parameter { get; set; } = new List<RequestBuildParameter>();

        public string Serialized()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static RequestBuild From(Dictionary<string, string> input)
        {
            RequestBuild request = new RequestBuild();

            foreach (KeyValuePair<string, string> parameter in input)
            {
                RequestBuildParameter requestBuildParameter = new RequestBuildParameter();
                requestBuildParameter.Name = parameter.Key;
                requestBuildParameter.Value = parameter.Value;

                request.Parameter.Add(requestBuildParameter);
            }

            return request;
        }
    }
}
