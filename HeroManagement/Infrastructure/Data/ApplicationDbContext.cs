using Microsoft.EntityFrameworkCore;
using HeroManagement.Domain.Entities;

namespace HeroManagement.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Hero> Heroes { get; set; }
        public DbSet<Superpower> Superpowers { get; set; }
        public DbSet<HeroSuperpower> HeroSuperpowers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HeroSuperpower>()
                .HasKey(hs => new { hs.HeroId, hs.SuperpowerId });

            modelBuilder.Entity<HeroSuperpower>()
                .HasOne(hs => hs.Hero)
                .WithMany(h => h.HeroSuperpowers)
                .HasForeignKey(hs => hs.HeroId);

            modelBuilder.Entity<HeroSuperpower>()
                .HasOne(hs => hs.Superpower)
                .WithMany(sp => sp.HeroSuperpowers)
                .HasForeignKey(hs => hs.SuperpowerId);
        }
    }
}
