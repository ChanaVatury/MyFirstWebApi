using Entities;

namespace Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> getAllProduct(string? name, int? minPrice,int? maxPrice, int?[] categoryIds);
        Task<IEnumerable<Product>> getProductByCategory(int category);
    }
}