using Bliss.Recruitment.Business.Interfaces;
using Bliss.Recruitment.Data.Context;
using Bliss.Recruitment.Data.Interfaces;
using Bliss.Recruitment.Data.Repositories;
using Bliss.Recruitment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bliss.Recruitment.Business.Components
{
    public class QuestionBc : IQuestionBc
    {
        private IQuestionRepository questionRepo;
        private BlissContext context = new BlissContext();

        public QuestionBc()
        {
            this.questionRepo = new QuestionRepository(context);
        }

        public IEnumerable<Question> GetAll()
        {
            return questionRepo.GetAll();
        }

        public Question Add(Question question)
        {
            var dbSimpleTable = questionRepo.Add(question);
            questionRepo.Save();
            return dbSimpleTable;
        }

        public Question GetById(long id)
        {
            var question = questionRepo.Get(id);
            if (question == null)
            {
                throw new Exception("Entity does not exist.");
            }
            return question;
        }

        public Question Edit(Question question)
        {
            questionRepo.TrackExisting(question);
            questionRepo.Save();
            return question;
        }

        public void Delete(long id)
        {
            var question = questionRepo.Get(id);
            if (question != null)
            {
                questionRepo.Delete(question);
                questionRepo.Save();
            }
            else
            {
                throw new Exception("Entity does not exist.");
            }
        }
    }
}
