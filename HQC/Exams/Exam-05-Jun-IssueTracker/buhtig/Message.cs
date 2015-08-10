namespace IssueTracker
{
    public static class Message
    {
        public const string AlreadyLogged = "There is already a logged in user";
        public const string NotMatchingPasswords = "The provided passwords do not match";
        public const string UserExists = "A user with username {0} already exists";
        public const string RegisteredSuccessfully = "User {0} registered successfully";
        public const string UserNotFound = "A user with username {0} does not exist";
        public const string NotValidPassword = "The password is invalid for user {0}";
        public const string LoggedSuccessfully = "User {0} logged in successfully";
        public const string NoOneLogged = "There is no currently logged in user";
        public const string LoggedOutSuccessfully = "User {0} logged out successfully";
        public const string IssueCreated = "Issue {0} created successfully";
        public const string IssueIdNotFound = "There is no issue with ID {0}";
        public const string IssueDontBelong = "The issue with ID {0} does not belong to user {1}";
        public const string IssueRemoved = "Issue {0} removed";
        public const string IssueNotFound = "There is no issue with ID {0}";
        public const string CommentAddedToIssue = "Comment added successfully to issue {0}";
        public const string NoIssues = "No issues";
        public const string NoComments = "No comments";
        public const string NoTags = "There are no tags provided";
        public const string NoMatchingTags = "There are no issues matching the tags provided";
    }
}
