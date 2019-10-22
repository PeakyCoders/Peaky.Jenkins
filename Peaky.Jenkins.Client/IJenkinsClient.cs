using System.Collections.Generic;
using System.Threading.Tasks;
using Peaky.Jenkins.Models.Builds;
using Peaky.Jenkins.Models.Jobs;
using Peaky.Jenkins.Models.Server;

namespace Peaky.Jenkins.Client
{
    public interface IJenkinsClient
    {
        Task<JenkinsServer> GetServerAsync();

        Task<Job> GetJobAsync(string jobName);

        Task<Build> GetBuildAsync(string jobName, int buildId);

        Task<bool> QueueJobAsync(string jobName, Dictionary<string, string> parameters);
    }
}
