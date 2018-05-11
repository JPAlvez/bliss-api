using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Bliss.Recruitment.Entities.RequestModel
{
    public class ShareRequestModel
    {
        /// <summary>
        /// Email to send.
        /// </summary>
        [Required]
        [JsonProperty("destination_email")]
        public string DestinationEmail { get; set; }
        /// <summary>
        /// Url content of email.
        /// </summary>
        [Required]
        [JsonProperty("content_url")]
        public string ContentUrl { get; set; }
    }
}
