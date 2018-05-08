using Bliss.Recruitment.Data.Context;
using Bliss.Recruitment.Data.Core;
using Bliss.Recruitment.Data.Interfaces;
using Bliss.Recruitment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bliss.Recruitment.Data.Repositories
{
    public class QuestionRepository : BaseRepository<Question>, IQuestionRepository, IDisposable
    {
        public QuestionRepository(BlissContext context)
            : base(context)
        {
        }

        public IEnumerable<Question> GetAll()
        {
            return Query.ToList();
        }

    }
}
