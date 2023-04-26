namespace MvcNet7.Models
{
    public class CustomerOrder
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Customer Customer { get; set; }
        public Order Order { get; set; }
    }
}
