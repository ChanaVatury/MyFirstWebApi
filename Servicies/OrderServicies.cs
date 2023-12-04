using Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Logging;
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
        private ILogger<OrderServicies> logger;

        public OrderServicies(IOrderRepository _orderRepository, ILogger<OrderServicies> _logger)
        {
            orderRepository = _orderRepository;
            logger = _logger;
        }
        public async Task<Order> addOrder(Order order)
        {
                int  order_sum = 0;
                var o = order.OrdersItems;
                foreach (OrdersItem i in o)
                {
                    int sum = await orderRepository.getprice(i);
                    sum = (int)(sum * (i.Quantity + 1));
                    order_sum += sum;

                }
                if (order_sum != order.OrderSum)

                {
                    Console.WriteLine("the polic come to you");
                    logger.LogInformation("{1} try to still! ", order.UserId);
                    logger.LogError($"try to still: {order.UserId}");
                    return null;
                }
            return await orderRepository.addOrder(order);
        }

    }
}
