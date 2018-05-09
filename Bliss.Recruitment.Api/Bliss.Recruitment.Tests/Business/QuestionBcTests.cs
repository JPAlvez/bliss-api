using Bliss.Recruitment.Business.Components;
using Bliss.Recruitment.Business.Interfaces;
using Bliss.Recruitment.Entities;
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
            //var random = new Random().Next(1, 99999);
            //var question = new Question
            //{
            //    QuestionDescription = $"Random question nr. {random}",
            //    ImageUrl = "https://www.google.pt/search?q=image",
            //    ThumbUrl = "https://www.google.pt/search?q=thumb",
            //    PublishedAt = DateTime.Now
            //};

            //var dbQuestion = questionBc.Add(question);
            //Assert.IsTrue(dbQuestion.Id > 0);
        }

        [TestMethod]
        public void QuestionBcTests_GetQuestion()
        {
            //var random = new Random().Next(1, 99999);
            //var question = new Question
            //{
            //    QuestionDescription = $"Random question nr. {random}",
            //    ImageUrl = "https://www.google.pt/search?q=image",
            //    ThumbUrl = "https://www.google.pt/search?q=thumb",
            //    PublishedAt = DateTime.Now
            //};

            //var dbQuestion = questionBc.Add(question);
            //Assert.IsNotNull(questionBc.GetById(dbQuestion.Id));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void QuestionBcTests_GetNonExistingQuestion()
        {
            //var question = questionBc.GetById(0);
        }

        [TestMethod]
        public void QuestionBcTests_GetAllQuestions()
        {
            //var random = new Random().Next(1, 99999);
            //var question = new Question
            //{
            //    QuestionDescription = $"Random question nr. {random}",
            //    ImageUrl = "https://www.google.pt/search?q=image",
            //    ThumbUrl = "https://www.google.pt/search?q=thumb",
            //    PublishedAt = DateTime.Now
            //};

            //questionBc.Add(question);
            //var result = questionBc.GetSearchQuery();
            //Assert.IsTrue(result.Count() >= 1);
        }

        [TestMethod]
        public void QuestionBcTests_EditQuestion()
        {
            //var random = new Random().Next(1, 99999);
            //var question = new Question
            //{
            //    QuestionDescription = $"Random question nr. {random}",
            //    ImageUrl = "https://www.google.pt/search?q=image",
            //    ThumbUrl = "https://www.google.pt/search?q=thumb",
            //    PublishedAt = DateTime.Now
            //};

            //var dbQuestion = questionBc.Add(question);
            //var original = dbQuestion.QuestionDescription;

            //dbQuestion.QuestionDescription = $"Updated description";

            //var result = questionBc.Edit(dbQuestion);
            //Assert.AreNotEqual(original, result.QuestionDescription);
        }

        [TestMethod]
        public void QuestionBcTests_DeleteQuestion()
        {
            //var random = new Random().Next(1, 99999);
            //var question = new Question
            //{
            //    QuestionDescription = $"Random question nr. {random}",
            //    ImageUrl = "https://www.google.pt/search?q=image",
            //    ThumbUrl = "https://www.google.pt/search?q=thumb",
            //    PublishedAt = DateTime.Now
            //};

            //var dbQuestion = questionBc.Add(question);

            //var deletedId = dbQuestion.Id;
            //questionBc.Delete(deletedId);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void QuestionBcTests_DeletenonExistingQuestion()
        {
            //questionBc.Delete(0);
        }

    }
}
