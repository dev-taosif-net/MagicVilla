using MagicVillaAPI.Data;
using MagicVillaAPI.Models;
using MagicVillaAPI.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MagicVillaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<VillaDTO> GetVillas()
        {
           return VillaStore.VillaDTO();
        }

        [HttpGet("id")]
        public VillaDTO? GetVilla(int id)
        {
            var v = VillaStore.VillaDTO().FirstOrDefault(x => x.Id == id);

            return v;
        }
    }
}
