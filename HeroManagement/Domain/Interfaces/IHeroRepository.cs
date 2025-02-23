using HeroManagement.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeroManagement.Domain.Interfaces
{
    public interface IHeroRepository
    {
        Task<IEnumerable<Hero>> GetAllHeroesAsync();
        Task<Hero> GetHeroByIdAsync(int id);
        Task AddHeroAsync(Hero hero);
        Task UpdateHeroAsync(Hero hero);
        Task DeleteHeroAsync(int id);
    }
}
