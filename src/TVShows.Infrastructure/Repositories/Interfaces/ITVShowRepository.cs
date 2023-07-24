using TVShows.Domain.Entities;

namespace TVShows.Domain.Repositories
{
    public interface ITVShowRepository
    {
        Task<List<TVShow>> Get();
        Task<List<TVShow>> GetFavorites();
        Task<List<TVShow>> UpdateIsFavorite(int id);
    }
}