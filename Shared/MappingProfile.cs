using AutoMapper;
using Shared.DTOs;
using Shared.Models;

namespace Shared
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            AllowNullCollections = true;
            CreateMap<CustomerDTO, Customer>().IgnoreReadOnly();
            CreateMap<Customer, CustomerDTO>();
            CreateMap<OrderDTO, Order>().IgnoreReadOnly();
            CreateMap<Order, OrderDTO>();
            CreateMap<OrderItemDTO, OrderItem>().IgnoreReadOnly();
            CreateMap<OrderItem, OrderItemDTO>();
            CreateMap<ProductDTO, Product>().IgnoreReadOnly();
            CreateMap<Product, ProductDTO>();
            CreateMap<SupplierDTO, Supplier>().IgnoreReadOnly();
            CreateMap<Supplier, SupplierDTO>();
        }
    }
}
