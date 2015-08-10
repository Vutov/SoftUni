namespace IssueTracker.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using Interfaces;

    public class Endpoint : IEndpoint
    {
        public Endpoint(string queryString)
        {
            this.ProcessCommandLine(queryString);
        }

        public string CommandName { get; set; }

        public IDictionary<string, string> Parameters { get; set; }

        private void ProcessCommandLine(string queryString)
        {
            var questionMarkIndex = queryString.IndexOf('?');
            if (questionMarkIndex != -1)
            {
                this.CommandName = queryString.Substring(0, questionMarkIndex);
                var pairs = queryString.Substring(questionMarkIndex + 1)
                    .Split('&')
                    .Select(x => x.Split('=').Select(WebUtility.UrlDecode).ToArray());
                var parameters = pairs.ToDictionary(pair => pair[0], pair => pair[1]);
                this.Parameters = parameters;
            }
            else
            {
                this.CommandName = queryString;
            }
        }
    }
}