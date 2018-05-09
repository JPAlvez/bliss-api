using Bliss.Recruitment.Data.Core;
using Bliss.Recruitment.Entities;
using System;

namespace Bliss.Recruitment.Data.Interfaces
{
    public interface IQuestionChoiceRepository : IBaseRepository<QuestionChoice>, IDisposable
    {
        QuestionChoice GetByQuestionAndName(long questionId, string name);
    }
}
