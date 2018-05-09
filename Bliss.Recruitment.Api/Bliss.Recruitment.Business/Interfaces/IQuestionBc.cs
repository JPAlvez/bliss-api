using Bliss.Recruitment.Entities;
using Bliss.Recruitment.Entities.RequestModel;
using Bliss.Recruitment.Entities.ResultModel;
using Bliss.Recruitment.Entities.SearchModel;
using System.Collections.Generic;

namespace Bliss.Recruitment.Business.Interfaces
{
    public interface IQuestionBc
    {
        IEnumerable<QuestionResponseModel> GetSearchQuery(BaseSearchModel searchModel);
        QuestionResponseModel GetById(long id);
        QuestionResponseModel CreateQuestion(QuestionRequestModel requestModel);
        QuestionResponseModel UpdateQuestion(QuestionResponseModel model);
    }
}
