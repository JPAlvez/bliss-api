using Bliss.Recruitment.Business.Interfaces;
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
            return questionRepo.GetSearchQuery(searchModel).Select(y => new QuestionResponseModel
            {
                Id = y.Id,
                Question = y.QuestionDescription,
                ImageUrl = y.ImageUrl,
                ThumbUrl = y.ThumbUrl,
                PublishedAt = y.PublishedAt,
                Choices = y.QuestionChoices?.Select(qc => new QuestionChoiceResponseModel
                {
                    Name = qc.Name,
                    Votes = qc.Votes
                })
            });
        }

        public QuestionResponseModel GetById(long id)
        {
            var question = questionRepo.GetById(id);
            if (question == null)
            {
                throw new Exception("Question does not exist."); // CustomException ?
            }

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

            return new QuestionResponseModel
            {
                Id = dbQuestion.Id,
                Question = dbQuestion.QuestionDescription,
                ImageUrl = dbQuestion.ImageUrl,
                ThumbUrl = dbQuestion.ThumbUrl,
                PublishedAt = dbQuestion.PublishedAt,
                Choices = dbQuestion.QuestionChoices?.Select(qc => new QuestionChoiceResponseModel
                {
                    Name = qc.Name,
                    Votes = qc.Votes
                })
            };
        }
        
        public QuestionResponseModel UpdateQuestion(QuestionResponseModel model)
        {
            var dbQuestion = questionRepo.GetById(model.Id);
            if (dbQuestion == null)
            {
                throw new Exception("Question does not exist."); // CustomException ?
            }

            questionRepo.TrackExisting(dbQuestion);
            MapQuestion(dbQuestion, model);
            questionRepo.Save();

            return model;
        }

        private void MapQuestion(Question dbQuestion, QuestionResponseModel model)
        {
            dbQuestion.QuestionDescription = model.Question;
            dbQuestion.ImageUrl = model.ImageUrl;
            dbQuestion.ThumbUrl = model.ThumbUrl;
            dbQuestion.PublishedAt = DateTime.Now;

            foreach (var choice in model.Choices)
            {
                //var dbQuestionChoice = questionChoiceRepo.GetByQuestionAndName(dbQuestion.Id, choice.Name);
                var dbQuestionChoice = dbQuestion.QuestionChoices.Where(qc => qc.Name == choice.Name).FirstOrDefault();
                if (dbQuestionChoice != null)
                {
                    //questionChoiceRepo.TrackExisting(dbQuestionChoice);
                    dbQuestionChoice.Votes = choice.Votes;
                }
                else
                {
                    dbQuestion.QuestionChoices.Add(new QuestionChoice
                    {
                        Name = choice.Name,
                        Votes = choice.Votes
                    });
                }
            }
        }
    }
}
