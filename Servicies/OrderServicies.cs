using Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicies
{
    public class OrderServicies : IOrderServicies
    {
        private readonly IOrderRepository orderRepository;

        public OrderServicies(IOrderRepository _orderRepository)
        {
            orderRepository = _orderRepository;
        }
        public async Task<Order> addOrder(Order order)
        {

            return await orderRepository.addOrder(order);
        }

    }
}
