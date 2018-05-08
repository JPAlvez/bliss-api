namespace Bliss.Recruitment.Entities
{
    public class QuestionChoice
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Votes { get; set; }

        public long QuestionId { get; set; }
        public virtual Question Question { get; set; }
    }
}
