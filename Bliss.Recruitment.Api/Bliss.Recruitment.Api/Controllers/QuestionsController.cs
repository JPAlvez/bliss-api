using Bliss.Recruitment.Api.Core;
using Bliss.Recruitment.Business.Components;
using Bliss.Recruitment.Business.Interfaces;
using Bliss.Recruitment.Entities;
using Bliss.Recruitment.Entities.RequestModel;
using Bliss.Recruitment.Entities.ResultModel;
using Bliss.Recruitment.Entities.SearchModel;
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
        [Route("")]
        public async Task<IHttpActionResult> GetAllQuestions(
            [FromUri] BaseSearchModel searchModel,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return await ExecuteAsync<IHttpActionResult>(() =>
            {
                return Ok(questionBc.GetSearchQuery(searchModel));
            }, cancellationToken);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IHttpActionResult> GetQuestion(
            long id,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return await ExecuteAsync<IHttpActionResult>(() =>
            {
                return Ok(questionBc.GetById(id));
            }, cancellationToken);
        }

        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> CreateQuestion(
            QuestionRequestModel requestModel,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return await ExecuteAsync<IHttpActionResult>(() =>
            {
                if (!ModelState.IsValid)
                {
                    //throw new GalpBusinessException(this.GetModelErrors(ModelState));
                    throw new Exception("ModelErrors");
                }

                return Ok(questionBc.CreateQuestion(requestModel));
            }, cancellationToken);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IHttpActionResult> UpdateQuestion(
            long id,
            QuestionResponseModel model,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return await ExecuteAsync<IHttpActionResult>(() =>
            {
                return Ok(questionBc.UpdateQuestion(model));
            }, cancellationToken);
        }

    }
}