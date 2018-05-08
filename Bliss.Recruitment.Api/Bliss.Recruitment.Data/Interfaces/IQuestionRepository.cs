using Bliss.Recruitment.Data.Core;
using Bliss.Recruitment.Entities;
using System;
using System.Collections.Generic;

namespace Bliss.Recruitment.Data.Interfaces
{
    public interface IQuestionRepository : IBaseRepository<Question>, IDisposable
    {
        IEnumerable<Question> GetAll();
    }
}
