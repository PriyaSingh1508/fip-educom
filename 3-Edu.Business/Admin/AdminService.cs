using Edu.DAL;
using Edu.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edu.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Edu.Shared.Interfaces;
using Edu.BLL.Helper;

namespace Edu.BLL.Admin
{
    public class AdminService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public async Task<IEnumerable<AdminDTO>> GetAllAdminsAsync()
        {
            return await _adminRepository.GetAllAdminsAsync();
        }

        public async Task<AdminDTO> GetAdminByIdAsync(int id)
        {
            return await _adminRepository.GetAdminByIdAsync(id);
        }

        public async Task CreateAdminAsync(AdminDTO adminDTO)
        {

            adminDTO.Password = PasswordHasher.HashPassword(adminDTO.Password);
            await _adminRepository.CreateAdminAsync(adminDTO);
        }

        public async Task UpdateAdminAsync(int id, AdminDTO adminDTO)
        {
            adminDTO.Password = PasswordHasher.HashPassword(adminDTO.Password);
            await _adminRepository.UpdateAdminAsync(id, adminDTO);
        }

        public async Task DeleteAdminAsync(int id)
        {
            await _adminRepository.DeleteAdminAsync(id);
        }
    }
}