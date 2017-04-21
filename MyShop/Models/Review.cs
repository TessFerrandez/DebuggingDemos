namespace MyShop.Models
{
    public class Review
    {
        public string Quote { get; set; }
        public string Source { get; set; }
        public void Clear()
        {
            Quote = null;
            Source = null;
        }
        ~Review()
        {
            if (Quote.ToString() != string.Empty)
                Quote = null;
        }
    }
}