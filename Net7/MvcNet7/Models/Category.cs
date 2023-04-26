using System.ComponentModel.DataAnnotations.Schema;

namespace MvcNet7.Models
{
    public class Category
    {
        public int Id { get; set; }
        //public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int ProductId { get; set; }// One Category One Product
        public virtual Product Product { get; set; }// One Category One Product
       
        //public ICollection<Order> Orders { get; set; } // One Product Many Order
        //public ICollection<Product>? Product { get; set; }

        //public ICollection<Product> Products { get; set; }
    }
}
