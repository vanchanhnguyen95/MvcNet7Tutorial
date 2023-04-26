using MvcNet7.Models;

namespace MvcNet7.Data
{
    public static class DbInitializer
    {
        public static void Initialize(OrderContext context)
        {
            context.Database.EnsureCreated();

            // Look for any Customers.
            if (context.Customers.Any())
            {
                return;   // DB has been seeded
            }

            var customers = new Customer[]
            {
                new Customer{Name = "Mr Tran", Address="Nam Tu Liem Ha Noi"},
                new Customer{Name = "Mr An", Address="Bac Tu Liem Ha Noi"},
                new Customer{Name = "Ms Hang", Address="Cau Giay Ha Noi"}
            };
            foreach (Customer c in customers)
            {
                context.Customers.Add(c);
            }
            context.SaveChanges();

            var categories = new Category[]
            {
                new Category{Name = "Cat1", Description="Category 1"},
                new Category{Name = "Cat2", Description="Category 2"},
                new Category{Name = "Cat3", Description="Category 3"}
            };

            foreach (Category c in categories)
            {
                context.Categories.Add(c);
            }
            context.SaveChanges();

            var products = new Product[]
            {
                new Product {
                    Name = "prod1",
                    Category = new Category {Name = "Cat1", Description="Category 1"},
                    Price = 10,
                    Description= "Description prod1 1",
                    Quantity = 10 },
                new Product {
                    Name = "prod2",
                    Category = new Category {Name = "Cat1", Description="Category 1"},
                    Price = 10,
                    Description= "Description prod2 2",
                    Quantity = 10 },
                new Product {
                    Name = "prod3",
                    Category = new Category {Name = "Cat2", Description="Category 2"},
                    Price = 20,
                    Description= "Description prod3 3",
                    Quantity = 20 },
                new Product {
                    Name = "prod4",
                    Category = new Category {Name = "Cat2", Description="Category 2"},
                    Price = 20,
                    Description= "Description prod4 4",
                    Quantity = 20 },

            };
            foreach (Product p in products)
            {
                context.Products.Add(p);
            }
            context.SaveChanges();

            var orders = new Order[]
            {
                new Order
                {
                    //Customer = new Customer {Name = "Mr Tran", Address="Nam Tu Liem Ha Noi"},
                    //Product = new Product {
                    //    Name = "prod1",
                    //    Category = new Category {Name = "Cat1", Description="Category 1"},
                    //    Price = 10,
                    //    Description= "Description prod1 1",
                    //    Quantity = 10 },
                    Amount = 100,
                    OrderDate = DateTime.Parse("2022-04-18")
                },
                new Order
                {
                    //Customer = new Customer {Name = "Mr Tran", Address="Nam Tu Liem Ha Noi"},
                    //Product = new Product {
                    //    Name = "prod1",
                    //    Category = new Category {Name = "Cat1", Description="Category 1"},
                    //    Price = 10,
                    //    Description= "Description prod1 1",
                    //    Quantity = 10 },
                    Amount = 100,
                    OrderDate = DateTime.Parse("2022-04-19")
                },
                new Order
                {
                    //Customer = new Customer {Name = "Mr Tran", Address="Nam Tu Liem Ha Noi"},
                    //Product = new Product {
                    //    Name = "prod2",
                    //    Category = new Category {Name = "Cat1", Description="Category 1"},
                    //    Price = 10,
                    //    Description= "Description prod2 2",
                    //    Quantity = 10 },
                    Amount = 100,
                    OrderDate = DateTime.Parse("2022-04-20")
                },
                new Order
                {
                    //Customer = new Customer {Name = "Mr Tran", Address="Nam Tu Liem Ha Noi"},
                    //Product = new Product {
                    //    Name = "prod3",
                    //    Category = new Category {Name = "Cat2", Description="Category 2"},
                    //    Price = 20,
                    //    Description= "Description prod3 3",
                    //    Quantity = 20 },
                    Amount = 100,
                    OrderDate = DateTime.Parse("2022-04-21")
                },
            };

            foreach (Order o in orders)
            {
                context.Orders.Add(o);
            }
            context.SaveChanges();
        }
    }
}
