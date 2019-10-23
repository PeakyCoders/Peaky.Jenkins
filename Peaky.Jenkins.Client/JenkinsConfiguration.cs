namespace Peaky.Jenkins.Client
{
    public class JenkinsConfiguration
    {
        public string Url { get; set; }

        public string Username { get; set; }

        public string Token { get; set; }

        public bool UseCrumb { get; set; } = false;
    }
}
