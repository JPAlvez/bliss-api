using Bliss.Recruitment.Common.Exceptions;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace Bliss.Recruitment.Api
{
    public class BlissExceptionHandler : ExceptionFilterAttribute
    {
        public BlissExceptionHandler()
        {
        }

        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (!HandleException(actionExecutedContext.Exception, actionExecutedContext))
            {
                base.OnException(actionExecutedContext);
            }
        }

        protected virtual bool HandleException(Exception exception, HttpActionExecutedContext actionExecutedContext)
        {
            var blissException = exception as BlissException;
            if (blissException != null)
            {
                actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(
                    HttpStatusCode.BadRequest, new
                    {
                        Status = blissException.Message
                    }
                );
                return true;
            }
            return false;
        }
    }
}