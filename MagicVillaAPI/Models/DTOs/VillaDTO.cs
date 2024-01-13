using System.ComponentModel.DataAnnotations;

namespace MagicVillaAPI.Models.DTOs
{
    public class VillaDTO
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(60)]
        public string? Name { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
