namespace ApriCode.Models.Response
{
    public class GameResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Publisher { get; set; }
        public List<GenreResponse> Genres { get; set; }
    }
}
