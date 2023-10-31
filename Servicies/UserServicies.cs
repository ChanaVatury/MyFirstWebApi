using Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zxcvbn;

namespace Servicies
{
    public class UserServicies : IUserServicies
    {
        private IUserRepository userRepository;

        public UserServicies(IUserRepository _userRepository)
        {
            userRepository = _userRepository;
        }

        public async Task<Users> addUser(Users user)
        {
            if (check(user.Code) < 2)
                return null;
            return await userRepository.addUser(user);
        }
        public async Task<Users> getUserByPasswordAndUserName(string code, string userName)
        {
            return await userRepository.getUserByPassword(code, userName);
        }
        public async Task<Users> updateUser(int id, Users user)
        {
            if (check(user.Code) < 2)
                return null;
            return await userRepository.updateUser(id, user);
        }

        public int check(string Code)
        {
            var result = Zxcvbn.Core.EvaluatePassword(Code);
            return result.Score;
        }

   
    
    }
}
