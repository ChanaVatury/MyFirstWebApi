using Entities;

namespace Repository
{
    public interface IUserRepository
    {
        Task<Users> addUser(Users user);
        Task<Users> getUserByPassword(string code, string userName);
        Task<Users> getUserById(string code);
        Task<Users> updateUser(int id, Users userToUpdate);
    }
}