using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bliss.Recruitment.Entities.RequestModel
{
    public class QuestionRequestModel
    {
        [JsonProperty(PropertyName = "id")]
        public long? Id { get; set; }
        [Required]
        [JsonProperty(PropertyName = "question")]
        public string Question { get; set; }
        [Required]
        [JsonProperty(PropertyName = "image_url")]
        public string ImageUrl { get; set; }
        [Required]
        [JsonProperty(PropertyName = "thumb_url")]
        public string ThumbUrl { get; set; }
        [Required]
        [JsonProperty(PropertyName = "choices")]
        public IEnumerable<string> Choices { get; set; }
    }
}
