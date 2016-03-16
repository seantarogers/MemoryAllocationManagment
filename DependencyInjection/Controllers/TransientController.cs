namespace DependencyInjection.Controllers
{
    using System.Web.Http;

    using DependencyInjection.QueryHandlers;

    [RoutePrefix("api/Transient")]
    public class TransientController : ApiController
    {
        private readonly ITransientQueryHandler transientQueryHandler;

        public TransientController(ITransientQueryHandler transientQueryHandler)
        {
            this.transientQueryHandler = transientQueryHandler;
        }

        [Route("")]
        public IHttpActionResult Get()
        {
            var customerDto = transientQueryHandler.Handle();
            return Ok(customerDto);
        }
    }
}
