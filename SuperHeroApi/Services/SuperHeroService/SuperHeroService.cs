using Microsoft.EntityFrameworkCore;
using SuperHeroApi.Data;

namespace SuperHeroApi.Services.SuperHeroService

{
    public class SuperHeroService : ISuperHeroService
    {

        private readonly DataContext _context;

        public SuperHeroService(DataContext context)
        {

            _context = context;
        }
        async Task<List<SuperHero>> ISuperHeroService.AddHero(SuperHero hero)
        {
            _context.SuperHeroes.Add(hero);
            await _context.SaveChangesAsync();
            return await _context.SuperHeroes.ToListAsync();
        }

        async Task<List<SuperHero>?> ISuperHeroService.DeleteHero(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero == null)
                return null;

            _context.SuperHeroes.Remove(hero);
            await _context.SaveChangesAsync();
            return await _context.SuperHeroes.ToListAsync();
        }

        async Task<List<SuperHero>> ISuperHeroService.GetAllHeroes()
        {
            var heroes = await _context.SuperHeroes.ToListAsync();
            return heroes;
        }

        async Task<SuperHero?> ISuperHeroService.GetSingleHero(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero == null)
                return null;
            return hero;
        }

        async Task<List<SuperHero>?> ISuperHeroService.UpdateHero(int id, SuperHero request)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero == null)
                return null;

            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Place = request.Place;
            hero.Name = request.Name;

            await _context.SaveChangesAsync();

            return await _context.SuperHeroes.ToListAsync();

        }
    }
}
