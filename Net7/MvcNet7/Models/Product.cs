namespace MvcNet7.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //public Order Order { get; set; } // One Product Many Order Cach 1
        public ICollection<Order> Orders { get; set; } // One Product Many Order// Cach 2


        //public ICollection<OrderProduct> OrderProducts { get; set; }
        //public Category Category { get; set; }// One Product One Category
        public virtual  Category Category { get; set; }
        public int CategoryId { get; set; }// One Category One Product

        public int Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }


        //public virtual Order Order { get; set; }
    }
}
