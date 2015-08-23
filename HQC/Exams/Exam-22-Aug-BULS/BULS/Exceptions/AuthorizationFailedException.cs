namespace BangaloreUniversityLearningSystem.Exceptions
{
    using System;

    public class AuthorizationFailedException : Exception
    {
        public AuthorizationFailedException(string message)
            : base(message)
        {
        }
    }
}
