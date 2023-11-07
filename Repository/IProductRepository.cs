using Entities;

namespace Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> getAllProduct();
        Task<IEnumerable<Product>> getProductByCategory(string category);
    }
}