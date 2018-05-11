using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bliss.Recruitment.Entities.RequestModel
{
    public class QuestionRequestModel
    {
        /// <summary>
        /// Id of question.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public long? Id { get; set; }
        /// <summary>
        /// Name of question.
        /// </summary>
        [Required]
        [JsonProperty(PropertyName = "question")]
        public string Question { get; set; }
        /// <summary>
        /// Url image of question.
        /// </summary>
        [Required]
        [JsonProperty(PropertyName = "image_url")]
        public string ImageUrl { get; set; }
        /// <summary>
        /// Url thumbnail of question
        /// </summary>
        [Required]
        [JsonProperty(PropertyName = "thumb_url")]
        public string ThumbUrl { get; set; }
        /// <summary>
        /// List of strings for describe a choice.
        /// </summary>
        [Required]
        [JsonProperty(PropertyName = "choices")]
        public IEnumerable<string> Choices { get; set; }
    }
}
