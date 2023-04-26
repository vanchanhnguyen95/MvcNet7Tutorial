using MvcNet7.Dto;
using MvcNet7.Models;

namespace MvcNet7.Interfaces
{
    public interface IOrderRepository
    {
        Task<IQueryable<Order>> GetAllOrders();
        Task<List<Order>> GetAllOrders2();

        ICollection<Order> GetOrders();

        Task<Order> GetOrder(int id);
        Task<Order> GetOrder(string name);
        Task<Order> GetOrderTrimToUpper(OrderDto orderCreate);
        Task<decimal>  GetOrderRating(int orderId);
        Task<bool> OrderExists(int orderId);
        Task<bool> CreateOrder(Order order);
        Task<bool> CreateOrder(int customerId, int productId, Order order);
        Task<bool> UpdateOrder(int customerId, int productId, Order order);
        Task<bool> DeleteOrder(Order order);
        Task<bool> Save();
    }
}
