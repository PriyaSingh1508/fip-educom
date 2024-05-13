using AutoMapper;
using Edu.DAL.Data;
using Edu.DAL.Entities;
using Edu.Shared.DTO;
using Edu.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.DAL.Repositories.Home
{
    public class HomeRepository:IHomeRepository
    {
        private readonly EduContext _context;
        private readonly IMapper _mapper;

        public HomeRepository(EduContext context, IMapper mapper)
        {
            _context = context;
            _mapper=mapper;
        }

        public async Task<List<CityDTO>> GetCitiesAsync(int stateId)
        {

            List<City> cities=await _context.Cities.Where(city=>city.StateId==stateId).ToListAsync();

            if (cities.Count == 0)
            {
                return null;
            }

            List<CityDTO> cityDTOs = _mapper.Map<List<CityDTO>>(cities);
            return cityDTOs;

        }

        public async Task<List<CountryDTO>> GetCountries()
        {
            List<Country> countries = await _context.Countries.ToListAsync();
            List<CountryDTO> countryDTOs = _mapper.Map<List<CountryDTO>>(countries);
            return countryDTOs;
        }

        public async Task<List<StateDTO>> GetStates(int countryId)
        {
            List<State> states = await _context.States.Where(state=>state.CountryId==countryId).ToListAsync();
            List<StateDTO> stateDTOs = _mapper.Map<List<StateDTO>>(states);
            return stateDTOs;
        }



    }
}
