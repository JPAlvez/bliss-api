using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Bliss.Recruitment.Email
{
    public class EmailDataAgent : IEmailDataAgent
    {
        private const string    EMAIL_CLIENT_HOST_ADDRESS = "smtp.gmail.com";
        private const int       EMAIL_CLIENT_HOST_PORT = 587;
        private const string    EMAIL_CLIENT_USERNAME = "blissnoreply2018@gmail.com";
        private const string    EMAIL_CLIENT_PASSWORD = "blisstest2018";
        private const int       EMAIL_CLIENT_TIMEOUT_MILLISECONDS = 10000;

        private const string    EMAIL_CLIENT_DISPLAY_NAME = "Anonymous";

        public EmailDataAgent()
        {

        }

        public virtual bool Send(IEnumerable<string> to, IEnumerable<string> cc, IEnumerable<string> bcc, string subject, string body)
        {
            var client = new SmtpClient(
                EMAIL_CLIENT_HOST_ADDRESS,
                EMAIL_CLIENT_HOST_PORT
                );

            client.EnableSsl = true;

            //Authentication
            string username = EMAIL_CLIENT_USERNAME;
            string password = EMAIL_CLIENT_PASSWORD;

            if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password))
            {
                client.Credentials = new NetworkCredential(username, password);
            }

            var mail = new MailMessage
            {
                From = new MailAddress(EMAIL_CLIENT_USERNAME, EMAIL_CLIENT_DISPLAY_NAME),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };

            foreach (var email in to.Distinct().Where(x => !string.IsNullOrWhiteSpace(x)))
            {
                mail.To.Add(email);
            }

            if (cc != null)
            {
                foreach (var email in cc.Distinct().Where(x => !string.IsNullOrWhiteSpace(x)))
                {
                    if (!to.Contains(email))
                    {
                        mail.CC.Add(email);
                    }
                }
            }

            if (bcc != null)
            {
                foreach (var email in bcc.Distinct().Where(x => !string.IsNullOrWhiteSpace(x)))
                {
                    if (!to.Contains(email) && !cc.Contains(email))
                    {
                        mail.Bcc.Add(email);
                    }
                }
            }

            try
            {
                client.Send(mail);
                return true;
            }
            catch (Exception exception)
            {
                return false;
            }

        }
    }
}
