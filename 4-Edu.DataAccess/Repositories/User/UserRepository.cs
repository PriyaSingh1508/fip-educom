using AutoMapper;
using Edu.DAL.Data;
using Edu.Shared.DTO;
using Edu.Shared.Entities;
using Edu.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.DAL.Repositories.User
{
    public class UserRepository:IUserRepository
    {

        private readonly EduContext _context;
        private readonly IMapper _mapper;

        public UserRepository(EduContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserDTO> GetUserByUsernameAndPassword(string email, string password)
        {
            var user = await _context.Users.Where(u=>u.Email==email).FirstOrDefaultAsync();
            if(user == null)
            {
                return null;
            }
            UserDTO dto = new UserDTO();
            dto.Email = user.Email;
            dto.Password = user.Password;
            dto.Role = user.UserRole;

            return dto;
        }
    }
}
