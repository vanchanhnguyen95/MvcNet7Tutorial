using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using MvcNet7.Data;
using MvcNet7.Models;
using MvcNet7.Repository;

namespace MvcNet7.Tests.Repository
{
    public class OrderRepositoryTests
    {
        private async Task<OrderContext> GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<OrderContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var databaseContext = new OrderContext(options);
            databaseContext.Database.EnsureCreated();
            if(await databaseContext.Orders.CountAsync() <= 0)
            {
                for (int i = 1; i <= 10; i++)
                {
                    databaseContext.Orders.Add(
                        new Order()
                        {
                            Customer = new Customer { Name = "Mr Tran", Address = "Ba Dinh Ha Noi" },
                            Product = new Product
                            {
                                Name = $"prod {i}",
                                Category = new Category { Name = $"Cat {i}", Description = $"Category {i}" },
                                Price = 10,
                                Description = $"Description prod{i} {i}",
                                Quantity = 10
                            },
                            Amount = i * 100,
                            OrderDate = DateTime.Parse("2020-04-18")
                        });

                    await databaseContext.SaveChangesAsync();
                }    
            }    
            return databaseContext;
        }

        [Fact]
        public async void OrderRepository_GetAllOrders_ReturnsOrders()
        {
            //Arrange
            var dbContext = await GetDatabaseContext();
            var orderRepository = new OrderRepository(dbContext);

            //Act
            var result = await orderRepository.GetAllOrders2();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<List<Order>>();
        }
    }
}
