using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShoppingBookContext shoppingBookContext;

        public ProductRepository(ShoppingBookContext _shoppingBookContext)
        {
            shoppingBookContext = _shoppingBookContext;
        }

        public async Task<IEnumerable<Product>> getAllProduct()
        {
            return await shoppingBookContext.Products.ToListAsync();
        }
        public async Task<IEnumerable<Product>> getProductByCategory(int category)
        {
            return await shoppingBookContext.Products.Where(a => a.CategoryId == category).ToListAsync();
        }
    }
}
