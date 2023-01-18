using System.ComponentModel.DataAnnotations;

namespace HotelListing.API.Data
{
    public class Country
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string? Name { get; set; }

        [StringLength(20)]
        public string? ShortName { get; set; }
        public virtual IList<Hotel>? Hotels { get; set; }
    }
}