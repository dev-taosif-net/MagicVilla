using System.ComponentModel.DataAnnotations;

namespace MagicVillaAPI.Models.DTOs
{
    public class VillaDTO
    {
        public required string Name { get; set; }
        public required string Details { get; set; }
        public required double Rate { get; set; }
        public int Sqft { get; set; }
        public int Occupancy { get; set; }
        public string? ImageUrl { get; set; }
        public string? Amenity { get; set; }

    }
}
