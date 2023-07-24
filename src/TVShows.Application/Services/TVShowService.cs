using MediatR;
using TVShows.Application.Common.Interfaces;
using TVShows.Application.DTOs;
using static TVShows.Application.Features.GetFavoritesTVShows;
using static TVShows.Application.Features.GetTVShows;
using static TVShows.Application.Features.UpdateIsFavorite;

namespace TVShows.Application.Services
{
    /// <summary>
    /// TVShowService main class service to get acces to the business logic.
    /// Uses MediatR to send messages through the application.
    /// Implements ITVShowService.
    /// </summary>
    public class TVShowService : ITVShowService
    {
        private readonly IMediator _mediator;

        public TVShowService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<List<TVShowDTO>> Get()
        {
            return await _mediator.Send(new GetTVShowsQuery());
        }

        public async Task<List<TVShowDTO>> GetFavorites()
        {
            return await _mediator.Send(new GetFavoritesTVShowsQuery());
        }

        public async Task<List<TVShowDTO>> UpdateIsFavorite(UpdateIsFavoriteQuery query)
        {
            return await _mediator.Send(query);
        }
    }
}
