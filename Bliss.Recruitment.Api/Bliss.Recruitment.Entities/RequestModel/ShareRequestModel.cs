using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Bliss.Recruitment.Entities.RequestModel
{
    public class ShareRequestModel
    {
        [Required]
        [JsonProperty(PropertyName = "destination_email")]
        public string DestinationEmail { get; set; }
        [Required]
        [JsonProperty(PropertyName = "content_url")]
        public string ContentUrl { get; set; }
    }
}
