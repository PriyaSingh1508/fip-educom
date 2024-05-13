using Edu.Shared.DTO;
using Edu.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Shared.Interfaces
{
    public interface IUserRepository
    {
        Task<UserDTO> GetUserByUsernameAndPassword(string username, string password);
    }
}
