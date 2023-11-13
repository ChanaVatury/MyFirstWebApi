using Entities;

namespace Servicies
{
    public interface IProductServices
    {
        Task<IEnumerable<Product>> getAllProduct(string? name, int? minPrice,
            int? maxPrice, int?[] categoryIds);
        Task<IEnumerable<Product>> getProductByCategory(int category);
    }
}