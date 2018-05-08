using Bliss.Recruitment.Entities;
using System.Collections.Generic;

namespace Bliss.Recruitment.Business.Interfaces
{
    public interface IQuestionBc
    {
        IEnumerable<Question> GetAll();
        Question GetById(long id);
        Question Edit(Question question);
        void Delete(long id);
        Question Add(Question question);
    }
}
