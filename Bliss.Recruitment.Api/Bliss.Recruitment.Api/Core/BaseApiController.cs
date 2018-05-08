using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Bliss.Recruitment.Api.Core
{
    public abstract class BaseApiController : ApiController
    {
        [ApiExplorerSettings(IgnoreApi = true)]
        protected async Task<T> ExecuteAsync<T>(Func<T> action, CancellationToken cancellationToken)
        {
            return await Task<T>.Factory.StartNew(action, cancellationToken);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        protected async Task ExecuteAsync(Action action, CancellationToken cancellationToken)
        {
            await Task.Factory.StartNew(action, cancellationToken);
        }
    }
}