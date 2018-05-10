using Bliss.Recruitment.Data.Core;
using Bliss.Recruitment.Entities;
using System;
using System.Collections.Generic;

namespace Bliss.Recruitment.Data.Interfaces
{
    public interface IQuestionChoiceRepository : IBaseRepository<QuestionChoice>, IDisposable
    {
        void DeleteByQuestionId(long questionId);
    }
}
