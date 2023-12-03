using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ShoppingBookContext shoppingBookContext;

        public OrderRepository(ShoppingBookContext shoppingBookContext)
        {
            this.shoppingBookContext = shoppingBookContext;
        }

        public async Task<Order> addOrder(Order order)
        {

            await shoppingBookContext.Orders.AddAsync(order);
            await shoppingBookContext.SaveChangesAsync();
            return order;
        }
        public async Task<int> getprice(OrdersItem order)
        {
            Product product = shoppingBookContext.Products.Where(item => item.Id == order.UserId).FirstOrDefault();
            return (int)product.Price;
        }

    }
}
