using Edu.BLL.Home;
using Edu.DAL.Entities;
using Edu.Shared.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Edu.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly HomeBLL _homeBll;
        public HomeController(HomeBLL homeBll)
        {
            _homeBll = homeBll;

        }

        [HttpGet("GetAllCountries")]
        public async Task<IActionResult> GetCountries()
        {
            try
            {
                List<CountryDTO> countries = await _homeBll.GetCountries();
                return Ok(countries);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
            
        }

        [HttpGet("GetStatesByCountry/{countryid:int}")]
        public async Task<IActionResult> GetStates([FromRoute] int countryid)
        {
            try
            {
                List<StateDTO> states= await _homeBll.GetStates(countryid);
                if (states.Count==0)
                {
                    return NotFound();
                }
                return Ok(states);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }



        [HttpGet("GetCityByState/{stateid:int}")]
        public async Task<IActionResult> GetCities([FromRoute] int stateid)
        {
            try
            {
                List<CityDTO> cities = await _homeBll.GetCities(stateid);
                if (cities.Count == 0)
                {
                    return NotFound();
                }
                return Ok(cities);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
