using HotelListing.API.Data;
using System.ComponentModel.DataAnnotations;

namespace HotelListing.API.Dto.Countries
{
    public class CountryResponseDto : BaseCountryDto
    {
        public int Id { get; set; }

    }

    /* public static class CountryResponseExtensions
     {
         public static CountryResponseDto ToCountryResponse(this Country country)
         {
             return new CountryResponseDto()
             {
                 Id = country.Id,
                 Name = country.Name,
                 ShortName = country.ShortName,
             };
         }
     } */
}
