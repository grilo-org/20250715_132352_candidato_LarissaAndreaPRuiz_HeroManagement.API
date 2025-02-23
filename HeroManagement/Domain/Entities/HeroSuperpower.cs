namespace HeroManagement.Domain.Entities
{
    public class HeroSuperpower
    {
        public int HeroId { get; set; }
        public Hero? Hero { get; set; } // Tornando opcional
        public int SuperpowerId { get; set; }
        public Superpower? Superpower { get; set; } // Tornando opcional
    }
}
