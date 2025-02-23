using HeroManagement.Domain.Entities;
using HeroManagement.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HeroManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperpowerController : ControllerBase
    {
        private readonly ISuperpowerRepository _superpowerRepository;

        public SuperpowerController(ISuperpowerRepository superpowerRepository)
        {
            _superpowerRepository = superpowerRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Superpower>> PostSuperpower(Superpower superpower)
        {
            await _superpowerRepository.AddSuperpowerAsync(superpower);
            return CreatedAtAction(nameof(GetSuperpower), new { id = superpower.Id }, superpower);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Superpower>>> GetSuperpowers()
        {
            var superpowers = await _superpowerRepository.GetAllSuperpowersAsync();
            return Ok(superpowers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Superpower>> GetSuperpower(int id)
        {
            var superpower = await _superpowerRepository.GetSuperpowerByIdAsync(id);
            if (superpower == null)
            {
                return NotFound();
            }
            return Ok(superpower);
        }
    }

}
