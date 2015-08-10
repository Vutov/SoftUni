namespace IssueTracker.Interfaces
{
    using System.Collections.Generic;

    public interface IEndpoint
    {
        string CommandName { get; }

        IDictionary<string, string> Parameters { get; }
    }
}