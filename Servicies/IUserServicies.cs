using Entities;

namespace Servicies
{
    public interface IUserServicies
    {
        Task<Users> addUser(Users user);
        Task<int> check(string Code);
        Task<Users> getUserByPasswordAndUserName(string code, string userName);
        Task<Users> getUserById(string code);
        Task<Users> updateUser(int id, Users user);
        Task<Users> getUserById(int id);
    }
}