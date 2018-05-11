using Bliss.Recruitment.Entities.RequestModel;
using Bliss.Recruitment.Entities.ResultModel;
using Bliss.Recruitment.Entities.SearchModel;
using System.Collections.Generic;

namespace Bliss.Recruitment.Business.Interfaces
{
    public interface IQuestionBc
    {
        /// <summary>
        /// Get questions by model.
        /// </summary>
        /// <param name="searchModel">A model for search questions. Contains limit, offset and filter properties.</param>
        /// <returns>Returns a List for QuestionResponseModel for every question.</returns>
        IEnumerable<QuestionResponseModel> GetSearchQuery(BaseSearchModel searchModel);
        /// <summary>
        /// Get a question by its Id.
        /// </summary>
        /// <param name="id">Id of question.</param>
        /// <returns>Returns a QuestionResponseModel.</returns>
        QuestionResponseModel GetById(long id);
        /// <summary>
        /// Create a question.
        /// </summary>
        /// <param name="requestModel">A model for create new question.</param>
        /// <returns>Returns a QuestionResponseModel.</returns>
        QuestionResponseModel CreateQuestion(QuestionRequestModel requestModel);
        /// <summary>
        /// Get questions by model.
        /// </summary>
        /// <param name="searchModel">A model for update a question.</param>
        /// <returns>Returns a QuestionResponseModel.</returns>
        QuestionResponseModel UpdateQuestion(QuestionResponseModel model);
    }
}
