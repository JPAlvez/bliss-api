using Bliss.Recruitment.Entities.RequestModel;

namespace Bliss.Recruitment.Business.Interfaces
{
    public interface IShareBc
    {
        /// <summary>
        /// Share a question by model.
        /// </summary>
        /// <param name="searchModel">A model for send question. Contains the destination email and its content to send</param>
        /// <returns>Returns a boolean if email was sent.</returns>
        bool ShareQuestion(ShareRequestModel requestModel);
    }
}
