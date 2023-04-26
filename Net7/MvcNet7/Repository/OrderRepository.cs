using Microsoft.EntityFrameworkCore;
using MvcNet7.Data;
using MvcNet7.Dto;
using MvcNet7.Interfaces;
using MvcNet7.Models;
using LogLevel = MvcNet7.Interfaces.LogLevel;

namespace MvcNet7.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ILogRepository _logRepository;
        private readonly OrderContext _context;

        public OrderRepository( OrderContext context)
        {
            _context = context;
        }

        public OrderRepository(ILogRepository logRepository,OrderContext context)
        {
            _logRepository = logRepository;
            _context = context;
        }

        public async Task<bool> SaveAsync()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }

        public Task<bool> CreateOrder(int customerId, int productId, Order order)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CreateOrder(Order order)
        {
            var customer = _context.Customers.Where(a => a.Id == order.CustomerId).FirstOrDefault();
            var product = _context.Products.Where(a => a.Id == order.ProductId).FirstOrDefault();

            order.Customer = customer;
            order.Product = product;

            //var pokemonOwnerEntity = _context.Owners.Where(a => a.Id == ownerId).FirstOrDefault();
            //var category = _context.Categories.Where(a => a.Id == categoryId).FirstOrDefault();

            await _context.AddAsync(order);
             //await _context.SaveChangesAsync();
            return await SaveAsync();
        }

        public Task<bool> DeleteOrder(Order order)
        {
            throw new NotImplementedException();
        }

        //public List<OrderViewDto> GetAllOrders()
        //{
        //    var result2 = _context.Orders.Include(p => p.Product).Include(c => c.Customer).ToList();

        //    var result = (
        //        from d in _context.Orders
        //        join c in _context.Customers
        //        on d.CustomerId equals c.Id
        //        join p in _context.Products
        //        on d.ProductId equals p.Id into target
        //        from r in target.DefaultIfEmpty()
        //        select new OrderViewDto
        //        {
        //            Id = d.Id,
        //            CustomerId = d.CustomerId,
        //            CustomerName = c.Name,
        //            ProductId = d.ProductId,
        //            ProductName = r.Name,
        //            OrderDate = d.OrderDate,
        //            Amount = d.Amount
        //        }
        //        ).ToList();
        //    return result;
        //}

        public Task<Order> GetOrder(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetOrder(string name)
        {
            throw new NotImplementedException();
        }

        public Task<decimal> GetOrderRating(int orderId)
        {
            throw new NotImplementedException();
        }

        public ICollection<Order> GetOrders()
        {
            return _context.Orders.OrderBy(p => p.Id).ToList();
        }

        public Task<Order> GetOrderTrimToUpper(OrderDto orderCreate)
        {
            throw new NotImplementedException();
        }

        public Task<bool> OrderExists(int orderId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Save()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateOrder(int customerId, int productId, Order order)
        {
            throw new NotImplementedException();
        }
         
        public async Task<IQueryable<Order>> GetAllOrders()
        {
            try
            {
                var result = _context.Orders.Include(p => p.Product).Include(p => p.Product.Category).Include(c => c.Customer).ToList().AsQueryable();
                await _context.DisposeAsync();
                return result;
            }
            catch(Exception)
            {
                _logRepository.WriteLog($"OrderRepository-GetAllOrders", LogLevel.Error);
                return null;
            }
            
        }

        public async Task<List<Order>> GetAllOrders2()
        {
            try
            {
                var result = _context.Orders.Include(p => p.Product).Include(p => p.Product.Category).Include(c => c.Customer).ToList();
                await _context.DisposeAsync();
                return result;
            }
            catch (Exception)
            {
                _logRepository.WriteLog($"OrderRepository-GetAllOrders", LogLevel.Error);
                return null;
            }

        }
    }
}
