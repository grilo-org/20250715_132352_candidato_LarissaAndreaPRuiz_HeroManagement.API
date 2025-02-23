using HeroManagement.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeroManagement.Domain.Interfaces
{
    public interface ISuperpowerRepository
    {
        Task<IEnumerable<Superpower>> GetAllSuperpowersAsync();
        Task<Superpower> GetSuperpowerByIdAsync(int id);
        Task AddSuperpowerAsync(Superpower superpower); // Adicione esta linha
    }
}
