using HotelListing.API.Data;

namespace HotelListing.API.Contract
{
    public interface ICountriesContract : IGenericContract<Country>
    {
        Task<Country?> GetDetails(int id);
    }
}
