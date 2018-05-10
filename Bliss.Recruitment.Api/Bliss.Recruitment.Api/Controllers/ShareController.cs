using Bliss.Recruitment.Api.Core;
using Bliss.Recruitment.Business.Components;
using Bliss.Recruitment.Business.Interfaces;
using Bliss.Recruitment.Common.Exceptions;
using Bliss.Recruitment.Entities.RequestModel;
using Bliss.Recruitment.Entities.ResponseModel;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace Bliss.Recruitment.Api.Controllers
{
    [RoutePrefix("api/share")]
    public class ShareController : BaseApiController
    {
        private IShareBc shareBc;

        public ShareController()
        {
            this.shareBc = new ShareBc();
        }

        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> ShareQuestion(
            [FromUri] ShareRequestModel requestModel,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return await ExecuteAsync<IHttpActionResult>(() =>
            {
                if (!ModelState.IsValid)
                {
                    throw new BlissException(CommonExceptionResources.AllFieldsMandatory);
                }

                var share = shareBc.ShareQuestion(requestModel);
                return Ok(new BaseExceptionResponseModel
                {
                    Status = "OK"
                });
            }, cancellationToken);
        }
    }
}
