using ConsoleApp1.Entities;

namespace ConsoleApp1;

class Program
{
    static void Main(string[] args)
    {
        AppDbContext db = new AppDbContext();

        var members = new List<Member>
        {
            new Member { FullName = "Alexander Ivanov", JoinDate = DateTime.Now.AddDays(-30) },
            new Member { FullName = "Maria Petrova", JoinDate = DateTime.Now.AddDays(-20) },
            new Member { FullName = "Ivan Sydorenko", JoinDate = DateTime.Now.AddDays(-10) },
            new Member { FullName = "Olena Koval", JoinDate = DateTime.Now.AddDays(-5) },
            new Member { FullName = "Petro Hnatyuk", JoinDate = DateTime.Now }
        };
        db.Members.AddRange(members);

        var games = new List<Game>
        {
            new Game { Title = "Catan", Genre = "Strategy", MinPlayers = 3, MaxPlayers = 4 },
            new Game { Title = "Monopoly", Genre = "Economy", MinPlayers = 2, MaxPlayers = 6 },
            new Game { Title = "Dixit", Genre = "Party", MinPlayers = 3, MaxPlayers = 6 },
            new Game { Title = "Chess", Genre = "Strategy", MinPlayers = 2, MaxPlayers = 2 },
            new Game { Title = "Ticket to Ride", Genre = "Strategy", MinPlayers = 2, MaxPlayers = 5 }
        };
        db.Games.AddRange(games);

        db.SaveChanges();

        var random = new Random();
        var sessions = new List<Session>();
        for (int i = 0; i < 10; i++)
        {
            var game = games[random.Next(games.Count)];
            var member = members[random.Next(members.Count)];
        sessions.Add(new Session
        {
            GameId = game.Id,
            MemberId = member.Id,
            Date = DateTime.Now.AddDays(-random.Next(30)),
            DurationMinutes = random.Next(30, 180)
        });
        }
        db.Sessions.AddRange(sessions);
        db.SaveChanges();

        Console.WriteLine("Database created and seeded!");
    }
}
