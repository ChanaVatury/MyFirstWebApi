using Entities;

namespace Servicies
{
    public interface ICategoryServices
    {
        Task<IEnumerable<Category>> getAllCategory();
    }
}