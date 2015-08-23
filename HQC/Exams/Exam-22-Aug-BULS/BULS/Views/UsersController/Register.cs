namespace BangaloreUniversityLearningSystem.Views.UsersController
{
    using System.Text;
    using Models;
    using Utilities;

    public class Register : BaseView
    {
        public Register(User user)
            : base(user)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            viewResult.AppendFormat(Message.UserRegisteredSuccessfully, (this.Model as User).Username).AppendLine();
        }
    }
}