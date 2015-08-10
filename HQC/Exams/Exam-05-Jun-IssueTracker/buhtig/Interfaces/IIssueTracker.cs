namespace IssueTracker.Interfaces
{
    using Enums;

    public interface IIssueTracker
    {
        /// <summary>
        /// Registers user with given username and password.
        /// </summary>
        /// <param name="username">Users's username.</param>
        /// <param name="password">Users's password.</param>
        /// <param name="confirmPassword">Confirmation of the password.</param>
        /// <returns>Message for status of the operation.</returns>
        string RegisterUser(string username, string password, string confirmPassword);
       
        /// <summary>
        /// Login the user with given username and password.
        /// </summary>
        /// <param name="username">Users's username.</param>
        /// <param name="password">Users's password.</param>
        /// <returns>Message for status of the operation.</returns>
        string LoginUser(string username, string password);

        /// <summary>
        /// Logs out the user, if any is logged.
        /// </summary>
        /// <returns>Message for status of the operation.</returns>
        string LogoutUser();

        /// <summary>
        /// Creates issue with given title, description, priority and tag/s. Id is auto-
        /// incremented.
        /// </summary>
        /// <param name="title">Title of the issue.</param>
        /// <param name="description">Description of the issue.</param>
        /// <param name="priority">Priority of the issue.</param>
        /// <param name="tags">Tags of the issue.</param>
        /// <returns>Message for status of the operation.</returns>
        string CreateIssue(string title, string description, IssuePriority priority, string[] tags);

        /// <summary>
        /// Removes issue with given issueId.
        /// </summary>
        /// <param name="issueId">Id of the issue.</param>
        /// <returns>Message for status of the operation.</returns>
        string RemoveIssue(int issueId);

        /// <summary>
        /// Add new comment with with given issue id and comment text.
        /// </summary>
        /// <param name="issueId">Id of the issue it is attached to.</param>
        /// <param name="issueText">Text of the comment.</param>
        /// <returns>Message for status of the operation.</returns>
        string AddComment(int issueId, string issueText);

        /// <summary>
        /// Gets all issues for the current user. Order them by priority of the issue (first with higher priority),
        /// then by title alphabetically.
        /// </summary>
        /// <returns>Message for status of the operation or user's issues.</returns>
        string GetMyIssues();

        /// <summary>
        /// Gets all comments for the current user sorted by time of adding.
        /// </summary>
        /// <returns>Message for status of the operation or current user's comments.</returns>
        string GetMyComments();

        /// <summary>
        /// Search all issues by given tag/tags. Order them by priority of the issue (first with higher priority),
        /// then by title alphabetically.
        /// </summary>
        /// <param name="tags">Given tags for the search.</param>
        /// <returns>Message for status of the operation or issues by tag.</returns>
        string SearchForIssues(string[] tags);
    }
}