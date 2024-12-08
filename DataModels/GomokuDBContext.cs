using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace PG.API.DataModels
{
    public class GomokuDBContext : DbContext
    {
        public GomokuDBContext(DbContextOptions<GomokuDBContext> options)
             : base(options)
        {
        }

        public DbSet<BoardGame> BoardGames { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<BoardPlayer> BoardPlayers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<BoardGame>().HasKey(x => x.Id);
            builder.Entity<Player>().HasKey(x => x.Id);
            builder.Entity<BoardPlayer>().HasKey(x => x.Id);
            builder.Entity<BoardDesign>().HasKey(x=>x.Id);
            builder.Entity<BoardDesign>().HasOne<BoardGame>(p => p.BoardGames)
                   .WithMany(g => g.BoardDesigns)
                   .HasForeignKey(p => p.BoardId);
        }
    }
}