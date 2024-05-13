using Edu.DAL.Entities;
using Edu.Shared.DTO;
using Edu.Shared.Interfaces;
using Edu.Shared.Interfaces.StudentInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.BLL.Home
{
    public class HomeBLL
    {
        private readonly IHomeRepository _homeRepository;

        public HomeBLL(IHomeRepository homeRepository)
        {
            _homeRepository = homeRepository;

        }
        public async Task<List<CityDTO>> GetCities(int stateId)
        {

            List<CityDTO> cities = await _homeRepository.GetCitiesAsync(stateId);

            
            return cities;
        }

        public async Task<List<CountryDTO>> GetCountries()
        {
            List<CountryDTO> countries = await _homeRepository.GetCountries();
            return countries;
        }

        public async Task<List<StateDTO>> GetStates(int countryId)
        {
            List<StateDTO> states = await _homeRepository.GetStates(countryId);
            return states;
        }
    }
}
