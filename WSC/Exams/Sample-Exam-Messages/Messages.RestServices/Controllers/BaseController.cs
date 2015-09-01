namespace Messages.RestServices.Controllers
{
    using System.Web.Http;
    using Data;

    public class BaseController : ApiController
    {
        public BaseController()
        {
            this.Data = new MessagesDbContext();
        }

        public MessagesDbContext Data { get; set; }
    }
}
