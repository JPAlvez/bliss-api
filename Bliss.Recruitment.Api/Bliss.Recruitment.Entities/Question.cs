using System;
using System.Collections.Generic;

namespace Bliss.Recruitment.Entities
{
    public class Question
    {
        public long Id { get; set; }
        public string QuestionDescription { get; set; }
        public string ImageUrl { get; set; }
        public string ThumbUrl { get; set; }
        public DateTime PublishedAt { get; set; }

        public virtual ICollection<QuestionChoice> QuestionChoices { get; set; } = new HashSet<QuestionChoice>();
    }
}
