using AutoMapper;
using Edu.DAL.Data;
using Edu.DAL.Entities;
using Edu.DAL.Exceptions;
using Edu.Shared.DTO;
using Edu.Shared.Interfaces.Teacher;
using Edu.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.DAL.Repository.Teachers
{
    public class TeacherRepository:ITeacherRepository
    {
        private readonly EduContext _context;
        private readonly IMapper _mapper;

        public TeacherRepository(EduContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ResponseModel<string>> RegisterTeacher(UserDetailsDTO userDTO)
        {
            var response=new ResponseModel<string>();
            try
            {

                var userInfo = _mapper.Map<UserDetailsDTO, User>(userDTO);

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
                    UserRole = UserTypeDTO.Teacher.ToString()

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
                    Teacher teacher = new Teacher()
                    {
                        User = res,
                        SubjectSpecialization = userDTO.SubjectSpecialization
                    };
                    await _context.Teachers.AddAsync(teacher);
                }
                await _context.SaveChangesAsync();

                response.Data = "User added successfully";
                response.IsSuccess = true;
                response.Status = System.Net.HttpStatusCode.OK;
            }catch(Exception ex) { throw new DALException(ex.Message, ex); }
            return response;

        }
    }
}
