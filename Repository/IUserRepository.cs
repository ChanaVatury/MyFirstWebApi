using Entities;

namespace Repository
{
    public interface IUserRepository
    {
        Users addUser(Users user);
        Users getUserByPassword(string code, string userName);
        Users updateUser(int id, Users userToUpdate);
    }
}