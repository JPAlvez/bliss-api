using Newtonsoft.Json;

namespace Bliss.Recruitment.Entities.ResponseModel
{
    public class BaseExceptionResponseModel
    {
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
    }
}
