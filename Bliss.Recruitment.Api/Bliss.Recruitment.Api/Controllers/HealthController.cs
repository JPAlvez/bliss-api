using Bliss.Recruitment.Api.Core;
using Bliss.Recruitment.Entities.ResponseModel;
using System;
using System.Net.Http;
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

        /// <summary>
        /// Get health status.
        /// </summary>
        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> GetHealthStatus(
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return await ExecuteAsync<IHttpActionResult>(() =>
            {
                // Random service state: 80% OK, 20% Unavailable
                var random = new Random().Next(0, 100);
                if (random < 20)
                {
                    return ResponseMessage(new HttpResponseMessage(System.Net.HttpStatusCode.ServiceUnavailable));
                }
                return Ok(new BaseExceptionResponseModel
                {
                    Status = "OK"
                });

            }, cancellationToken);
        }
    }
}
