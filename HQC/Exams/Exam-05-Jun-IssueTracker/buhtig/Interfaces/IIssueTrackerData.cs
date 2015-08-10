namespace IssueTracker.Interfaces
{
    using System.Collections.Generic;
    using Models;
    using Wintellect.PowerCollections;

    public interface IIssueTrackerData
    {
        User LoggedUser { get; set; }

        IDictionary<string, User> Users { get; }

        OrderedDictionary<int, Problem> Issues { get; }

        MultiDictionary<string, Problem> UsersAndIssues { get; }

        MultiDictionary<string, Problem> TagsAndIssues { get; }

        MultiDictionary<User, Comment> UsersAndComments { get; }

        void AddIssue(Problem problem);

        void RemoveIssue(Problem problem);

        void AddUser(User user);

        User GetUser(string username);

        int GetNextIssueId();

        void IncreaseIssueIdCount();

        void AddComment(int issueId, Comment comment);

        IList<Problem> GetIssuesForLoggedUser();

        IList<Comment> GetCommentsForLoggedUser();

        IList<Problem> GetIssuesForTag(string tag);
    }
}
