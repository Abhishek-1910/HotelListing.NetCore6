using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelListing.API.Data;
using AutoMapper;
using HotelListing.API.Dto.Countries;
using NuGet.Versioning;
using HotelListing.API.Contract;

namespace HotelListing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountriesContract _countriesContract;
        private readonly IMapper _mapper;

        public CountriesController(ICountriesContract countriesContract, IMapper mapper)
        {
            _countriesContract = countriesContract;
            _mapper = mapper;
        }

        // GET: api/Countries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CountryDto>>> GetCountries()
        {
            return _mapper.Map<List<CountryDto>>(await _countriesContract.GetAllAsync());
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CountryDto>> GetCountry(int id)
        {
            var country = await _countriesContract.GetDetails(id);
            //if (country == null)
            //{
            //    return NotFound();
            //}

            // return country;

            return country == null ? NotFound() : _mapper.Map<CountryDto>(country);
        }

        // PUT: api/Countries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountry(int id, UpdateCountryDto updateCountryDto)
        {
            if (id != updateCountryDto.Id) return BadRequest("Invalid Record ID");
            var country = await _countriesContract.GetAsync(id);

            if (country == null) return NoContent();

            _mapper.Map(updateCountryDto, country);

            try
            {
                await _countriesContract.UpdateAsync(country);
            } catch(DbUpdateConcurrencyException)
            {
                if (!await CountryExists(id)) return NotFound();
            }
            return NoContent();
        }

        private async Task<bool> CountryExists(int id)
        {
            return await _countriesContract.Exists(id);
        }

        // POST: api/Countries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CountryResponseDto>> PostCountry(AddCountryRequestDto addCountryRequest)
        {
            //Country country = addCountryRequest.ToCountry();
            //_context.Countries.Add(country);
            //await _context.SaveChangesAsync();
            //country.ToCountryResponse();
            //return CreatedAtAction("GetCountry", new { id = country.Id }, country.ToCountryResponse());

            Country country = _mapper.Map<Country>(addCountryRequest);
            await _countriesContract.AddAsync(country);
            return CreatedAtAction("GetCountry", new { id = country.Id }, country);


        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var country = await _countriesContract.GetAsync(id);
            if (country == null)
            {
                return NotFound();
            }

            //_context.Countries.Remove(country);
            //await _context.SaveChangesAsync();

            await _countriesContract.DeleteAsync(id);

            return NoContent();
        }

    }
}
