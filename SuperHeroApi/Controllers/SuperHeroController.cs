using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroApi.Models;

namespace SuperHeroApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private static List<SuperHero> superHeroes = new List<SuperHero>
            {
                new SuperHero
                { Id= 1,
                    Name = "Spider Man" ,
                    FirstName = "Peter" ,
                    LastName="Parker",
                    Place="new york city"},
                new SuperHero
                { Id= 2,
                    Name = "Iron Man" ,
                    FirstName = "Peter" ,
                    LastName="Parker",
                    Place="new york city"},
                new SuperHero
                { Id= 3,
                    Name = "Thor" ,
                    FirstName = "Peter" ,
                    LastName="Parker",
                    Place="new york city"}
            };
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {

            return Ok(superHeroes);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<SuperHero>>> GetSingleHero(int id)
        {
            var hero = superHeroes.Find(x => x.Id == id);
            return Ok(hero);
        }
    }
}
