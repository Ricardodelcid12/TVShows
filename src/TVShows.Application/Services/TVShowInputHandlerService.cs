using TVShows.Application.Common.Interfaces;
using TVShows.Application.DTOs;
using static TVShows.Application.Features.UpdateIsFavorite;

namespace TVShows.Application.Services
{
    /// <summary>
    /// TVShowHandler handles user interactions and the use cases to perform the corresponding business actions.
    /// </summary>
    public class TVShowInputHandlerService : ITVShowInputHandlerService
    {

        private readonly ITVShowService _tvShowService;
        private Dictionary<string, Func<Task<TVShowHandlerResultDTO>>> commandHandlers;

        public TVShowInputHandlerService(ITVShowService tvShowService)
        {
            _tvShowService = tvShowService;
            commandHandlers = CommandsInicializer();
        }

        /// <summary>
        /// CommandsInicializer create a new dictionary with the available option commands.
        /// </summary>
        private Dictionary<string, Func<Task<TVShowHandlerResultDTO>>> CommandsInicializer()
        {
            return commandHandlers = new Dictionary<string, Func<Task<TVShowHandlerResultDTO>>>
            {
                { "list", HandleListCommand },
                { "favorites", HandleFavoritesCommand }
            };
        }

        /// <summary>
        /// HandleUserInput validate the userInput string to take decisions about the right business action.
        /// </summary>
        public async Task<TVShowHandlerResultDTO> HandleUserInput(string userInput)
        {
            string command = userInput.Trim().ToLower();

            if (int.TryParse(command, out int id))
            {
                return await HandleUpdateIsFavoriteCommand(new UpdateIsFavoriteQuery { Id = id });
            }

            if (commandHandlers.TryGetValue(command, out var handler))
            {
                return await handler();
            }

            return new TVShowHandlerResultDTO
            {
                TVShows = null,
                Message = "INFORMATION!: Invalid input, please follow the input instructions."
            };
        }

        /// <summary>
        /// HandleListCommand retrieve all tv shows as a representation list.
        /// </summary>
        private async Task<TVShowHandlerResultDTO> HandleListCommand()
        {
            var allTVShows = await _tvShowService.Get();

            return new TVShowHandlerResultDTO
            {
                TVShows = allTVShows,
                Message = "List of TV Shows:"
            };
        }

        /// <summary>
        /// HandleListCommand retrieve all favorites user tv shows as a representation list.
        /// </summary>
        private async Task<TVShowHandlerResultDTO> HandleFavoritesCommand()
        {
            var favorites = await _tvShowService.GetFavorites();

            return new TVShowHandlerResultDTO
            {
                TVShows = favorites,
                Message = !favorites.Any()
                    ? "You don't have favorites tv shows."
                    : "List of Favorites TV Shows:"
            };
        }

        /// <summary>
        /// HandleUpdateIsFavoriteCommand Update the IsFavorite tv show state property, then retrieve all tv shows as a representation list.
        /// </summary>
        private async Task<TVShowHandlerResultDTO> HandleUpdateIsFavoriteCommand(UpdateIsFavoriteQuery query)
        {
            var allTVShows = await _tvShowService.UpdateIsFavorite(query);

            return new TVShowHandlerResultDTO
            {
                TVShows = allTVShows,
                Message = $"TV Show:'{query.Id}' Is Favorite state updated."
            };
        }
    }
}
