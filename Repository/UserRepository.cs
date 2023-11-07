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
        public async Task <Users> updateUser(int id, Users userToUpdate)
        {
            string textToReplace = string.Empty;
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string currentUserInFile;
                while ((currentUserInFile = await reader.ReadLineAsync()) != null)
                {

                    Users user = JsonSerializer.Deserialize<Users>(currentUserInFile);
                    if (user.UserId == id)
                        textToReplace = currentUserInFile;
                }
            }
            if (textToReplace != string.Empty)
            {
                string text = await System.IO.File.ReadAllTextAsync(filePath);
                text = text.Replace(textToReplace, JsonSerializer.Serialize(userToUpdate));
                await System.IO.File.WriteAllTextAsync(filePath, text);
            }
            return userToUpdate;

        }

    }

}