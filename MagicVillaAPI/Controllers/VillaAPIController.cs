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
        public IActionResult GetVillas()
        {
           return Ok(VillaStore.VillaDTO()) ;
        }

        [HttpGet("id",Name = "GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetVilla(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var result = VillaStore.VillaDTO().FirstOrDefault(x => x.Id == id);
            if (result == null)
            {
                return NoContent();
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult CreateVilla( [FromBody]VillaDTO villaDTO)
        {
            if (VillaStore.VillaDTO().FirstOrDefault (x=>x.Name == villaDTO.Name) != null)
            {
                ModelState.AddModelError("NameValidation", "Name Already Exists") ;

                return BadRequest(ModelState);

            }

            if (villaDTO == null)
            {
                return BadRequest();
            }
            if (villaDTO.Id > 0)
            {
                return BadRequest(villaDTO.Id);
            }

            villaDTO.Id = VillaStore.VillaDTO().OrderByDescending(x=>x.Id).Select(x=>x.Id).FirstOrDefault() + 1 ;        
            VillaStore.VillaDTO().Add(villaDTO);

            return CreatedAtRoute("GetVilla",new {id = villaDTO.Id} ,villaDTO )  ;

        }

        //////// craken
    }
}
