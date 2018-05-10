using Bliss.Recruitment.Business.Components;
using Bliss.Recruitment.Business.Interfaces;
using Bliss.Recruitment.Common.Exceptions;
using Bliss.Recruitment.Entities;
using Bliss.Recruitment.Entities.RequestModel;
using Bliss.Recruitment.Entities.ResultModel;
using Bliss.Recruitment.Entities.SearchModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bliss.Recruitment.Tests.Business
{
    [TestClass]
    public class QuestionBcTests
    {
        private IQuestionBc questionBc;

        [TestInitialize]
        public void Init()
        {
            questionBc = new QuestionBc();
        }

        [TestMethod]
        public void QuestionBcTests_AddQuestion()
        {
            var random = TestUtils.RandomString(10);
            var question = new QuestionRequestModel
            {
                Question = $"Random question {random} with choice (Add)",
                ImageUrl = "https://www.google.pt/search?q=image",
                ThumbUrl = "https://www.google.pt/search?q=thumb",
                Choices = new[] { $"choice1_{random}", $"choice2_{random}", $"choice3_{random}" }
            };

            var dbQuestion = questionBc.CreateQuestion(question);
            Assert.IsTrue(dbQuestion.Id > 0);
        }

        [TestMethod]
        public void QuestionBcTests_GetQuestion()
        {
            var random = TestUtils.RandomString(10);
            var question = new QuestionRequestModel
            {
                Question = $"Random question {random} with choice (Get)",
                ImageUrl = "https://www.google.pt/search?q=image",
                ThumbUrl = "https://www.google.pt/search?q=thumb",
                Choices = new[] { $"choice1_{random}", $"choice2_{random}", $"choice3_{random}" }
            };

            var dbQuestion = questionBc.CreateQuestion(question);
            Assert.IsNotNull(questionBc.GetById(dbQuestion.Id));
        }

        [TestMethod]
        [ExpectedException(typeof(BlissException))]
        public void QuestionBcTests_GetNonExistingQuestion()
        {
            var question = questionBc.GetById(0);
        }

        [TestMethod]
        public void QuestionBcTests_GetAllQuestions()
        {
            var random = TestUtils.RandomString(10);
            var question = new QuestionRequestModel
            {
                Question = $"Random question {random} with choice (GetAll)",
                ImageUrl = "https://www.google.pt/search?q=image",
                ThumbUrl = "https://www.google.pt/search?q=thumb",
                Choices = new[] { $"choice1_{random}", $"choice2_{random}", $"choice3_{random}" }
            };

            questionBc.CreateQuestion(question);

            var search = new BaseSearchModel
            {
                Limit = 1,
                Offset = 0,
                Filter = random
            };

            var result = questionBc.GetSearchQuery(search);
            Assert.IsTrue(result.Count() >= 1);

            var choices = result.FirstOrDefault().Choices;
            Assert.IsNotNull(choices);
            Assert.IsTrue(choices.Count() > 1);
        }

        [TestMethod]
        public void QuestionBcTests_UpdateQuestion()
        {
            //var random = TestUtils.RandomString(10);
            //var search = new BaseSearchModel
            //{
            //    Limit = 1,
            //    Offset = 0
            //};

            //var result = questionBc.GetSearchQuery(search);

            //if (!result.Any())
            //{
            //    Assert.Inconclusive();
            //}
            //else
            //{
            //    var dbQuestion = result.FirstOrDefault();
            //    var original = dbQuestion.Question;

            //    dbQuestion.Id = dbQuestion.Id;
            //    dbQuestion.Question = $"Updated description {random}";
            //    dbQuestion.Choices = new QuestionChoiceResponseModel[]
            //    {
            //        new QuestionChoiceResponseModel
            //        {
            //            Name = $"choice_{random}",
            //            Votes = 1
            //        }
            //    };

            //    var updated = questionBc.UpdateQuestion(dbQuestion);
            //    Assert.AreNotEqual(original, updated.Question);
            //}

            var random = TestUtils.RandomString(10);
            var question = new QuestionRequestModel
            {
                Question = $"Random question {random} with choice (Get)",
                ImageUrl = "https://www.google.pt/search?q=image",
                ThumbUrl = "https://www.google.pt/search?q=thumb",
                Choices = new[] { $"choice1_{random}", $"choice2_{random}", $"choice3_{random}" }
            };

            var dbQuestion = questionBc.CreateQuestion(question);
            Assert.IsNotNull(questionBc.GetById(dbQuestion.Id));

            var original = dbQuestion.Question;

            dbQuestion.Id = dbQuestion.Id;
            dbQuestion.Question = $"Updated description {random}";
            dbQuestion.Choices = new QuestionChoiceResponseModel[]
            {
                new QuestionChoiceResponseModel
                {
                    Name = $"choice_{random}",
                    Votes = 1
                }
            };

            var updated = questionBc.UpdateQuestion(dbQuestion);
            Assert.AreNotEqual(original, updated.Question);
        }

        [TestMethod]
        [ExpectedException(typeof(BlissException))]
        public void QuestionBcTests_UpdateNonExistingQuestion()
        {
            var question = new QuestionResponseModel
            {
                Id = 0
            };
            var updated = questionBc.UpdateQuestion(question);
        }

    }
}
