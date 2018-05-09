using Bliss.Recruitment.Data.Context;
using Bliss.Recruitment.Data.Core;
using Bliss.Recruitment.Data.Interfaces;
using Bliss.Recruitment.Entities;
using Bliss.Recruitment.Entities.SearchModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Bliss.Recruitment.Data.Repositories
{
    public class QuestionRepository : BaseRepository<Question>, IQuestionRepository, IDisposable
    {
        public QuestionRepository(BlissContext context)
            : base(context)
        {
        }

        public IEnumerable<Question> GetSearchQuery(BaseSearchModel searchModel)
        {
            var query = Query.Include(x => x.QuestionChoices);

            if (!string.IsNullOrWhiteSpace(searchModel.Filter))
            {
                string lowercaseFilter = searchModel.Filter.ToLower();

                query = query.Where(x => x.QuestionDescription.Contains(lowercaseFilter) 
                                    || x.QuestionChoices.Any(qc => qc.Name.Contains(lowercaseFilter)));
            }

            return query
                .OrderBy(o => o.Id)
                .Skip(searchModel.Offset)
                .Take(searchModel.Limit)
                .ToArray();
        }

        public Question GetById(long id)
        {
            return Query.Include(y => y.QuestionChoices).Where(x => x.Id == id).FirstOrDefault();
        }

    }
}
