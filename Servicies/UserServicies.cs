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

        public Users addUser(Users user)
        {
            if (check(user.Code) < 2)
                return null;
            return userRepository.addUser(user);
        }
        public Users getUserByPasswordAndUserName(string code, string userName)
        {
            return userRepository.getUserByPassword(code, userName);
        }
        public Users updateUser(int id, Users user)
        {
            if (check(user.Code) < 2)
                return null;
            return userRepository.updateUser(id, user);
        }

        public int check(string Code)
        {
            var result = Zxcvbn.Core.EvaluatePassword(Code);
            return result.Score;
        }
    }
}
