using AutoMapper;
using HotelListing.API.Data;
using HotelListing.API.Dto.Countries;
using HotelListing.API.Dto.Hotels;

namespace HotelListing.API.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Country, AddCountryRequestDto>().ReverseMap(); // Usinv ReverseMap() allows us to
                                                                     // map vice versa also.
                                                                     // i.e. Both Country to AddCountryRequestDto and AddCountryRequestDto to Country.
            CreateMap<Country, CountryResponseDto>().ReverseMap();
            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<Country, UpdateCountryDto>().ReverseMap();


            CreateMap<Hotel, HotelDto>().ReverseMap();
            CreateMap<Hotel, AddHotelRequestDto>().ReverseMap();
            CreateMap<HotelDto, AddHotelRequestDto>().ReverseMap();
        }
    }
}
