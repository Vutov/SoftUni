namespace BangaloreUniversityLearningSystem.Views.UsersController
{
    using System.Text;
    using Models;
    using Utilities;

    public class Login : BaseView
    {
        public Login(User user)
            : base(user)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            viewResult.AppendFormat(Message.UserLoggedSuccessfully, (this.Model as User).Username).AppendLine();
        }
    }
}