using Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicies
{
    public class ProductServices : IProductServices
    {

        IProductRepository productRepository;

        public ProductServices(IProductRepository _productRepository)
        {
            this.productRepository = _productRepository;
        }

        public async Task<IEnumerable<Product>> getAllProduct(string? name, int? minPrice,
            int? maxPrice, int?[] categoryIds)
        {
            return await productRepository.getAllProduct(name,minPrice,maxPrice,categoryIds);
        }
        public async Task<IEnumerable<Product>> getProductByCategory(int category)
        {
            return await productRepository.getProductByCategory(category);
        }
    }
}
