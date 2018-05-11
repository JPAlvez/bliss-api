using Bliss.Recruitment.Business.Components;
using Bliss.Recruitment.Business.Interfaces;
using Bliss.Recruitment.Entities.RequestModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bliss.Recruitment.Tests.Business
{
    [TestClass]
    public class ShareBcTests
    {
        private IShareBc shareBc;

        [TestInitialize]
        public void Init()
        {
            shareBc = new ShareBc();
        }

        [TestMethod]
        public void ShareBcTests_ShareQuestion()
        {
            var shareRequestModel = new ShareRequestModel
            {
                DestinationEmail = "jalves@alter-solutions.com",
                ContentUrl = $"<h2>Share Question</h2><p style='font-size: 1.2em;'> (Question Example)</p>"
            };

            var share = shareBc.ShareQuestion(shareRequestModel);
            Assert.IsTrue(share);
        }
    }
}
