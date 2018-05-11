using Bliss.Recruitment.Business.Interfaces;
using Bliss.Recruitment.Common.Exceptions;
using Bliss.Recruitment.Data.Context;
using Bliss.Recruitment.Data.Interfaces;
using Bliss.Recruitment.Data.Repositories;
using Bliss.Recruitment.Entities;
using Bliss.Recruitment.Entities.RequestModel;
using Bliss.Recruitment.Entities.ResultModel;
using Bliss.Recruitment.Entities.SearchModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bliss.Recruitment.Business.Components
{
    public class QuestionBc : IQuestionBc
    {
        private IQuestionRepository questionRepo;
        private IQuestionChoiceRepository questionChoiceRepo;
        private BlissContext context = new BlissContext();

        public QuestionBc()
        {
            this.questionRepo = new QuestionRepository(context);
            this.questionChoiceRepo = new QuestionChoiceRepository(context);
        }

        public IEnumerable<QuestionResponseModel> GetSearchQuery(BaseSearchModel searchModel)
        {
            return questionRepo.GetSearchQuery(searchModel).Select(y => MapToQuestionModel(y));
        }

        public QuestionResponseModel GetById(long id)
        {
            var question = questionRepo.GetById(id);
            if (question == null)
            {
                throw new BlissException(CommonExceptionResources.QuestionNotFound);
            }

            return MapToQuestionModel(question);
        }

        public QuestionResponseModel CreateQuestion(QuestionRequestModel requestModel)
        {
            var newQuestion = new Question
            {
                QuestionDescription = requestModel.Question,
                ImageUrl = requestModel.ImageUrl,
                ThumbUrl = requestModel.ThumbUrl,
                PublishedAt = DateTime.Now
            };

            foreach (var choice in requestModel.Choices.Distinct()) // Distinct - If there are choices with same name
            {
                newQuestion.QuestionChoices.Add(new QuestionChoice
                {
                    Name = choice,
                    Votes = 0
                });
            }

            var dbQuestion = questionRepo.Add(newQuestion);
            questionRepo.Save();

            return MapToQuestionModel(dbQuestion);
        }
        
        public QuestionResponseModel UpdateQuestion(QuestionResponseModel model)
        {
            var dbQuestion = questionRepo.GetById(model.Id);
            if (dbQuestion == null)
            {
                throw new BlissException(CommonExceptionResources.QuestionNotFound);
            }

            // Delete old choices
            questionChoiceRepo.DeleteByQuestionId(dbQuestion.Id);
            questionRepo.Save();
            
            questionRepo.TrackExisting(dbQuestion);

            // Add new choices
            MapQuestion(dbQuestion, model);
            questionRepo.Save();

            model.PublishedAt = dbQuestion.PublishedAt;
            return model;
        }

        #region Private methods

        private void MapQuestion(Question dbQuestion, QuestionResponseModel model)
        {
            dbQuestion.QuestionDescription = model.Question;
            dbQuestion.ImageUrl = model.ImageUrl;
            dbQuestion.ThumbUrl = model.ThumbUrl;
            dbQuestion.PublishedAt = DateTime.Now;

            foreach (var choice in model.Choices)
            {
                questionChoiceRepo.Add(new QuestionChoice
                {
                    QuestionId = dbQuestion.Id,
                    Name = choice.Name,
                    Votes = choice.Votes
                });
            }
        }

        private QuestionResponseModel MapToQuestionModel(Question question)
        {
            return new QuestionResponseModel
            {
                Id = question.Id,
                Question = question.QuestionDescription,
                ImageUrl = question.ImageUrl,
                ThumbUrl = question.ThumbUrl,
                PublishedAt = question.PublishedAt,
                Choices = question.QuestionChoices?.Select(qc => new QuestionChoiceResponseModel
                {
                    Name = qc.Name,
                    Votes = qc.Votes
                })
            };
        }

        #endregion

    }
}
