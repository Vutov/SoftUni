namespace BugTracker.RestServices.Models.ViewModels
{
    abstract public class CreateViewModel
    {
        public int Id { get; set; }

        public string Message { get; set; }
    }
}