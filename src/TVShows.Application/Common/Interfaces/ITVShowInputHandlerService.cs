using TVShows.Application.DTOs;

namespace TVShows.Application.Common.Interfaces
{
    public interface ITVShowInputHandlerService
    {
        Task<TVShowHandlerResultDTO> HandleUserInput(string userInput);
    }
}