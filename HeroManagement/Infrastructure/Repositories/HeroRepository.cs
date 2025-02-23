using HeroManagement.Domain.Entities;
using HeroManagement.Domain.Interfaces;
using HeroManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeroManagement.Infrastructure.Repositories
{
    public class HeroRepository : IHeroRepository
    {
        private readonly ApplicationDbContext _context;

        public HeroRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Hero>> GetAllHeroesAsync()
        {
            return await _context.Heroes.Include(h => h.HeroSuperpowers).ThenInclude(hs => hs.Superpower).ToListAsync();
        }

        public async Task<Hero> GetHeroByIdAsync(int id)
        {
            return await _context.Heroes.Include(h => h.HeroSuperpowers).ThenInclude(hs => hs.Superpower).FirstOrDefaultAsync(h => h.Id == id);
        }

        public async Task AddHeroAsync(Hero hero)
        {
            await _context.Heroes.AddAsync(hero);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateHeroAsync(Hero hero)
        {
            _context.Heroes.Update(hero);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteHeroAsync(int id)
        {
            var hero = await _context.Heroes.FindAsync(id);
            _context.Heroes.Remove(hero);
            await _context.SaveChangesAsync();
        }
    }
}
