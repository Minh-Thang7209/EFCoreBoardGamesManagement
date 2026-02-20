namespace ConsoleApp1.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Genre { get ; set; } = null!;
        public int MinPlayers { get; set; }
        public int MaxPlayers { get; set; }
        

        public List<Session>  Sessions { get; set; } = new List<Session>();
    }
}
