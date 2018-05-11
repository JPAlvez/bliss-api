namespace Bliss.Recruitment.Entities.SearchModel
{
    public class BaseSearchModel
    {
        /// <summary>
        /// The number of records to retrieve.
        /// </summary>
        public int Limit { get; set; }
        /// <summary>
        /// 0 based starting index of the first retrieved record.
        /// </summary>
        public int Offset { get; set; }
        /// <summary>
        /// Field to search for the filter pattern on "question" and "choice" properties.
        /// </summary>
        public string Filter { get; set; }
    }
}
