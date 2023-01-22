using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelListing.API.Data;
using HotelListing.API.Contract;
using HotelListing.API.Dto.Hotels;
using AutoMapper;

namespace HotelListing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelsContract _hotelsContract;
        private readonly IMapper _mapper;

        public HotelsController(IHotelsContract hotelsContract, IMapper mapper)
        {
            _hotelsContract = hotelsContract;
            _mapper = mapper;
        }

        // GET: api/Hotels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelDto>>> GetHotels()
        {
            return _mapper.Map<List<HotelDto>>(await _hotelsContract.GetAllAsync());
        }

        // GET: api/Hotels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelDto>> GetHotel(int id)
        {
            var hotel = await _hotelsContract.GetAsync(id);

            if (hotel == null)
            {
                return NotFound();
            }

            return _mapper.Map<HotelDto>(hotel);
        }

        // PUT: api/Hotels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotel(int id, HotelDto hotelDto)
        {
            if (id != hotelDto.Id)
            {
                return BadRequest();
            }

            //_hotelsContract.Entry(hotel).State = EntityState.Modified;

            try
            {
                await _hotelsContract.UpdateAsync(_mapper.Map<Hotel>(hotelDto));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await HotelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Hotels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HotelDto>> PostHotel(AddHotelRequestDto addHotelRequestDto)
        {
            Hotel hotel = _mapper.Map<Hotel>(addHotelRequestDto);
            await _hotelsContract.AddAsync(hotel);

            return _mapper.Map<HotelDto>(hotel);
        }

        // DELETE: api/Hotels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            var hotel = await _hotelsContract.GetAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }

            await _hotelsContract.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> HotelExists(int id)
        {
            return await _hotelsContract.Exists(id);
        }
    }
}
