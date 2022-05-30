
namespace ApriCode.Bll.Models
{
    public class GameModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Publisher { get; set; }
        public List<GenreModel>? Genres { get; set; }
    }
}
