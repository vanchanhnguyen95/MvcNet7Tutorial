using System.Diagnostics.Metrics;

namespace MvcNet7.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; } // One Order One Customer

        public int ProductId { get; set; }
        public Product Product { get; set; } // One Order One Product

        //public ICollection<CustomerOrder> CustomerOrders { get; set; }
        //public ICollection<OrderProduct> OrderProducts { get; set; }//One Order Many Product

        //public virtual Product Product { get; set; }
        //public ICollection<OrderProduct> OrderProduct { get; set; }
        public int Amount { get; set; }
        public DateTime OrderDate { get; set; }

        //public ICollection<Product> Products { get; set; }
    }
}
