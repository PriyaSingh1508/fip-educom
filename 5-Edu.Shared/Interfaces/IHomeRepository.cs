using Edu.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Shared.Interfaces
{
    public interface IHomeRepository
    {
        Task<List<CityDTO>> GetCitiesAsync(int stateId);
        Task<List<CountryDTO>> GetCountries();
        Task<List<StateDTO>> GetStates(int countryId);
    }
}
