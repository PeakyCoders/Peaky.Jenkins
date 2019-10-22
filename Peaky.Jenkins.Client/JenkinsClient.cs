using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Peaky.Jenkins.Models.Builds;
using Peaky.Jenkins.Models.Jobs;
using Peaky.Jenkins.Models.Server;

namespace Peaky.Jenkins.Client
{
    public class JenkinsClient : IJenkinsClient
    {
        private readonly JenkinsConfiguration _jenkinsConfiguration;
        private const string JsonSuffix = "api/json?pretty=true";

        public JenkinsClient(JenkinsConfiguration jenkinsConfiguration)
        {
            _jenkinsConfiguration = jenkinsConfiguration;
        }

        public async Task<JenkinsServer> GetServerAsync()
        {
            HttpClient client = BuildBaseClient();
            HttpResponseMessage response = await client.GetAsync(BuildUrl());

            return JsonConvert.DeserializeObject<JenkinsServer>(await response.Content.ReadAsStringAsync());
        }

        public async Task<Job> GetJobAsync(string jobName)
        {
            HttpClient client = BuildBaseClient();
            HttpResponseMessage response = await client.GetAsync(BuildUrl($"job/{jobName}"));

            return JsonConvert.DeserializeObject<Job>(await response.Content.ReadAsStringAsync());
        }

        public async Task<Build> GetBuildAsync(string jobName, int buildId)
        {
            HttpClient client = BuildBaseClient();
            HttpResponseMessage response = await client.GetAsync(BuildUrl($"job/{jobName}/{buildId}"));

            return JsonConvert.DeserializeObject<Build>(await response.Content.ReadAsStringAsync());
        }

        public async Task<bool> QueueJobAsync(string jobName, Dictionary<string, string> parameters)
        {
            HttpClient client = BuildBaseClient();
            Crumb crumb = await GetCrumbAsync();
            client.DefaultRequestHeaders.Add(crumb.CrumbRequestField, crumb.CrumbValue);

            FormUrlEncodedContent content = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>()
                {new KeyValuePair<string, string>("json", RequestBuild.From(parameters).Serialized())});

            HttpResponseMessage response = await client.PostAsync(BuildActionsUri($"job/{jobName}/build"), content);

            return response.StatusCode == HttpStatusCode.Created;
        }

        private HttpClient BuildBaseClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(
                Encoding.ASCII.GetBytes(
                    $"{_jenkinsConfiguration.Username}:{_jenkinsConfiguration.Token}")));

            return client;
        }

        private Uri BuildUrl(string route = "")
        {
            if (string.IsNullOrEmpty(route))
            {
                return new Uri($"{_jenkinsConfiguration.Url}/{JsonSuffix}");
            }
            else
            {
                return new Uri($"{_jenkinsConfiguration.Url}/{route}/{JsonSuffix}");
            }
        }

        private Uri BuildActionsUri(string route)
        {
            return new Uri($"{_jenkinsConfiguration.Url}/{route}");
        }

        private async Task<Crumb> GetCrumbAsync()
        {
            HttpClient client = BuildBaseClient();
            HttpResponseMessage response = await client.GetAsync(BuildUrl("crumbIssuer/api/json"));

            return JsonConvert.DeserializeObject<Crumb>(await response.Content.ReadAsStringAsync());
        }
    }
}
