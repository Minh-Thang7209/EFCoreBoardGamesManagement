using ConsoleApp1.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace ConsoleApp1
{
    public class AppDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Session> Sessions { get; set; }

        private readonly string _connectionString;

        public AppDbContext()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appconfig.json")
                .Build();

            _connectionString = config.GetConnectionString("DefaultConnection");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appconfig.json")
                .Build();

            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>()
                .HasMany(g => g.Sessions)
                .WithOne(s => s.Game)
                .HasForeignKey(s => s.GameId);

            modelBuilder.Entity<Member>()
                .HasMany(m => m.Sessions)
                .WithOne(s => s.Member)
                .HasForeignKey(s => s.MemberId);

            modelBuilder.Entity<Game>(b =>
            {
               b.Property(g => g.Title).IsRequired().HasMaxLength(100);
               b.ToTable(t =>
               {
                  t.HasCheckConstraint("CK_MinPlayers", "MinPlayers > 0");
                  t.HasCheckConstraint("CK_MaxPlayers", "MaxPlayers > 0");
               });
            });

            modelBuilder.Entity<Member>()
                .Property(m => m.JoinDate)
                .IsRequired();

            modelBuilder.Entity<Session>()
                .Property(s => s.Date)
                .IsRequired();
        }
    }
}
