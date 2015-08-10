namespace IssueTracker.Core
{
    using System;
    using Enums;
    using Interfaces;

    public class Dispatcher
    {
        private readonly IIssueTracker tracker;

        public Dispatcher(IIssueTracker tracker)
        {
            this.tracker = tracker;
        }

        public Dispatcher()
            : this(new IssueTracker())
        {
        }

        public string DispatchAction(IEndpoint endpoint)
        {
            string message;
            switch (endpoint.CommandName)
            {
                case "RegisterUser":
                    message = this.tracker.RegisterUser(
                        endpoint.Parameters["username"],
                        endpoint.Parameters["password"],
                        endpoint.Parameters["confirmPassword"]);
                    break;
                case "LoginUser":
                    message = this.tracker.LoginUser(endpoint.Parameters["username"], endpoint.Parameters["password"]);
                    break;
                case "LogoutUser":
                    message = this.tracker.LogoutUser();
                    break;
                case "CreateIssue":
                    var priority = (IssuePriority)Enum.Parse(typeof(IssuePriority), endpoint.Parameters["priority"], true);
                    var tags = endpoint.Parameters["tags"].Split('|');
                    message = this.tracker.CreateIssue(
                        endpoint.Parameters["title"],
                        endpoint.Parameters["description"],
                        priority,
                        tags);
                    break;
                case "RemoveIssue":
                    message = this.tracker.RemoveIssue(int.Parse(endpoint.Parameters["id"]));
                    break;
                case "AddComment":
                    message = this.tracker.AddComment(
                        int.Parse(endpoint.Parameters["id"]),
                        endpoint.Parameters["text"]);
                    break;
                case "MyIssues":
                    message = this.tracker.GetMyIssues();
                    break;
                case "MyComments":
                    message = this.tracker.GetMyComments();
                    break;
                case "Search":
                    var searchTags = endpoint.Parameters["tags"].Split('|');
                    message = this.tracker.SearchForIssues(searchTags);
                    break;
                default:
                    message = string.Format("Invalid action: {0}", endpoint.CommandName);
                    break;
            }

            return message;
        }
    }
}