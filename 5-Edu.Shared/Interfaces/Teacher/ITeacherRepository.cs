using Edu.Shared.DTO;
using Edu.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Shared.Interfaces.Teacher
{
    public interface ITeacherRepository
    {
        public Task<ResponseModel<string>> RegisterTeacher(UserDetailsDTO userDTO);
    }
}
