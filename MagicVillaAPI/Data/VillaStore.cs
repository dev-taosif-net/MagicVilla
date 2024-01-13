using MagicVillaAPI.Models.DTOs;

namespace MagicVillaAPI.Data
{
    public static class VillaStore
    {
        public static List<VillaDTO> VillaDTO()
        {
            return new List<VillaDTO>()
            {
                new VillaDTO() {Name="Villa One", Id =1},
                new VillaDTO() {Name="Villa Two", Id =1},
            };
        }
    }
}
