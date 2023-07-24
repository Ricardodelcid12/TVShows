using TVShows.Application.DTOs;
using static TVShows.Application.Features.UpdateIsFavorite;

namespace TVShows.Application.Common.Interfaces
{
    public interface ITVShowService
    {
        Task<List<TVShowDTO>> Get();
        Task<List<TVShowDTO>> GetFavorites();
        Task<List<TVShowDTO>> UpdateIsFavorite(UpdateIsFavoriteQuery query);
    }
}
