using Bliss.Recruitment.Data.Context;
using Bliss.Recruitment.Data.Core;
using Bliss.Recruitment.Data.Interfaces;
using Bliss.Recruitment.Entities;
using System;
using System.Linq;

namespace Bliss.Recruitment.Data.Repositories
{
    public class QuestionChoiceRepository : BaseRepository<QuestionChoice>, IQuestionChoiceRepository, IDisposable
    {
        public QuestionChoiceRepository(BlissContext context)
            : base(context)
        {
        }

        public void DeleteByQuestionId(long questionId)
        {
            var choices = Query.Where(x => x.QuestionId == questionId).ToArray();
            foreach (var choice in choices)
            {
                Delete(choice);
            }
        }
    }
}
