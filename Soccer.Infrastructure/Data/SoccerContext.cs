using Soccer.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Soccer.Infrastructure.Data
{
    public class SoccerContext : DbContext
    {
        public SoccerContext(DbContextOptions<SoccerContext> dbContextOptions) : base(dbContextOptions){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SoccerContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
    }
}
