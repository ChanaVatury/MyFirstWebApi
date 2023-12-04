
using AutoMapper;
using DTO;
using Entities;


namespace MyFirstWebApi
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Users, UserDTO>().ReverseMap();
            CreateMap<Users, UserDTOLogin>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<OrdersItem, OrderItemDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ForMember(dest => dest.CategoryName,
                opts => opts.MapFrom(src => src.Category.Name));
        }
    }
}
