using MvcNet7.Models;

namespace MvcNet7.Dto
{
    public class OrderDto
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }
        //public List<Customer> Customer { get; set; } // One Order One Customer

        public int ProductId { get; set; }
        //public List<Product> Product { get; set; } // One Order One Product
        public int Amount { get; set; }
        public DateTime OrderDate { get; set; }
    }

    public class OrderViewDto : OrderDto
    {
        public string CustomerName { get; set; }
        public string ProductName { get; set; }
    }
}
