namespace BangaloreUniversityLearningSystem.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// Basic implementation for every router.
    /// </summary>
    public interface IRouter
    {
        /// <summary>
        /// Name of the controller witch is used in the router.
        /// </summary>
        string ControllerName { get; }

        /// <summary>
        /// Name of the action witch is used by the router.
        /// </summary>
        string ActionName { get; }

        /// <summary>
        /// Data parameters witch are used by the router.
        /// </summary>
        IDictionary<string, string> Parameters { get; }
    }
}
