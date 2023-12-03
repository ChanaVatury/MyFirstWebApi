using Entities;

namespace Servicies
{
    public interface IRatingServicies
    {
        Task<Rating> AddRating(Rating rating);
    }
}