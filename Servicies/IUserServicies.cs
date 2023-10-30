using Entities;

namespace Servicies
{
    public interface IUserServicies
    {
        Users addUser(Users user);
        int check(string Code);
        Users getUserByPasswordAndUserName(string code, string userName);
        Users updateUser(int id, Users user);
    }
}