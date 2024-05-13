using AutoMapper;
using Azure;
using Edu.DAL.Data;
using Edu.DAL.Entities;
using Edu.DAL.Exceptions;
using Edu.Shared.DTO;
using Edu.Shared.Interfaces.StudentInterfaces;
using Edu.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.DAL.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IConfiguration _config;
        private readonly EduContext _context;
        private readonly IMapper _mapper;
        public StudentRepository(IConfiguration config, EduContext context, IMapper mapper)
        {
            _config = config;
            _context = context;
            _mapper = mapper;

        }
        public async Task<ResponseModel<string>> AddStudent(StudentDetailDTO studentEntity)
        {
            var response = new ResponseModel<string>();
            try
            {

                var userInfo = _mapper.Map<StudentDetailDTO, User>(studentEntity);

                User user = new User()
                {
                    FirstName = userInfo.FirstName,
                    LastName = userInfo.LastName,
                    Email = userInfo.Email,
                    Password = userInfo.Password,
                    MobileNo = userInfo.MobileNo,
                    Gender = userInfo.Gender,
                    Dob = userInfo.Dob,
                    PolicyAgreement = userInfo.PolicyAgreement,
                    UserRole = UserTypeDTO.Student.ToString()

                };
                await _context.Users.AddAsync(user);
                var dbResponse = await _context.SaveChangesAsync();


                if (dbResponse != 0)
                {
                    var res = await _context.Users.FirstOrDefaultAsync(x => x.Email == userInfo.Email);

                    if (userInfo.Addresses != null)
                    {
                        foreach (var addressDto in userInfo.Addresses)
                        {

                            var address = new Address
                            {
                                Country = addressDto.Country,
                                State = addressDto.State,
                                City = addressDto.City,
                                ZipCode = addressDto.ZipCode,
                                Street = addressDto.Street,
                                User = res
                            };

                            await _context.Addresses.AddAsync(address);
                        }


                    }

                }
                await _context.SaveChangesAsync();
                response.Message = "Added Student Successfully";
                response.IsSuccess = true;
                response.Status = System.Net.HttpStatusCode.OK;
                response.Data = "Student Added Successfully";
            }catch(Exception ex) { throw new DALException (ex.Message, ex); }

                return response;

            



        }
        public async Task<ResponseModel<StudentDetailDTO>> GetStudentById(int id)
        {
            var response=new ResponseModel<StudentDetailDTO>();
            try
            {
                var student = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
                if (student == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not Found";
                    response.Status = System.Net.HttpStatusCode.NotFound;
                }
                else
                {
                    var studentDto = _mapper.Map<StudentDetailDTO>(student);
                    var addresses = await _context.Addresses.Where(x => x.User == student).ToListAsync();
                    var addressDto = _mapper.Map<List<AddressDTO>>(addresses);
                    studentDto.Addresses = addressDto;
                    studentDto.Password = null;
                    response.IsSuccess = true;
                    response.Data=studentDto;
                    response.Status=System.Net.HttpStatusCode.OK;
                }
            }catch(Exception ex) { throw new DALException(ex.Message, ex); }



            return response;
        }
        public ResponseModel<IQueryable<StudentDetailDTO>> GetAllStudents()
        {
            var response=new ResponseModel<IQueryable<StudentDetailDTO>>();
            try
            {
                var students = _context.Users.Where(x => x.UserRole == UserTypeDTO.Student.ToString());
                response.IsSuccess = true;
                response.Data= from tutorial in students select _mapper.Map<User, StudentDetailDTO>(tutorial); ;
                response.Status= System.Net.HttpStatusCode.OK;

                
            }catch(Exception ex) { throw new DALException($"{ex.Message}", ex); }
            return response;
        
        }
        public async Task<ResponseModel<string>> UpdateStudent(int id, StudentDetailDTO studentEntity)
        {
            var response=new ResponseModel<string>();
            try
            {
                var student = _mapper.Map<User>(studentEntity);
                student.Id = id;

                var existingStudent = await _context.Users.FindAsync(id);
                if (existingStudent == null)
                {
                    response.Status = System.Net.HttpStatusCode.NotFound;
                    response.IsSuccess= false;
                    response.Data= "Student Not Found";
                }
                else
                {
                    if (student.Password == null)
                    {
                        student.Password = existingStudent.Password;
                    }
                    student.UserRole = UserTypeDTO.Student.ToString();
                    var addresses = await _context.Addresses.Where(x => x.User == existingStudent).ToListAsync();
                    _context.RemoveRange(addresses);


                    _context.Entry(existingStudent).CurrentValues.SetValues(student);

                    var dbResponse = await _context.SaveChangesAsync();


                    if (dbResponse != 0)
                    {
                        var res = await _context.Users.FirstOrDefaultAsync(x => x.Email == student.Email);

                        if (student.Addresses != null)
                        {
                            foreach (var addressDto in student.Addresses)
                            {

                                var address = new Address
                                {
                                    Country = addressDto.Country,
                                    State = addressDto.State,
                                    City = addressDto.City,
                                    ZipCode = addressDto.ZipCode,
                                    Street = addressDto.Street,
                                    User = res
                                };

                                await _context.Addresses.AddAsync(address);
                            }


                        }

                    }
                    await _context.SaveChangesAsync();
                    response.IsSuccess = true;
                    response.Data = "Student Updated Successfully";
                    response.Status = System.Net.HttpStatusCode.OK;
                }
            }catch(Exception ex) { throw new DALException(ex.Message,ex); }
            return response;
        }
        public async Task<bool> NotAvailable(int id)
        {
            var student = await _context.Users.FirstOrDefaultAsync(x=>x.Id==id/* && x.UserRole==UserTypeDTO.Student.ToString()*/);
            if (student == null)
            {
                return true;
            }
            return false;
        }
        public async Task<ResponseModel<string>> DeleteStudent(int id)
        {
            var response=new ResponseModel<string>();
            try
            {
                var student = await _context.Users.FindAsync(id);
                if (student == null) { 
                response.IsSuccess = false;
                    response.Status = System.Net.HttpStatusCode.NotFound;
                    response.Data = "Student Not Found";
                }
                else{
                    var addresses = await _context.Addresses.Where(x => x.User == student).ToListAsync();

                    _context.Users.Remove(student);
                    _context.Addresses.RemoveRange(addresses);


                    var studentDto = _mapper.Map<StudentDetailDTO>(student);

                    await _context.SaveChangesAsync();
                    response.IsSuccess = true;
                    response.Status = System.Net.HttpStatusCode.OK;
                    response.Data = "Student Deleted Successfully";
                }

            }
            catch(Exception ex) { throw new DALException(ex.Message,ex); }
            return response;
        }
        public StudentDTO Login(LoginDTO login)
        {
            var student= _context.Student.FirstOrDefault(x=>x.Email== login.Email);
            var studentDto = _mapper.Map<StudentDTO>(student);
            return studentDto;

        }
    }
}
