using AutoMapper;
using Edu.DAL.Entities;
using Edu.Shared.DTO;
using Edu.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.DAL.Mapper
{
    public class AdminProfile : Profile
    {
        public AdminProfile()
        {
            CreateMap<AdminModel, AdminDTO>().ReverseMap();
            CreateMap<UserDTO,User>().ReverseMap();
        }
    }
}
