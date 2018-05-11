using System;
using System.Collections.Generic;

namespace Bliss.Recruitment.Entities.ResultModel
{
    public class QuestionResponseModel
    {
        /// <summary>
        /// Id of question.
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Name of question.
        /// </summary>
        public string Question { get; set; }
        /// <summary>
        /// Url image of question.
        /// </summary>
        public string ImageUrl { get; set; }
        /// <summary>
        /// Url thumbnail of question.
        /// </summary>
        public string ThumbUrl { get; set; }
        /// <summary>
        /// Published date of question.
        /// </summary>
        public DateTime PublishedAt { get; set; }
        /// <summary>
        /// List of strings for describe a choice.
        /// </summary>
        public IEnumerable<QuestionChoiceResponseModel> Choices { get; set; }
    }
}
