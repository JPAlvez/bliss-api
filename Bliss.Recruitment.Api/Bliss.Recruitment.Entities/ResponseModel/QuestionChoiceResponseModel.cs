using Newtonsoft.Json;

namespace Bliss.Recruitment.Entities.ResultModel
{
    public class QuestionChoiceResponseModel
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "votes")]
        public int Votes { get; set; }
    }
}
