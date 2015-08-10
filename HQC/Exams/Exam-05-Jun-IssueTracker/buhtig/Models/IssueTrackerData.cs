namespace IssueTracker.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;
    using Wintellect.PowerCollections;

    public class IssueTrackerData : IIssueTrackerData
    {
        private int nextIssueId;

        public IssueTrackerData()
        {
            this.nextIssueId = 1;
            this.Users = new Dictionary<string, User>();
            this.Issues = new OrderedDictionary<int, Problem>();
            this.UsersAndIssues = new MultiDictionary<string, Problem>(true);
            this.TagsAndIssues = new MultiDictionary<string, Problem>(true);
            this.UsersAndComments = new MultiDictionary<User, Comment>(true);
        }

        public User LoggedUser { get; set; }

        public IDictionary<string, User> Users { get; private set; }

        public OrderedDictionary<int, Problem> Issues { get; private set; }

        public MultiDictionary<string, Problem> UsersAndIssues { get; private set; }

        public MultiDictionary<string, Problem> TagsAndIssues { get; private set; }

        public MultiDictionary<User, Comment> UsersAndComments { get; private set; }

        public void AddIssue(Problem issue)
        {
            this.Issues.Add(issue.Id, issue);
            this.UsersAndIssues[this.LoggedUser.Username].Add(issue);
            foreach (var tag in issue.Tags)
            {
                this.TagsAndIssues[tag].Add(issue);
            }
        }

        public void RemoveIssue(Problem issue)
        {
            this.UsersAndIssues[this.LoggedUser.Username].Remove(issue);
            foreach (var tag in issue.Tags)
            {
                this.TagsAndIssues[tag].Remove(issue);
            }

            this.Issues.Remove(issue.Id);
        }

        public void AddUser(User user)
        {
            this.Users.Add(user.Username, user);
        }

        public User GetUser(string username)
        {
            return this.Users[username];
        }

        public int GetNextIssueId()
        {
            return this.nextIssueId;
        }

        public void IncreaseIssueIdCount()
        {
            this.nextIssueId++;
        }

        public void AddComment(int issueId, Comment comment)
        {
            var issue = this.Issues[issueId];
            issue.AddComment(comment);
            this.UsersAndComments[this.LoggedUser].Add(comment);
        }

        public IList<Problem> GetIssuesForLoggedUser()
        {
           return this.UsersAndIssues[this.LoggedUser.Username].ToList();
        }

        public IList<Comment> GetCommentsForLoggedUser()
        {
            var comments = this.UsersAndComments[this.LoggedUser];
            return comments.ToList();
        }

        public IList<Problem> GetIssuesForTag(string tag)
        {
            return this.TagsAndIssues[tag].ToList();
        }
    }
}