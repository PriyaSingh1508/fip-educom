using AutoMapper;
using Edu.BLL.Helper;
using Edu.DAL.Entities;
using Edu.Shared.DTO;
using Edu.Shared.Interfaces.StudentInterfaces;
using Edu.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.BLL.Student
{
    public class StudentBLL : IStudentBLL
    {
        private readonly IStudentRepository _studentRepository;

        public StudentBLL(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;

        }
        public async Task<ResponseModel<string>> AddStudent(StudentDetailDTO addRequest)
        {
            addRequest.Password = PasswordHasher.HashPassword(addRequest.Password);
            var addStudent = await _studentRepository.AddStudent(addRequest);

            return addStudent;
        }
        public async Task<ResponseModel<StudentDetailDTO>> GetStudentById(int id)
        {
            var student = await _studentRepository.GetStudentById(id);

            return student;
        }
        public ResponseModel<IQueryable<StudentDetailDTO>> GetAllStudents()
        {
            var studentList =_studentRepository.GetAllStudents();

            return studentList;
        }
        public async Task<bool> NotAvailable(int id)
        {
            return await _studentRepository.NotAvailable(id);
        }
        public async Task<ResponseModel<string>> UpdateStudent(int id, StudentDetailDTO student)
        {
            
            student.Password=PasswordHasher.HashPassword(student.Password);
            
            var studentInfo = await _studentRepository.UpdateStudent(id, student);

            return studentInfo;
        }
        public async Task<ResponseModel<string>> DeleteStudent(int id)
        {

            var deletedStudent = await _studentRepository.DeleteStudent(id);

            return deletedStudent;
        }
        public StudentDTO Login(LoginDTO login)
        {
            var student = _studentRepository.Login(login);
            return student;
        }

    }
}
