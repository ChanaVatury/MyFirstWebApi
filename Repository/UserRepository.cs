using Entities;
using System.Text.Json;

namespace Repository
{
    public class UserRepository : IUserRepository
    {
        const string filePath = "M:\\Web\\Layet\\MyFirstWebApi/Users.txt";
        public Users getUserByPassword(string code, string userName)
        {
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    Users user = JsonSerializer.Deserialize<Users>(currentUserInFile);
                    if (user.UserName == userName && user.Code == code)
                        return user;
                }
            }
            return null;
        }
        public Users addUser(Users user)
        {

            int numberOfUsers = System.IO.File.ReadLines(filePath).Count();
            user.UserId = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(filePath, userJson + Environment.NewLine);
            return user;
        }
        public Users updateUser(int id, Users userToUpdate)
        {
            string textToReplace = string.Empty;
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {

                    Users user = JsonSerializer.Deserialize<Users>(currentUserInFile);
                    if (user.UserId == id)
                        textToReplace = currentUserInFile;
                }
            }
            if (textToReplace != string.Empty)
            {
                string text = System.IO.File.ReadAllText(filePath);
                text = text.Replace(textToReplace, JsonSerializer.Serialize(userToUpdate));
                System.IO.File.WriteAllText(filePath, text);
            }
            return userToUpdate;

        }


    }

}