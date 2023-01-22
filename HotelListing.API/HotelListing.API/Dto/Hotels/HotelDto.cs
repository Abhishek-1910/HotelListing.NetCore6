using System.ComponentModel.DataAnnotations;

namespace HotelListing.API.Dto.Hotels
{
    public class HotelDto : BaseHotelDto
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }
        
    }
}
