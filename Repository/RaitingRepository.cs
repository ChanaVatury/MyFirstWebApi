using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RaitingRepository : IRaitingRepository
    {
        private readonly ShoppingBookContext shoppingBookContext;

        public RaitingRepository(ShoppingBookContext _shoppingBookContext)
        {
            shoppingBookContext = _shoppingBookContext;
        }

        public async Task<Rating> AddRating(Rating rating)
        {
            await shoppingBookContext.Ratings.AddAsync(rating);
            await shoppingBookContext.SaveChangesAsync();
            return rating;
        }
    }
}
