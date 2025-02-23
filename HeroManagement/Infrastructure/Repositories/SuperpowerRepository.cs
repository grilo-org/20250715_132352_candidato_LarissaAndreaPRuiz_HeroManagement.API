using HeroManagement.Domain.Entities;
using HeroManagement.Domain.Interfaces;
using HeroManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeroManagement.Infrastructure.Repositories
{
    public class SuperpowerRepository : ISuperpowerRepository
    {
        private readonly ApplicationDbContext _context;

        public SuperpowerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Superpower>> GetAllSuperpowersAsync()
        {
            return await _context.Superpowers.ToListAsync();
        }

        public async Task<Superpower> GetSuperpowerByIdAsync(int id)
        {
            return await _context.Superpowers.FindAsync(id);
        }

        public async Task AddSuperpowerAsync(Superpower superpower)
        {
            await _context.Superpowers.AddAsync(superpower);
            await _context.SaveChangesAsync();
        }
    }
}
