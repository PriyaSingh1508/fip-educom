using System.Collections.Generic;
using System.Threading.Tasks;
using Edu.Shared.Entities;

namespace Edu.Shared.Interfaces
{
    public interface IAdminRepository
    {
        Task<IEnumerable<AdminDTO>> GetAllAdminsAsync();
        Task<AdminDTO> GetAdminByIdAsync(int id);
        Task CreateAdminAsync(AdminDTO admin);
        Task UpdateAdminAsync(int id, AdminDTO admin);
        Task DeleteAdminAsync(int id);
    }
}
