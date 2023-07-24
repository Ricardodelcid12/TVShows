using Microsoft.EntityFrameworkCore;
using TVShows.Domain.Entities;
using TVShows.Domain.Repositories;

namespace TVShows.Infrastructure.Repositories
{
    public class TVShowRepository : ITVShowRepository
    {
        private readonly TVShowsDbContext _dbContext;

        public TVShowRepository(TVShowsDbContext dbContext) => _dbContext = dbContext;

        public async Task<List<TVShow>> Get()
        {
            var tvShows = await _dbContext.TVShows.ToListAsync();
            return tvShows;
        }

        public async Task<List<TVShow>> GetFavorites()
        {
            var favorites = await _dbContext.TVShows
                .Where(tvs => tvs.IsFavorite == true).ToListAsync();
            return favorites;
        }

        public async Task<List<TVShow>> UpdateIsFavorite(int id)
        {
            var tvShow = await _dbContext.TVShows.FindAsync(id);

            if (tvShow == null) 
                throw new ExceptionHandler("Something went wrong trying to retrieve your Favorites TV Shows.");

            tvShow.IsFavorite = !tvShow.IsFavorite;
            
            await _dbContext.SaveChangesAsync();

            var tvShows = await _dbContext.TVShows.ToListAsync();
            if (tvShows == null)
                throw new ExceptionHandler("Something went wrong trying to retrieve your Favorites TV Shows.");

            return tvShows;
        }
    }
}