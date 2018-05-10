using System;
using System.Collections.Generic;
using Bliss.Recruitment.Entities.RequestModel;

namespace Bliss.Recruitment.Business.Interfaces
{
    public interface IShareBc
    {
        bool ShareQuestion(ShareRequestModel requestModel);
    }
}
