
using AutoMapper;
using MvcNet7.Dto;
using MvcNet7.Models;

namespace MvcNet7.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Order, OrderDto>();
            CreateMap<OrderDto, Order>();
            CreateMap<Customer, CustomerDto>();
        }
    }
}
