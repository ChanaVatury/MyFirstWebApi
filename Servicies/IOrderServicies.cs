using Entities;

namespace Servicies
{
    public interface IOrderServicies
    {
        Task<Order> addOrder(Order order);
    }
}