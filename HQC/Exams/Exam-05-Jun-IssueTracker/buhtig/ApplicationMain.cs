namespace IssueTracker
{
    using System.Globalization;
    using System.Threading;
    using Core;
    using Models;

    public class ApplicationMain
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var issueTrackerData = new IssueTrackerData();

            // DI: Refactored the code in different classes.
            var issueTracker = new IssueTracker(issueTrackerData);

            // DI: Refactored the code in different classes.
            var dispacher = new Dispatcher(issueTracker);

            // DI: Refactored the code in different classes.
            var engine = new Engine(dispacher);

            engine.Run();
        }
    }
}
