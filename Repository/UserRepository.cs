using Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ShoppingBookContext shoppingBookContext;

       // const string filePath = "D:\\gggggg/Users.txt";
        const string filePath = "M:\\Web\\Layet\\MyFirstWebApi/Users.txt";

        public UserRepository(ShoppingBookContext _shoppingBookContext)
        {
            shoppingBookContext = _shoppingBookContext;
        }

        public async Task<Users> getUserByPassword(string code, string userName)
        {
           return  await shoppingBookContext.Users.Where(e => e.Passwordd == code && e.Email == userName).FirstOrDefaultAsync();
        
        }
        public async Task<Users> addUser(Users user)
        {
            await shoppingBookContext.Users.AddAsync(user);
            await shoppingBookContext.SaveChangesAsync();
            return user;
        }
        public async Task<Users> updateUser(int id, Users userToUpdate)
        {
            userToUpdate.UserId = id;
            shoppingBookContext.Users.Update(userToUpdate);
            await shoppingBookContext.SaveChangesAsync();


        }

    }

}