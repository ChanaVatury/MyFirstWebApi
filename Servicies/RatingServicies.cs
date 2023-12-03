using Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicies
{
    public class RatingServicies : IRatingServicies
    {
        private readonly IRaitingRepository raitingRepository;

        public RatingServicies(IRaitingRepository _raitingRepository)
        {
            raitingRepository = _raitingRepository;
        }
        public async Task<Rating> AddRating(Rating rating)
        {
            return await raitingRepository.AddRating(rating);
        }
    }
}
