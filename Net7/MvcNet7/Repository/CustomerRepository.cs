using MvcNet7.Data;
using MvcNet7.Interfaces;
using MvcNet7.Models;

namespace MvcNet7.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly OrderContext _context;

        public CustomerRepository(OrderContext context)
        {
            _context = context;
        }

        public List<Customer> GetAllCustomers()
        {
            return  _context.Customers.ToList() ?? new List<Customer>();
        }
    }
}
