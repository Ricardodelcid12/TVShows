using TVShows.Application.DTOs;
using TVShows.Domain.Entities;

namespace TVShows.Application.Extensions
{
    /// <summary>
    /// TVShowExtensions class contains the main extension methods in the application.
    /// </summary>
    public static class TVShowExtensions
    {
        /// <summary>
        /// ToTVShowDtoList is a class feature to map properties from TVShow to TVShowDTO.
        /// </summary>
        public static List<TVShowDTO> ToTVShowDtoList(this List<TVShow> tvShows)
        {
            var list = tvShows.Select(tvShow => new TVShowDTO
            {
                ToConsoleStringFormat = $"{tvShow.Id} - {tvShow.Title} {(tvShow.IsFavorite ? "*" : "")}"
            }).ToList();

            return list;
        }
    }
}
