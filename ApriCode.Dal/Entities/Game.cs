
namespace ApriCode.Dal.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Publisher { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }
    }
}
