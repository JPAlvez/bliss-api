namespace Bliss.Recruitment.Entities.SearchModel
{
    public class BaseSearchModel
    {
        public int Limit { get; set; }
        public int Offset { get; set; }
        public string Filter { get; set; }
    }
}
