using Bliss.Recruitment.Data.Core;
using Bliss.Recruitment.Entities;
using Bliss.Recruitment.Entities.SearchModel;
using System;
using System.Collections.Generic;

namespace Bliss.Recruitment.Data.Interfaces
{
    public interface IQuestionRepository : IBaseRepository<Question>, IDisposable
    {
        IEnumerable<Question> GetSearchQuery(BaseSearchModel searchModel);
        Question GetById(long id);
    }
}
