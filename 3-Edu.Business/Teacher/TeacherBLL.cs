using Edu.BLL.Helper;
using Edu.Shared.DTO;
using Edu.Shared.Interfaces.Teacher;
using Edu.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.BLL.Teacher
{
    public class TeacherBLL
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherBLL(ITeacherRepository teacherRepository)
        {

            _teacherRepository = teacherRepository;

        }
        public async Task<ResponseModel<string>> RegisterTeacher(UserDetailsDTO userDTO)
        {
            
            //var teacher = _mapper.Map<TeacherLoginDTO, TeacherLogin>(teacherLoginDTO);
            userDTO.Password=PasswordHasher.HashPassword(userDTO.Password);
            var res=await _teacherRepository.RegisterTeacher(userDTO);
            return res;


        }
    }
}
