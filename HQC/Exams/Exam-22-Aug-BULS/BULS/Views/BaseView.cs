namespace BangaloreUniversityLearningSystem.Views
{
    using System.Text;
    using Interfaces;

    public abstract class BaseView : IView
    {
        protected BaseView(object model)
        {
            this.Model = model;
        }

        public object Model { get; private set; }

        public string Display()
        {
            var viewResult = new StringBuilder();
            this.BuildViewResult(viewResult);
            return viewResult.ToString().Trim();
        }

        protected virtual void BuildViewResult(StringBuilder viewResult)
        {
        }
    }
}
