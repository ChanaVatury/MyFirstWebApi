using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ShoppingBookContext shoppingBookContext;

        public CategoryRepository(ShoppingBookContext _shoppingBookContext)
        {
            shoppingBookContext = _shoppingBookContext;
        }

        public async Task<IEnumerable<Category>> getAllCategory()
        {
            return await shoppingBookContext.Categories.ToListAsync();
        }

    }
}
