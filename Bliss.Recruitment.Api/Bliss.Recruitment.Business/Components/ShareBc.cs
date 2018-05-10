using Bliss.Recruitment.Business.Interfaces;
using Bliss.Recruitment.Common.Exceptions;
using Bliss.Recruitment.Email;
using Bliss.Recruitment.Entities.RequestModel;

namespace Bliss.Recruitment.Business.Components
{
    public class ShareBc : IShareBc
    {
        private IEmailDataAgent emailDataAgent;

        public ShareBc()
        {
            emailDataAgent = new EmailDataAgent();
        }

        public bool ShareQuestion(ShareRequestModel requestModel)
        {
            var sent = emailDataAgent.Send(new[] { requestModel.DestinationEmail }, null, null, "Share", requestModel.ContentUrl);
            if (sent)
            {
                return sent;
            }
            else
            {
                throw new BlissException(CommonExceptionResources.InvalidShare);
            }
        }
    }
}
