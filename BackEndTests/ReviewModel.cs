namespace BackEndTests
{
    public class ReviewModel
    {
        public string Comment { get; set; }
        public string Title { get; set; }
        public int Rating { get; set; }

        public ReviewModel(string comment, string title, int rating)
        {
            Comment = comment; 
            Title = title;
            Rating = rating;
        }
    }
}