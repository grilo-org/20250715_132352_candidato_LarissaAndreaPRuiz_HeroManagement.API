using AutoMapper;
using HeroManagement.Domain.Entities;
using HeroManagement.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeroManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroController : ControllerBase
    {
        private readonly IHeroRepository _heroRepository;
        private readonly ISuperpowerRepository _superpowerRepository;
        private readonly IMapper _mapper;

        public HeroController(IHeroRepository heroRepository, ISuperpowerRepository superpowerRepository, IMapper mapper)
        {
            _heroRepository = heroRepository;
            _superpowerRepository = superpowerRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<Hero>> PostHero(Hero hero)
        {
            foreach (var heroSuperpower in hero.HeroSuperpowers)
            {
                heroSuperpower.Hero = hero;
                heroSuperpower.Superpower = await _superpowerRepository.GetSuperpowerByIdAsync(heroSuperpower.SuperpowerId);
            }

            await _heroRepository.AddHeroAsync(hero);
            return CreatedAtAction(nameof(GetHero), new { id = hero.Id }, hero);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hero>>> GetHeroes()
        {
            var heroes = await _heroRepository.GetAllHeroesAsync();
            return Ok(heroes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Hero>> GetHero(int id)
        {
            var hero = await _heroRepository.GetHeroByIdAsync(id);
            if (hero == null)
            {
                return NotFound();
            }
            return Ok(hero);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutHero(int id, Hero updatedHero)
        {
            if (id != updatedHero.Id)
            {
                return BadRequest();
            }

            // Recupere o herói existente do banco de dados
            var existingHero = await _heroRepository.GetHeroByIdAsync(id);
            if (existingHero == null)
            {
                return NotFound();
            }

            // Atualize os campos do herói existente
            existingHero.Name = updatedHero.Name;
            existingHero.HeroName = updatedHero.HeroName;
            existingHero.BirthDate = updatedHero.BirthDate;
            existingHero.Height = updatedHero.Height;
            existingHero.Weight = updatedHero.Weight;

            // Atualize as associações de HeroSuperpowers
            existingHero.HeroSuperpowers.Clear();
            foreach (var heroSuperpower in updatedHero.HeroSuperpowers)
            {
                var existingSuperpower = await _superpowerRepository.GetSuperpowerByIdAsync(heroSuperpower.SuperpowerId);
                if (existingSuperpower != null)
                {
                    existingHero.HeroSuperpowers.Add(new HeroSuperpower
                    {
                        HeroId = existingHero.Id,
                        SuperpowerId = existingSuperpower.Id
                    });
                }
            }

            try
            {
                await _heroRepository.UpdateHeroAsync(existingHero);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _heroRepository.GetHeroByIdAsync(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHero(int id)
        {
            var hero = await _heroRepository.GetHeroByIdAsync(id);
            if (hero == null)
            {
                return NotFound();
            }

            await _heroRepository.DeleteHeroAsync(id);
            return NoContent();
        }
    }

}
