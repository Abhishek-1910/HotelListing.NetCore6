using HotelListing.API.Data;
using HotelListing.API.Dto.Hotels;

namespace HotelListing.API.Dto.Countries
{
    public class CountryDto : BaseCountryDto
    {
        public int Id { get; set; }
        public virtual IList<HotelDto>? Hotels { get; set; }
    }
}
