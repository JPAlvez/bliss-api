using Bliss.Recruitment.Api.Core;
using Bliss.Recruitment.Business.Components;
using Bliss.Recruitment.Business.Interfaces;
using Bliss.Recruitment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Bliss.Recruitment.Api.Controllers
{
    [RoutePrefix("api/questions")]
    public class QuestionsController : BaseApiController
    {
        private IQuestionBc questionBc;

        public QuestionsController()
        {
            this.questionBc = new QuestionBc();
        }

        [HttpGet]
        [Route("all")]
        public async Task<IHttpActionResult> GetAll(
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return await ExecuteAsync<IHttpActionResult>(() =>
            {
                Question test = new Question
                {
                    QuestionDescription = "<JSON> ... "
                };
                return Ok(test);

            }, cancellationToken);
        }
    }
}