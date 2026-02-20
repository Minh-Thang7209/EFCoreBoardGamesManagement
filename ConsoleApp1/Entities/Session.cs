using System;

namespace ConsoleApp1.Entities
{
    public class Session
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int MemberId { get; set; }
        public DateTime Date { get; set; }
        public int DurationMinutes { get; set; }
    }
}
