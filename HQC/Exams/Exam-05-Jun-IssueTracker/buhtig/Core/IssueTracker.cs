namespace IssueTracker.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Enums;
    using Interfaces;
    using Models;

    public class IssueTracker : IIssueTracker
    {
        public IssueTracker(IIssueTrackerData data)
        {
            this.Data = data;
        }

        public IssueTracker()
            : this(new IssueTrackerData())
        {
        }

        public IIssueTrackerData Data { get; private set; }

        public string RegisterUser(string username, string password, string confirmPassword)
        {
            if (this.Data.LoggedUser != null)
            {
                return Message.AlreadyLogged;
            }

            if (password != confirmPassword)
            {
                return Message.NotMatchingPasswords;
            }

            if (this.Data.Users.ContainsKey(username))
            {
                return string.Format(Message.UserExists, username);
            }

            var user = new User(username, password);
            this.Data.AddUser(user);
            return string.Format(Message.RegisteredSuccessfully, username);
        }

        public string LoginUser(string username, string password)
        {
            if (this.Data.LoggedUser != null)
            {
                return Message.AlreadyLogged;
            }

            if (!this.Data.Users.ContainsKey(username))
            {
                return string.Format(Message.UserNotFound, username);
            }

            var user = this.Data.GetUser(username);
            if (user.Password != PasswordHasher.HashPassword(password))
            {
                return string.Format(Message.NotValidPassword, username);
            }

            this.Data.LoggedUser = user;

            return string.Format(Message.LoggedSuccessfully, username);
        }

        public string LogoutUser()
        {
            if (this.Data.LoggedUser == null)
            {
                return Message.NoOneLogged;
            }

            var username = this.Data.LoggedUser.Username;
            this.Data.LoggedUser = null;
            return string.Format(Message.LoggedOutSuccessfully, username);
        }

        public string CreateIssue(string title, string description, IssuePriority priority, string[] tags)
        {
            if (this.Data.LoggedUser == null)
            {
                return Message.NoOneLogged;
            }

            var id = this.Data.GetNextIssueId();
            var issue = new Problem(id, title, description, priority, tags.Distinct().ToList());
            this.Data.IncreaseIssueIdCount();
            this.Data.AddIssue(issue);

            return string.Format(Message.IssueCreated, issue.Id);
        }

        public string RemoveIssue(int issueId)
        {
            if (this.Data.LoggedUser == null)
            {
                return Message.NoOneLogged;
            }

            if (!this.Data.Issues.ContainsKey(issueId))
            {
                return string.Format(Message.IssueIdNotFound, issueId);
            }

            var issue = this.Data.Issues[issueId];
            var username = this.Data.LoggedUser.Username;
            if (!this.Data.UsersAndIssues[username].Contains(issue))
            {
                return string.Format(Message.IssueDontBelong, issueId, username);
            }

            this.Data.RemoveIssue(issue);

            return string.Format(Message.IssueRemoved, issueId);
        }

        public string AddComment(int issueId, string issueText)
        {
            if (this.Data.LoggedUser == null)
            {
                return Message.NoOneLogged;
            }

            if (!this.Data.Issues.ContainsKey(issueId))
            {
                return string.Format(Message.IssueNotFound, issueId);
            }

            var comment = new Comment(this.Data.LoggedUser, issueText);
            this.Data.AddComment(issueId, comment);

            return string.Format(Message.CommentAddedToIssue, issueId);
        }

        public string GetMyIssues()
        {
            if (this.Data.LoggedUser == null)
            {
                return Message.NoOneLogged;
            }

            // PERFORMANCE: Removed redundant foreach with string concatenation in it.

            var issues = this.Data.GetIssuesForLoggedUser();
            if (issues.Any())
            {
                var orderedIssues = issues.OrderByDescending(x => x.Priority).ThenBy(x => x.Title);
                return string.Join(Environment.NewLine, orderedIssues);
            }

            return Message.NoIssues;
        }

        public string GetMyComments()
        {
            if (this.Data.LoggedUser == null)
            {
                return Message.NoOneLogged;
            }

            // PERFORMANCE: Used mutilidictionary to improve performance.

            var comments = this.Data.GetCommentsForLoggedUser();
            if (comments.Any())
            {
                return string.Join(Environment.NewLine, comments);
            }

            return Message.NoComments;
        }

        public string SearchForIssues(string[] tags)
        {
            if (tags.Length <= 0)
            {
                return Message.NoTags;
            }

            var issues = new List<Problem>();
            foreach (var tag in tags)
            {
                issues.AddRange(this.Data.GetIssuesForTag(tag));
            }

            if (issues.Any())
            {
                var distinctIssues = issues.Distinct();
                var orderedIssues = distinctIssues.OrderByDescending(x => x.Priority).ThenBy(x => x.Title);
                return string.Join(Environment.NewLine, orderedIssues);
            }

            return Message.NoMatchingTags;
        }
    }
}