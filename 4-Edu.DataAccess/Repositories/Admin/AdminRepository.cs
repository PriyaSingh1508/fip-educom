using Edu.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Edu.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Edu.DAL.Data;
using Edu.DAL.Entities;
using Edu.Shared.DTO;

namespace Edu.DAL.Repositories.Admin
{
    public class AdminRepository : IAdminRepository
    {
        private readonly EduContext _context;
        private readonly IMapper _mapper;

        public AdminRepository(EduContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AdminDTO>> GetAllAdminsAsync()
        {
            var admins = await _context.Admins.ToListAsync();
            return _mapper.Map<IEnumerable<AdminDTO>>(admins);
        }

        public async Task<AdminDTO> GetAdminByIdAsync(int id)
        {
            var admin = await _context.Admins.FindAsync(id);
            return _mapper.Map<AdminDTO>(admin);
        }

        public async Task CreateAdminAsync(AdminDTO adminDTO)
        {
            var admin = _mapper.Map<AdminModel>(adminDTO);
            _context.Admins.Add(admin);
            Edu.DAL.Entities.User user = new Edu.DAL.Entities.User();
            user.Email = adminDTO.Email;
            user.Password = adminDTO.Password;
            user.Addresses = null;
            user.FirstName = adminDTO.Email; 
            user.LastName=adminDTO.Email;
            user.Dob = null;
            user.Gender = "";
            user.UserRole = UserTypeDTO.Admin.ToString();
            user.MobileNo = "";
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAdminAsync(int id, AdminDTO adminDTO)
        {
            var admin = await _context.Admins.FindAsync(id);
            if (admin == null)
            {
                // Handle not found case
                return;
            }

            _mapper.Map(adminDTO, admin);

            _context.Entry(admin).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAdminAsync(int id)
        {
            var admin = await _context.Admins.FindAsync(id);
            if (admin != null)
            {
                _context.Admins.Remove(admin);
                await _context.SaveChangesAsync();
            }
        }
    }
}