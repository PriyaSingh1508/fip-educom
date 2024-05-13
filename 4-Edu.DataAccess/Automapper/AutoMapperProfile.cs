using AutoMapper;
using Edu.DAL.Entities;
using Edu.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.DAL.Automapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<StudentDTO, StudentEntity>();
            CreateMap<StudentDTO, StudentEntity>().ReverseMap();
            CreateMap<StudentDetailDTO, User>();
            CreateMap<StudentDetailDTO, User>().ReverseMap();

        }
    }
}
