using Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicies
{
    public class CategoryServices : ICategoryServices
    {

        private readonly ICategoryRepository categoryRepository;

        public CategoryServices(ICategoryRepository _categoryRepository)
        {
            categoryRepository = _categoryRepository;
        }

        public async Task<IEnumerable<Category>> getAllCategory()
        {
            return await categoryRepository.getAllCategory();
        }
    }
}
