using MvcNet7.Dto;
using MvcNet7.Models;

namespace MvcNet7.Interfaces
{
    public interface ICustomerRepository
    {
        List<Customer> GetAllCustomers();
    }
}
