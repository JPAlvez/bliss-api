using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Bliss.Recruitment.Entities.ResultModel
{
    public class QuestionResponseModel
    {
        [JsonProperty(PropertyName = "id")]
        public long Id { get; set; }
        [JsonProperty(PropertyName = "question")]
        public string Question { get; set; }
        [JsonProperty(PropertyName = "image_url")]
        public string ImageUrl { get; set; }
        [JsonProperty(PropertyName = "thumb_url")]
        public string ThumbUrl { get; set; }
        [JsonProperty(PropertyName = "published_at")]
        public DateTime PublishedAt { get; set; }
        [JsonProperty(PropertyName = "choices")]
        public IEnumerable<QuestionChoiceResponseModel> Choices { get; set; }
    }
}
