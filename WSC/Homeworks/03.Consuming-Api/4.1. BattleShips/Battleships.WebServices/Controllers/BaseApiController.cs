namespace Battleships.WebServices.Controllers
{
    using System.Web.Http;

    using Battleships.Data;

    public abstract class BaseApiController : ApiController
    {
        private IBattleshipsData data;
        
        protected BaseApiController(IBattleshipsData data)
        {
            this.data = data;
        }

        protected IBattleshipsData Data
        {
            get
            {
                return this.data;
            }
        }
    }
}