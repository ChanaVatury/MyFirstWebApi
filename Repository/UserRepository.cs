﻿using Entities;
using System.Text.Json;

namespace Repository
{
    public class UserRepository : IUserRepository
    {
        const string filePath = "M:\\Web\\Layet\\MyFirstWebApi/Users.txt";
        public async Task<Users> getUserByPassword(string code, string userName)
        {
            using (StreamReader reader =  System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = await reader.ReadLineAsync()) != null)
                {
                    Users user = JsonSerializer.Deserialize<Users>(currentUserInFile);
                    if (user.UserName == userName && user.Code == code)
                        return user;
                }
            }
            return null;
        }
        public async Task<Users> getUserById(int id)
        {
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = await reader.ReadLineAsync()) != null)
                {
                    Users user = JsonSerializer.Deserialize<Users>(currentUserInFile);
                    if (user.UserId == id)
                        return user;
                }
            }
            return null;
        }
        public async Task<Users> addUser(Users user)
        {

            int numberOfUsers = System.IO.File.ReadLines(filePath).Count();
            user.UserId = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(filePath, userJson + Environment.NewLine);
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

        public Task<Users> getUserByPassword(string code)
        {
            throw new NotImplementedException();
        }

        public Task<Users> getUserById(string code)
        {
            throw new NotImplementedException();
        }
    }

}