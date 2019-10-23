using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Peaky.Jenkins.Models.Builds;
using Peaky.Jenkins.Models.Jobs;
using Peaky.Jenkins.Models.Server;

namespace Peaky.Jenkins.Client
{
    public class JenkinsClient : IJenkinsClient
    {
        private readonly JenkinsConfiguration _jenkinsConfiguration;
        private const string JsonSuffix = "api/json";

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
            await HandleCrumbAsync(client);

            StringBuilder urlBuilder = new StringBuilder($"{_jenkinsConfiguration.Url}/job/{jobName}/buildWithParameters");
            if (parameters.Count > 0)
            {
                urlBuilder.Append("?");

                bool first = true;

                foreach (KeyValuePair<string, string> pair in parameters)
                {
                    if (first)
                    {
                        first = false;
                    }
                    else
                    {
                        urlBuilder.Append("&");
                    }

                    urlBuilder.Append($"{pair.Key}={pair.Value}");
                }
            }

            HttpRequestMessage request =
                new HttpRequestMessage(HttpMethod.Post, urlBuilder.ToString());
            
            HttpResponseMessage response = await client.SendAsync(request);

            return response.StatusCode == HttpStatusCode.Created;
        }

        #region Private methods

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

        private async Task HandleCrumbAsync(HttpClient client)
        {
            if (!_jenkinsConfiguration.UseCrumb) return;

            Crumb crumb = await GetCrumbAsync();
            client.DefaultRequestHeaders.Add(crumb.CrumbRequestField, crumb.CrumbValue);
        }

        private async Task<Crumb> GetCrumbAsync()
        {
            HttpClient client = BuildBaseClient();
            HttpResponseMessage response = await client.GetAsync(BuildUrl("crumbIssuer/api/json"));

            return JsonConvert.DeserializeObject<Crumb>(await response.Content.ReadAsStringAsync());
        } 

        #endregion
    }
}
