namespace BangaloreUniversityLearningSystem.Views.UsersController
{
    using System.Text;
    using Models;
    using Views;

    class MockedView: BaseView
    {
        public MockedView(User user)
            : base(user)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            viewResult.Append("mocked");
        }


    }
}
