using Edu.BLL.Helper;
using Edu.Shared.DTO;
using Edu.Shared.Entities;
using Edu.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.BLL.User
{
    public class UserBLL
    {
        private readonly IUserRepository _userRepository;

        public UserBLL(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

      

        public async Task<UserDTO> GetUser(string username, string password)
        {
            var userdto= await _userRepository.GetUserByUsernameAndPassword(username, password);
            if(userdto==null) { return null; }
            if(PasswordHasher.VerifyPassword(password, userdto.Password))
            {
                return userdto;
            }
            return null;
        }
    }
}
