namespace BangaloreUniversityLearningSystem.Views.UsersController
{
    using System.Text;
    using Models;
    using Utilities;

    public class Logout : BaseView
    {
        public Logout(User user)
            : base(user)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            viewResult.AppendFormat(Message.UserLoggedOutSuccessfully, (this.Model as User).Username).AppendLine();
        }
    }
}