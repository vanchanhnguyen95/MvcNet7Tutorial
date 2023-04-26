namespace MvcNet7.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        //public int OrderId { get; set; }
        public ICollection<Order> Orders { get; set; } // One  Customer Many  Order

        //public ICollection<CustomerOrder> CustomerOrders { get; set; }
    }
}
