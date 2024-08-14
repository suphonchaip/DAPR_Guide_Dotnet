namespace OrderSubscriber.Models
{
    public class CheckOutOrder
    {
        public Guid Id { get; set; } = Guid.Empty;

        public string Name { get; set; } = string.Empty;

        public DateTime TimeStamp { get; set; } = DateTime.Now;
    }
}
