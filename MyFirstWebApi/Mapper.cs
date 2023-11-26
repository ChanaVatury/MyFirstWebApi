
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
        }
    }
}
