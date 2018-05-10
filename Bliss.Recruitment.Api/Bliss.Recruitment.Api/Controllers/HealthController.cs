using Bliss.Recruitment.Api.Core;
using Bliss.Recruitment.Entities.ResponseModel;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace Bliss.Recruitment.Api.Controllers
{
    [RoutePrefix("api/health")]
    public class HealthController : BaseApiController
    {
        public HealthController()
        {
        }

        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> GetHealthStatus(
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return await ExecuteAsync<IHttpActionResult>(() =>
            {
                return Ok(new BaseExceptionResponseModel
                {
                    Status = "OK"
                });

            }, cancellationToken);
        }
    }
}
