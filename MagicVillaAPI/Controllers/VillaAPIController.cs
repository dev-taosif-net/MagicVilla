using MagicVillaAPI.Data;
using MagicVillaAPI.Entity;
using MagicVillaAPI.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MagicVillaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        public readonly ILogger<VillaAPIController> logger;
        public readonly ApplicationDbContext _db;
        public VillaAPIController(ILogger<VillaAPIController> logger, ApplicationDbContext _db)
        {
            this.logger = logger;
            this._db = _db;
        }

        [HttpGet]
        [Route("GetAllVilla")]
        public IActionResult GetVillas()
        {
            return Ok(_db.Villas.ToList());
        }

        [HttpGet]
        [Route("GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetVilla(int id)
        {
            if (id == 0)
            {
                logger.LogError("Invalid Data");
                return BadRequest();
            }
            var result = _db.Villas.FirstOrDefault(x => x.Id == id);
            if (result == null)
            {
                return NoContent();
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("CreateVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateVilla( [FromBody]VillaDTO villaDTO)
        {

            if (villaDTO == null)
            {
                return BadRequest();
            }
 
            Villa villa = new Villa()
            {
                Name = villaDTO.Name,
                Details = villaDTO.Details,
                Rate = villaDTO.Rate,
                Sqft = villaDTO.Sqft,
                Occupancy = villaDTO.Occupancy,
                ImageUrl = villaDTO.ImageUrl,
                Amenity = villaDTO.Amenity,
                CreatedDate = DateTime.Now,
            };

            _db.Add(villa);
            _db.SaveChanges();
 
            return Ok("Villa Created!!!");

        }

    }
}
