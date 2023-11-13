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

        public async Task<IEnumerable<Product>> getAllProduct(string? name,int? minPrice, 
            int? maxPrice, int?[] categoryIds)
        {
            var query = shoppingBookContext.Products.Where(product =>
                (name == null) ? (true) : (product.Name.Contains(name))
                && ((minPrice == null) ? (true) : (int.Parse(product.Price) >= minPrice))
                && ((maxPrice == null) ? (true) : (int.Parse(product.Price) <= maxPrice))
                && ((categoryIds.Length == 0) ? (true) : (categoryIds.Contains(product.CategoryId))))
                .OrderBy(p => p.Price);
            List<Product> products = await query.ToListAsync();
           
            return products;
        }
        public async Task<IEnumerable<Product>> getProductByCategory(int category)
        {
            return await shoppingBookContext.Products.Where(a => a.CategoryId == category).ToListAsync();
        }
    }
}
