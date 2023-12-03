using Entities;

namespace Repository
{
    public interface IRaitingRepository
    {
        Task<Rating> AddRating(Rating rating);
    }
}