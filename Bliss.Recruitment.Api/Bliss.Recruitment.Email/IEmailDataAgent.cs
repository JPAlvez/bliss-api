using System.Collections.Generic;

namespace Bliss.Recruitment.Email
{
    public interface IEmailDataAgent
    {
        bool Send(
            IEnumerable<string> to, 
            IEnumerable<string> cc, 
            IEnumerable<string> bcc, 
            string subject, 
            string body
        );
    }
}
