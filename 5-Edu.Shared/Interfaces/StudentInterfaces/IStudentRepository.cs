using Edu.Shared.DTO;
using Edu.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Shared.Interfaces.StudentInterfaces
{
    public interface IStudentRepository
    {
        Task<ResponseModel<string>> DeleteStudent(int id);
        Task<ResponseModel<StudentDetailDTO>> GetStudentById(int id);
        ResponseModel<IQueryable<StudentDetailDTO>> GetAllStudents();
        Task<ResponseModel<string>> AddStudent(StudentDetailDTO student);
        Task<ResponseModel<string>> UpdateStudent(int id, StudentDetailDTO student);
        Task<bool> NotAvailable(int id);
        StudentDTO Login(LoginDTO login);
    }
}
