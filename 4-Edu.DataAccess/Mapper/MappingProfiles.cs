using AutoMapper;
using Edu.DAL.Entities;
using Edu.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.DAL.Mapper
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
          
           CreateMap<UserDetailsDTO, User>().ReverseMap();
            CreateMap<User, UserDetailsDTO>().ReverseMap();
            CreateMap<AddressDTO, Address>();
            CreateMap<AddressDTO, Address>().ReverseMap();
            CreateMap<City, CityDTO>();
            CreateMap<Country, CountryDTO>();
            CreateMap<State, StateDTO>();

            CreateMap<TutorialItem, TutorialItemDTO>();
            CreateMap<TechnologyDTO,Technology>().ReverseMap();
            CreateMap<TutorialCategory, GetTutorialCategoriesDTO>().ReverseMap();
        }
    }
}
