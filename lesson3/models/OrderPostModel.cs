namespace lesson3.models
{
    public class OrderPostModel
    {
        public int OrderId { get; set; }
        public string NameClient { get; set; }
        public DateTime Date { get; set; }
        public int DosesCount { get; set; }
    }
}
