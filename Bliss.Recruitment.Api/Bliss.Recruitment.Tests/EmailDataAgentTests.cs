using Bliss.Recruitment.Email;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Bliss.Recruitment.Tests
{
    [TestClass]
    public class EmailDataAgentTests
    {
        private IEmailDataAgent emailDataAgent;

        [TestInitialize]
        public void Init()
        {
            emailDataAgent = new EmailDataAgent();
        }

        [TestMethod]
        public void EmailDataAgentTests_SendEmail()
        {
            IEnumerable<string> to = new[] { "jalves@alter-solutions.com" };
            IEnumerable<string> cc = new[] { "j.alves@alter-solutions.com" };
            IEnumerable<string> bcc = new[] { "ja.lves@alter-solutions.com" };
            string subject = "Assunto Teste";
            string body = "@Teste@";

            var sent = emailDataAgent.Send(to, cc, bcc, subject, body);
            Assert.IsTrue(sent);
        }
    }
}
