using Entities;

namespace Servicies
{
    public interface IProductServices
    {
        Task<IEnumerable<Product>> getAllProduct();
        Task<IEnumerable<Product>> getProductByCategory(int category);
    }
}