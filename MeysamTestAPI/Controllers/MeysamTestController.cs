using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace MeysamTestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeysamTestController : ControllerBase
    {
        private static List<SuperHero> _mahsas = new List<SuperHero>
        {
            new SuperHero
            {
                Id = 1,
                Name = "ZORO",
                FirstName = "Meysam",
                LastName = "MKH",
                Place = "Toronto"
            },
            new SuperHero
            {
                Id = 2,
                Name = "LADYBUG",
                FirstName = "Tanin",
                LastName = "Ravangard",
                Place = "Shomal"
            },
            new SuperHero
            {
                Id = 3,
                Name = "BATMAN",
                FirstName = "Zohreh",
                LastName = "NSRBZGD",
                Place = "Toronto"
            }
        };

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            return Ok(_mahsas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> Get(int id)
        {
            var mahsa = _mahsas.Find(m => m.Id == id);
            if (mahsa == null)
                return BadRequest("This hero was not found");
            return Ok(mahsa);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            _mahsas.Add(hero);
            return Ok(_mahsas);
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero hero)
        {
            var mahsa = _mahsas.Find(m => m.Id == hero.Id);
            if (mahsa == null)
                return BadRequest("This hero was not found");

            mahsa.Id = hero.Id;
            mahsa.Name = hero.Name;
            mahsa.FirstName = hero.FirstName;
            mahsa.LastName = hero.LastName;
            mahsa.Place = hero.Place;

            return Ok(_mahsas);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var mahsa = _mahsas.Find(x => x.Id == id);
            if (mahsa == null)
                return BadRequest("This hero was not found");
            
            _mahsas.Remove(mahsa);
            return Ok(_mahsas);
        }
    }
}
