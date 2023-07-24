using Microsoft.EntityFrameworkCore;
using TVShows.Domain.Entities;

namespace TVShows.Infrastructure
{
    public class TVShowsDbContext : DbContext
    {
        public TVShowsDbContext(DbContextOptions<TVShowsDbContext> options) : base(options)  { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<TVShow> TVShows { get; set; }
    }
}
