using MvcNet7.Models;

namespace MvcNet7.Data
{
    public class Seed
    {
        private readonly OrderContext dataContext;
        public Seed(OrderContext context)
        {
            this.dataContext = context;
        }

        public void SeedDataContext()
        {
            if (!dataContext.Orders.Any())
            {

                var orders = new Order[]
                {
                    new Order
                    {
                        Customer = new Customer {Name = "Mr Tran", Address="Ba Dinh Ha Noi"},
                        Product = new Product {
                            Name = "prod1",
                            Category = new Category {Name = "Cat1", Description="Category 1"},
                            Price = 10,
                            Description= "Description prod1 1",
                            Quantity = 10 },
                        Amount = 100,
                        OrderDate = DateTime.Parse("2022-04-18")
                    },
                    new Order
                    {
                        Customer = new Customer {Name = "Mr Huy", Address="Nam Tu Liem Ha Noi"},
                        Product = new Product {
                            Name = "prod2",
                            Category = new Category {Name = "Cat2", Description="Category 2"},
                            Price = 10,
                            Description= "Description prod2 2",
                            Quantity = 10 },
                        Amount = 100,
                        OrderDate = DateTime.Parse("2022-04-19")
                    },
                    new Order
                    {
                        Customer = new Customer {Name = "Mr Hoang", Address="Cau Giay Ha Noi"},
                        Product = new Product {
                            Name = "prod3",
                            Category = new Category {Name = "Cat3", Description="Category 3"},
                            Price = 10,
                            Description= "Description prod3 3",
                            Quantity = 10 },
                        Amount = 100,
                        OrderDate = DateTime.Parse("2022-04-20")
                    },
                    new Order
                    {
                        Customer = new Customer {Name = "Mr Dung", Address="My Dinh Ha Noi"},
                        Product = new Product {
                            Name = "prod4",
                            Category = new Category {Name = "Cat4", Description="Category 4"},
                            Price = 20,
                            Description= "Description prod4 4",
                            Quantity = 20 },
                        Amount = 100,
                        OrderDate = DateTime.Parse("2022-04-21")
                    },
                };


                dataContext.Orders.AddRange(orders);
                dataContext.SaveChanges();

            }
        }
    }
}
