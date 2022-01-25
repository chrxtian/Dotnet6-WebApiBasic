using Api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]    
    public class HeroesController : ControllerBase
    {
        //private static List<Hero> _heroes = new List<Hero>
        //{ 
        //    new Hero { Id = 1, Name = "Spider-man", FirstName = "Peter", LastName = "Parker", Place = "NY" },
        //    new Hero { Id = 2, Name = "Ironman", FirstName = "Tony", LastName = "Stark", Place = "Long Island" }
        //};

        private DataDbContext _context { get; set; }

        public HeroesController(DataDbContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<List<Hero>>> Get()
        {
            var heroes = await _context.Heroes.ToListAsync();
            return Ok(heroes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Hero>> Get(int id)
        {
            var hero = await _context.Heroes.FindAsync(id);
            if (hero == null)
            { 
                return NotFound($"Hero with id '{id}' not found.");
            }
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<Hero>> Post(Hero hero)
        { 
            _context.Heroes.Add(hero);
            await _context.SaveChangesAsync();
            return Created($"api/heroes/{hero.Id}", hero);
        }

        [HttpPut]
        public async Task<ActionResult<Hero>> Put(Hero hero)
        {
            if (hero == null)
            {
                return BadRequest();
            }

            var dbHero = await _context.Heroes.FindAsync(hero.Id);
            if (dbHero == null)
            {
                return NotFound();
            }

            dbHero.Id = hero.Id;
            dbHero.Name = hero.Name;
            dbHero.FirstName = hero.FirstName;
            dbHero.LastName = hero.LastName;
            dbHero.Place = hero.Place;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var hero = await _context.Heroes.FindAsync(id);
            if (hero == null)
            {
                return NotFound($"Hero with id '{id}' not found.");
            }
            _context.Heroes.Remove(hero);
            await _context.SaveChangesAsync();
            return Ok(hero);
        }

    }
}
